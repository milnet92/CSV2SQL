using CSV2SQL.Core;
using CSV2SQL.Forms;
using CVS2SQL.Core.Scripting;
using DQSAutomateInterpreter.Interpreter;
using DQSAutomateInterpreter.Lexer;
using DQSAutomateInterpreter.Parser;
using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CSV2SQL.Forms.Controls
{
    public class CodeControl : UserControl
    {
        public string SourceCode { get => fctb.Text; }
        public string FileName { get; set; }
        public FileTable FileTable { get; set; }
        public bool Saved { get; set; }

        public delegate void SaveEventHandler(object sender, EventArgs e);
        public delegate void InterpretEventHandler(object sender, InterpretEventArgs e);

        public event SaveEventHandler Save;
        public event InterpretEventHandler Interpreted;

        TextStyle brownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Regular);
        TextStyle blueStyle = new TextStyle(new SolidBrush(Color.FromArgb(86, 156, 214)), null, FontStyle.Regular);
        TextStyle italicGreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        TextStyle greyStyle = new TextStyle(new SolidBrush(Color.FromArgb(112, 128, 144)), null, FontStyle.Regular);
        TextStyle greenStyle = new TextStyle(new SolidBrush(Color.FromArgb(0, 150, 150)), null, FontStyle.Regular);
        TextStyle orangeStyle = new TextStyle(new SolidBrush(Color.FromArgb(255, 69, 0)), null, FontStyle.Regular);

        public static Regex StringRegex = new Regex(@""".*?""");
        public static Regex KeyWordRegex = new Regex(@"\b(class|var|func|as|static|false|true|if|else|while|do|for|break|in|continue|return|import|enum|foreach|throw|try|catch|finally|lambda|using)\b");
        public static Regex SqlKeyWordRegex = new Regex(@"\b(select|from|ttsbegin|ttscommit|ttsabort|select_recordset|update_recordset|inner|outer|join|insert_recordset|top|like)\b");
        public static Regex CommentRegex = new Regex(@"\/\/.*");
        public static Regex LiteralRegex = new Regex(@"\b(null|string|integer|bool|char|\d\d*?\.?\d*)\b");

        public static Regex NativeClassesRegex = GetNativeClassesRegex();
        public static Regex NativeFunctionsRegex = GetNativeFunctionsRegex();

        FastColoredTextBox fctb;
        internal ScriptForm ScriptForm;

        public CodeControl()
        {
            Initialize();
        }

        public CodeControl(ScriptForm form, FileTable fileTable, string sourceCode)
        {
            ScriptForm = form;
            FileTable = fileTable;

            Initialize();

            fctb.Text = sourceCode;
        }

        private void Initialize()
        {

            fctb = CreateColoredRichBox();

            this.Controls.Add(fctb);

            this.GotFocus += CodeTab_GotFocus;

            SetNotSavedChar();
        }

        private void Tb_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop) || !fctb.Enabled) return;

            string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (data.Length > 0)
            {
                fctb.Text = File.ReadAllText(data[0]);
            }
        }

        private void Tb_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = (fctb.Enabled && e.Data.GetDataPresent(DataFormats.FileDrop)) ? DragDropEffects.All : DragDropEffects.None;
        }

        public void OnSave(EventArgs e)
        {
            Save?.Invoke(this, e);
        }

        public void OnInterpret(InterpretEventArgs e)
        {
            Interpreted?.Invoke(this, e);
        }

        private void CodeTab_GotFocus(object sender, EventArgs e)
        {
            fctb.Focus();
        }

        private FastColoredTextBox CreateColoredRichBox()
        {
            var tb = new FastColoredTextBox();
            tb.Font = new Font("Consolas", 9.75f);
            tb.Dock = DockStyle.Fill;
            tb.BorderStyle = BorderStyle.Fixed3D;
            tb.LeftPadding = 17;

            tb.Language = Language.Custom;
            tb.DelayedTextChangedInterval = 300;
            tb.DelayedEventsInterval = 300;
            tb.ShowFoldingLines = false;
            tb.HighlightingRangeType = HighlightingRangeType.VisibleRange;
            tb.LeftBracket = '{';
            tb.RightBracket = '}';
            tb.AutoCompleteBrackets = true;

            tb.TextChangedDelayed += fctb_TextChangedDelayed;
            tb.TextChanged += Tb_TextChanged;
            tb.KeyDown += Tb_KeyDown;
            tb.DragEnter += Tb_DragEnter;
            tb.DragDrop += Tb_DragDrop;
            tb.AllowDrop = true;

            return tb;
        }

        private void Tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Saved = false;
        }

        private void SetNotSavedChar()
        {
            this.Text += "*";
        }

        private void Tb_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        private void fctb_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearFoldingMarkers();
            e.ChangedRange.ClearStyle(orangeStyle, brownStyle, italicGreenStyle, blueStyle);

            e.ChangedRange.SetStyle(italicGreenStyle, CommentRegex);
            e.ChangedRange.SetStyle(brownStyle, StringRegex);
            e.ChangedRange.SetStyle(blueStyle, KeyWordRegex);
            e.ChangedRange.SetStyle(blueStyle, SqlKeyWordRegex);
            e.ChangedRange.SetStyle(orangeStyle, LiteralRegex);

            ApplyFunctionHightlight(e.ChangedRange);

            e.ChangedRange.SetFoldingMarkers("{", "}");

            var parseResult = Interpret(true);
        }

        private void ApplyFunctionHightlight(Range changedRange)
        {
            changedRange.ClearStyle(greyStyle);

            //Apply to natives
            changedRange.SetStyle(greyStyle, NativeFunctionsRegex);

            fctb.Range.ClearStyle(greenStyle);
            fctb.Range.SetStyle(greenStyle, NativeClassesRegex);

            //find function declarations, highlight all of their entry into the code
            foreach (Range found in fctb.GetRanges(@"\b(class)\s+(?<range>\w+)\b"))
                fctb.Range.SetStyle(greenStyle, @"\b" + found.Text + @"\b");

            foreach (Range found in fctb.GetRanges(@"\b(func)\s+(?<range>\w+)\b"))
                fctb.Range.SetStyle(greyStyle, @"\b" + found.Text + @"\b");
        }

        private static Regex GenerateSimpleRegex(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"\b(");

            bool first = true;
            foreach (var func in list)
            {
                if (!first)
                {
                    sb.Append("|");
                }

                sb.Append(func);
                first = false;
            }

            sb.Append(@")\b");

            return new Regex(sb.ToString());
        }

        private static Regex GetNativeClassesRegex()
        {
            return GenerateSimpleRegex(DQSAutomateInterpreter.Util.TypeHelper.GetDotNetTypeNames());
        }

        private static Regex GetNativeFunctionsRegex()
        {
            return GenerateSimpleRegex(DQSAutomateInterpreter.Util.TypeHelper.GetDotNetFunctionNames());
        }

        public IInterpreterResult Interpret(bool parseOnly)
        {
            IInterpreterResult result = InterpreterResult.Ok;

            DatabaseConnection connection = DBConnectionManager.Instance.GetConnectionById(FileTable.ConnectionId);
            
            var configuration = DQSAutomateInterpreter.Core.Configuration.InterpreterConfiguration.Default;

            configuration.DatabaseConfiguration.Server = connection.Server;
            configuration.DatabaseConfiguration.Database = connection.DataBase;
            configuration.DatabaseConfiguration.Password = CSV2SQL.Core.Security.SecurityHelper.SecureStringToString(connection.Password);
            configuration.DatabaseConfiguration.ConnectionTimeout = 30;
            configuration.DatabaseConfiguration.IntegratedSecurity = connection.AuthenticationMethod == Enums.AuthenticationMethod.Windows;
            configuration.DatabaseConfiguration.User = connection.UserName;

            try
            {
                using (var session = DQSAutomateInterpreter.Core.Environment.CreateOneTimeSession(new InterpreterOptions()
                {
                    Arguments = new string[0],
                    Configuration = configuration,
                    StartingFileName = FileName,
                    Mode = InterpreterOptions.InterpreterExecutionMode.Release
                }))
                {

                    if (parseOnly)
                    {
                        try
                        {
                            _ = session.Parse(fctb.Text);
                        }
                        catch (Exception ex)
                        {
                            result = new InterpreterResult()
                            {
                                Exception = ex
                            };
                        }
                    }
                    else
                    {
                        result = session.Execute(fctb.Text);
                    }

                    OnInterpret(new InterpretEventArgs(result, parseOnly));
                }

                return result;
            }
            catch (Exception ex)
            {
                OnInterpret(new InterpretEventArgs(new InterpreterResult(ex), parseOnly));
                return result;
            }
        }
    }
}
