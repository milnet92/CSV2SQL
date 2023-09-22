using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSV2SQL.Core;
using CSV2SQL.Forms.Controls;
using CSV2SQL.Properties;
using CVS2SQL.Core.Scripting;
using DQSAutomateInterpreter.Core;
using DQSAutomateInterpreter.Core.Exceptions;

namespace CSV2SQL.Forms
{
    public partial class ScriptForm : Form
    {
        bool lastParseCorrect = false;
        CodeControl codeControl;
        FileTable fileTable;
        ConsoleCapture consoleCapture = new ConsoleCapture();

        public ScriptForm(FileTable fileTable)
        {
            this.Icon = CSV2SQL.Properties.Resources.banana;
            this.fileTable = fileTable;

            InitializeComponent();

            var connection = DBConnectionManager.Instance.GetConnectionById(fileTable.ConnectionId);
            this.Text = $"Execute script: {fileTable.TableName} ({connection.Server}.{connection.DataBase})";

            string sourceCode = Settings.Default.SourceCode;
            sourceCode = sourceCode.Replace("##", fileTable.TableName);

            codeControl = new CodeControl(this, fileTable, sourceCode)
            {
                Dock = DockStyle.Fill
            };

            this.codePanel.Controls.Add(codeControl);

            Console.SetOut(consoleCapture);

            consoleCapture.ConsoleWrite += ConsoleCapture_ConsoleWrite;
            consoleCapture.ConsoleWriteLine += ConsoleCapture_ConsoleWriteLine;

            this.codeControl.Interpreted += CodeControl_Interpreted;

        }

        private void CodeControl_Interpreted(object sender, InterpretEventArgs e)
        {
            var parsedOk = !(e.Result.Exception?.InnerException is ParseException);

            codePanel.Invoke((MethodInvoker)delegate
            {
                if (e.OnlyParsed)
                {
                    outputTextBox.Text = "";
                }

                if (!e.Result.Success)
                {
                    outputTextBox.AppendText(e.Result.Exception.Message.ToString());
                }
                else if (!e.OnlyParsed)
                {
                    outputTextBox.AppendText("\n");
                    outputTextBox.AppendText($"Execution finished in {e.Result.ExecutionTime.Seconds} second(s).");
                }

                lastParseCorrect = parsedOk;

                runButton.Enabled = lastParseCorrect;
            });
        }

        private void ConsoleCapture_ConsoleWriteLine(object sender, ConsoleWriteEventArgs e)
        {
            codePanel.Invoke((MethodInvoker)delegate
            {
                outputTextBox.AppendText(e.Text + System.Environment.NewLine);
                outputTextBox.Refresh();
            });
        }

        private void ConsoleCapture_ConsoleWrite(object sender, ConsoleWriteEventArgs e)
        {
            codePanel.Invoke((MethodInvoker)delegate
            {
                outputTextBox.AppendText(e.Text);
                outputTextBox.Refresh();
            });
        }

        public void ExecuteRunAction()
        {
            Thread t = new Thread(new ThreadStart(Interpret));
            t.Start();
        }

        private void Interpret()
        {
            splitContainer.Panel2.Invoke((MethodInvoker)delegate
            {
                outputTextBox.Text = "";

                codeControl.Enabled = false;
                runButton.Enabled = false;

                codeControl.Interpret(false);

                runButton.Enabled = true;
                codeControl.Enabled = true;

                codeControl.Focus();
            });
        }

        private void ScriptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            consoleCapture.ConsoleWrite -= ConsoleCapture_ConsoleWrite;
            consoleCapture.ConsoleWriteLine -= ConsoleCapture_ConsoleWriteLine;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            ExecuteRunAction();
        }

        private void runButton_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void runButton_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}
