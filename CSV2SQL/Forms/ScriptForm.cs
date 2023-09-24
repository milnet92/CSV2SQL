using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Windows.Forms;
using CSV2SQL.Core;
using CSV2SQL.Forms.Controls;
using CSV2SQL.Properties;
using CVS2SQL.Core.Scripting;
using DQSAutomateInterpreter.Core.Exceptions;

namespace CSV2SQL.Forms
{
    public partial class ScriptForm : Form
    {
        bool lastParseCorrect = false;
        CodeControl codeControl;
        FileTable fileTable;
        ConsoleCapture consoleCapture = new ConsoleCapture();

        Thread executingThread = null;
        bool running = false;

        public ScriptForm(FileTable fileTable)
        {
            this.Icon = CSV2SQL.Properties.Resources.banana;
            this.fileTable = fileTable;

            InitializeComponent();

            var connection = DBConnectionManager.Instance.GetConnectionById(fileTable.ConnectionId);
            this.Text = $"Execute script: {fileTable.TableName} ({connection.Server}.{connection.DataBase})";

            string sourceCode = Resources.ScriptTemplate;
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
            this.codeControl.KeyDown += OnKeyDown;
            this.KeyDown += OnKeyDown;
            this.outputTextBox.KeyDown += OnKeyDown;
            this.DragEnter += ScriptForm_DragEnter;
            this.DragDrop += ScriptForm_DragDrop;
        }

        private void ScriptForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = !running && e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void ScriptForm_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Execute();
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                StopExecution();
            }
        }

        private void CodeControl_Interpreted(object sender, InterpretEventArgs e)
        {
            var parsedOk = !(e.Result.Exception?.InnerException is ParseException || e.Result.Exception is ParseException);

            codePanel.Invoke((MethodInvoker)delegate
            {
                if (e.OnlyParsed)
                {
                    outputTextBox.Text = "";
                }

                if (!e.Result.Success)
                {
                    if (e.Result.Exception is ThreadAbortException)
                        outputTextBox.AppendText("Execution was cancelled by the user.");
                    else
                        outputTextBox.AppendText(e.Result.Exception.Message.ToString());
                }
                else if (!e.OnlyParsed)
                {
                    outputTextBox.AppendText("\n");
                    outputTextBox.AppendText($"Execution finished in {e.Result.ExecutionTime}.");
                }

                lastParseCorrect = parsedOk;

                runButton.Enabled = lastParseCorrect;
                codeControl.Enabled = true;
                stopButton.Enabled = false;
                running = false;
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

        public void Execute()
        {
            if (!lastParseCorrect || running) return;

            executingThread = new Thread(new ThreadStart(Interpret));
            executingThread.Start();
            running = true;
        }

        public void StopExecution()
        {
            if (running)
            {
                stopButton.Enabled = false;
                executingThread.Abort();
            }
        }

        private void Interpret()
        {
            splitContainer.Panel2.Invoke((MethodInvoker)delegate
            {
                outputTextBox.Text = "";

                codeControl.Enabled = false;
                runButton.Enabled = false;
                stopButton.Enabled = true;
            });

            codeControl.Interpret(false);

            splitContainer.Panel2.Invoke((MethodInvoker)delegate
            {
                runButton.Enabled = true;
                codeControl.Enabled = true;
                stopButton.Enabled = false;
                running = false;
                codeControl.Focus();
            });
        }

        private void ScriptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (running)
            {
                if (MessageBox.Show(this, "Script is still running. Do you want to stop execution and exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    == DialogResult.Yes)
                {
                    StopExecution();
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }

            consoleCapture.ConsoleWrite -= ConsoleCapture_ConsoleWrite;
            consoleCapture.ConsoleWriteLine -= ConsoleCapture_ConsoleWriteLine;
            codeControl.Interpreted -= CodeControl_Interpreted;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            Execute();
        }

        private void runButton_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void runButton_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            StopExecution();
        }
    }
}
