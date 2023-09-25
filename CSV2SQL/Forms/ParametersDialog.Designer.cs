namespace CSV2SQL.Forms
{
    partial class ParametersDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbChangeTableName = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txSchema = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbPrimaryKey = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPreviewRowCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbShowOptions = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txSeparator = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btAccept = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Default schema";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbChangeTableName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txSchema);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(32, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(376, 125);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database";
            // 
            // cbChangeTableName
            // 
            this.cbChangeTableName.AutoSize = true;
            this.cbChangeTableName.Location = new System.Drawing.Point(212, 85);
            this.cbChangeTableName.Margin = new System.Windows.Forms.Padding(4);
            this.cbChangeTableName.Name = "cbChangeTableName";
            this.cbChangeTableName.Size = new System.Drawing.Size(18, 17);
            this.cbChangeTableName.TabIndex = 7;
            this.cbChangeTableName.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(27, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 37);
            this.label4.TabIndex = 6;
            this.label4.Text = "Change table name when importing the same file";
            // 
            // txSchema
            // 
            this.txSchema.Location = new System.Drawing.Point(155, 34);
            this.txSchema.Margin = new System.Windows.Forms.Padding(4);
            this.txSchema.Name = "txSchema";
            this.txSchema.Size = new System.Drawing.Size(117, 22);
            this.txSchema.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbPrimaryKey);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbPreviewRowCount);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbShowOptions);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txSeparator);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(32, 151);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(376, 163);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File";
            // 
            // cbPrimaryKey
            // 
            this.cbPrimaryKey.AutoSize = true;
            this.cbPrimaryKey.Location = new System.Drawing.Point(155, 123);
            this.cbPrimaryKey.Margin = new System.Windows.Forms.Padding(4);
            this.cbPrimaryKey.Name = "cbPrimaryKey";
            this.cbPrimaryKey.Size = new System.Drawing.Size(18, 17);
            this.cbPrimaryKey.TabIndex = 9;
            this.cbPrimaryKey.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 122);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Create primary key";
            // 
            // tbPreviewRowCount
            // 
            this.tbPreviewRowCount.Location = new System.Drawing.Point(155, 87);
            this.tbPreviewRowCount.Margin = new System.Windows.Forms.Padding(4);
            this.tbPreviewRowCount.Name = "tbPreviewRowCount";
            this.tbPreviewRowCount.Size = new System.Drawing.Size(62, 22);
            this.tbPreviewRowCount.TabIndex = 7;
            this.tbPreviewRowCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 90);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Preview rows";
            // 
            // cbShowOptions
            // 
            this.cbShowOptions.AutoSize = true;
            this.cbShowOptions.Location = new System.Drawing.Point(155, 62);
            this.cbShowOptions.Margin = new System.Windows.Forms.Padding(4);
            this.cbShowOptions.Name = "cbShowOptions";
            this.cbShowOptions.Size = new System.Drawing.Size(18, 17);
            this.cbShowOptions.TabIndex = 5;
            this.cbShowOptions.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Show options dialog";
            // 
            // txSeparator
            // 
            this.txSeparator.Location = new System.Drawing.Point(154, 25);
            this.txSeparator.Margin = new System.Windows.Forms.Padding(4);
            this.txSeparator.Name = "txSeparator";
            this.txSeparator.Size = new System.Drawing.Size(72, 22);
            this.txSeparator.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Default separator";
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(237, 322);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(100, 28);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btAccept
            // 
            this.btAccept.Location = new System.Drawing.Point(115, 322);
            this.btAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(100, 28);
            this.btAccept.TabIndex = 4;
            this.btAccept.Text = "Accept";
            this.btAccept.UseVisualStyleBackColor = true;
            this.btAccept.Click += new System.EventHandler(this.btAccept_Click);
            // 
            // ParametersDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 379);
            this.Controls.Add(this.btAccept);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ParametersDialog";
            this.Text = "Parameters";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txSchema;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txSeparator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btAccept;
        private System.Windows.Forms.CheckBox cbShowOptions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbChangeTableName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPreviewRowCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbPrimaryKey;
        private System.Windows.Forms.Label label6;
    }
}