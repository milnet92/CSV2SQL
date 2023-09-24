namespace CSV2SQL.Forms
{
    partial class ScriptForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolBoxPannel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.runButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.codePanel = new System.Windows.Forms.Panel();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.toolBoxPannel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBoxPannel
            // 
            this.toolBoxPannel.Controls.Add(this.toolStrip1);
            this.toolBoxPannel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBoxPannel.Location = new System.Drawing.Point(0, 0);
            this.toolBoxPannel.Name = "toolBoxPannel";
            this.toolBoxPannel.Size = new System.Drawing.Size(1009, 33);
            this.toolBoxPannel.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1009, 32);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // runButton
            // 
            this.runButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runButton.Image = global::CSV2SQL.Properties.Resources.run;
            this.runButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(67, 29);
            this.runButton.Text = "Run";
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            this.runButton.MouseEnter += new System.EventHandler(this.runButton_MouseEnter);
            this.runButton.MouseLeave += new System.EventHandler(this.runButton_MouseLeave);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 33);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.codePanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.outputTextBox);
            this.splitContainer.Size = new System.Drawing.Size(1009, 581);
            this.splitContainer.SplitterDistance = 378;
            this.splitContainer.TabIndex = 3;
            // 
            // codePanel
            // 
            this.codePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codePanel.Location = new System.Drawing.Point(0, 0);
            this.codePanel.Name = "codePanel";
            this.codePanel.Size = new System.Drawing.Size(1009, 378);
            this.codePanel.TabIndex = 6;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTextBox.Location = new System.Drawing.Point(0, 0);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputTextBox.Size = new System.Drawing.Size(1009, 199);
            this.outputTextBox.TabIndex = 2;
            this.outputTextBox.WordWrap = false;
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 614);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolBoxPannel);
            this.Name = "ScriptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScriptForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScriptForm_FormClosing);
            this.toolBoxPannel.ResumeLayout(false);
            this.toolBoxPannel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel toolBoxPannel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel codePanel;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton runButton;
    }
}