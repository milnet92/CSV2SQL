using System.Drawing;
using System.Windows.Forms;

namespace CSV2SQL.Forms
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tsApplication = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLog = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutConnections = new System.Windows.Forms.TableLayoutPanel();
            this.lbConnections = new CSV2SQL.Forms.Controls.CustomListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitleFiles = new System.Windows.Forms.Label();
            this.lbFiles = new CSV2SQL.Forms.Controls.CustomListBox();
            this.mainTab = new CSV2SQL.Forms.Controls.FileTab();
            this.tsApplication.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutConnections.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsApplication
            // 
            this.tsApplication.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsApplication.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.helpToolStripButton});
            this.tsApplication.Location = new System.Drawing.Point(0, 0);
            this.tsApplication.Name = "tsApplication";
            this.tsApplication.Size = new System.Drawing.Size(1137, 27);
            this.tsApplication.TabIndex = 0;
            this.tsApplication.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::CSV2SQL.Properties.Resources.settings;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton1.Text = "Settings";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.helpToolStripButton.Text = "About";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Controls.Add(this.lblLog, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1137, 625);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLog.Location = new System.Drawing.Point(4, 600);
            this.lblLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(1137, 25);
            this.lblLog.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mainTab);
            this.splitContainer1.Size = new System.Drawing.Size(1137, 592);
            this.splitContainer1.SplitterDistance = 386;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutConnections);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Size = new System.Drawing.Size(384, 590);
            this.splitContainer2.SplitterDistance = 207;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutConnections
            // 
            this.tableLayoutConnections.ColumnCount = 1;
            this.tableLayoutConnections.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutConnections.Controls.Add(this.lbConnections, 0, 1);
            this.tableLayoutConnections.Controls.Add(this.label1, 0, 0);
            this.tableLayoutConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutConnections.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutConnections.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutConnections.Name = "tableLayoutConnections";
            this.tableLayoutConnections.RowCount = 2;
            this.tableLayoutConnections.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutConnections.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutConnections.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutConnections.Size = new System.Drawing.Size(384, 207);
            this.tableLayoutConnections.TabIndex = 1;
            // 
            // lbConnections
            // 
            this.lbConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbConnections.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbConnections.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConnections.FormattingEnabled = true;
            this.lbConnections.IntegralHeight = false;
            this.lbConnections.ItemHeight = 30;
            this.lbConnections.Location = new System.Drawing.Point(4, 29);
            this.lbConnections.Margin = new System.Windows.Forms.Padding(4);
            this.lbConnections.Name = "lbConnections";
            this.lbConnections.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbConnections.Size = new System.Drawing.Size(376, 174);
            this.lbConnections.TabIndex = 7;
            this.lbConnections.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbConnections_MouseDoubleClick);
            this.lbConnections.Resize += new System.EventHandler(this.lbConnections_Resize);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Connections";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.lblTitleFiles, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbFiles, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(384, 378);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblTitleFiles
            // 
            this.lblTitleFiles.AutoSize = true;
            this.lblTitleFiles.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lblTitleFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleFiles.Location = new System.Drawing.Point(0, 0);
            this.lblTitleFiles.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitleFiles.Name = "lblTitleFiles";
            this.lblTitleFiles.Size = new System.Drawing.Size(384, 25);
            this.lblTitleFiles.TabIndex = 0;
            this.lblTitleFiles.Text = "Files";
            this.lblTitleFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbFiles
            // 
            this.lbFiles.AllowDrop = true;
            this.lbFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.IntegralHeight = false;
            this.lbFiles.ItemHeight = 30;
            this.lbFiles.Location = new System.Drawing.Point(4, 29);
            this.lbFiles.Margin = new System.Windows.Forms.Padding(4);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(376, 345);
            this.lbFiles.TabIndex = 1;
            this.lbFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbFiles_DragDrop);
            this.lbFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbFiles_DragEnter);
            this.lbFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbFiles_MouseDoubleClick);
            this.lbFiles.Resize += new System.EventHandler(this.lbFiles_Resize);
            // 
            // mainTab
            // 
            this.mainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTab.Location = new System.Drawing.Point(0, 0);
            this.mainTab.Margin = new System.Windows.Forms.Padding(0);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(744, 590);
            this.mainTab.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 652);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tsApplication);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "CSV2SQL";
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.tsApplication.ResumeLayout(false);
            this.tsApplication.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutConnections.ResumeLayout(false);
            this.tableLayoutConnections.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip tsApplication;
        private Controls.FileTab mainTab;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblLog;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private TableLayoutPanel tableLayoutConnections;
        private Controls.CustomListBox lbConnections;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblTitleFiles;
        private Controls.CustomListBox lbFiles;
        private ToolStripButton toolStripButton1;
        private ToolStripButton helpToolStripButton;
    }
}

