namespace CSV2SQL.Forms
{
    partial class FileLoadOptionsDefaultDialog
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
            this.tbTableName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSchema = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFirstRowHeader = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSeparator = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbDatabase = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btAccept = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Table name";
            // 
            // tbTableName
            // 
            this.tbTableName.Location = new System.Drawing.Point(155, 44);
            this.tbTableName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbTableName.Name = "tbTableName";
            this.tbTableName.Size = new System.Drawing.Size(217, 22);
            this.tbTableName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Schema";
            // 
            // tbSchema
            // 
            this.tbSchema.Location = new System.Drawing.Point(155, 82);
            this.tbSchema.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSchema.Name = "tbSchema";
            this.tbSchema.Size = new System.Drawing.Size(77, 22);
            this.tbSchema.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbFirstRowHeader);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbSeparator);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbTableName);
            this.groupBox1.Controls.Add(this.tbSchema);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(39, 30);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(381, 213);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load options";
            // 
            // cbFirstRowHeader
            // 
            this.cbFirstRowHeader.AutoSize = true;
            this.cbFirstRowHeader.Location = new System.Drawing.Point(155, 172);
            this.cbFirstRowHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbFirstRowHeader.Name = "cbFirstRowHeader";
            this.cbFirstRowHeader.Size = new System.Drawing.Size(18, 17);
            this.cbFirstRowHeader.TabIndex = 7;
            this.cbFirstRowHeader.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 172);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "First row header";
            // 
            // tbSeparator
            // 
            this.tbSeparator.Location = new System.Drawing.Point(155, 121);
            this.tbSeparator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSeparator.Name = "tbSeparator";
            this.tbSeparator.Size = new System.Drawing.Size(77, 22);
            this.tbSeparator.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Field separator";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbServer);
            this.groupBox2.Controls.Add(this.tbDatabase);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(465, 30);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(325, 213);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(103, 44);
            this.tbServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbServer.Name = "tbServer";
            this.tbServer.ReadOnly = true;
            this.tbServer.Size = new System.Drawing.Size(192, 22);
            this.tbServer.TabIndex = 9;
            // 
            // tbDatabase
            // 
            this.tbDatabase.Location = new System.Drawing.Point(103, 82);
            this.tbDatabase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.ReadOnly = true;
            this.tbDatabase.Size = new System.Drawing.Size(192, 22);
            this.tbDatabase.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 86);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Database";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 48);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Server";
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(691, 263);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(100, 28);
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btAccept
            // 
            this.btAccept.Location = new System.Drawing.Point(568, 263);
            this.btAccept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(100, 28);
            this.btAccept.TabIndex = 7;
            this.btAccept.Text = "Accept";
            this.btAccept.UseVisualStyleBackColor = true;
            this.btAccept.Click += new System.EventHandler(this.btAccept_Click);
            // 
            // FileLoadOptionsDefaultDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 306);
            this.Controls.Add(this.btAccept);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FileLoadOptionsDefaultDialog";
            this.Text = "Load file";
            this.Load += new System.EventHandler(this.FileLoadOptionsDefaultDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSchema;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbFirstRowHeader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSeparator;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.TextBox tbDatabase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btAccept;
    }
}