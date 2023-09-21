namespace CSV2SQL.Forms
{
    partial class FileLoadOptionsMultipleDialog
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
            this.btAccept = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbDatabase = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFirstRowHeader = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSeparator = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboConnection = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbSchema = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btAccept
            // 
            this.btAccept.Location = new System.Drawing.Point(613, 316);
            this.btAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(100, 28);
            this.btAccept.TabIndex = 11;
            this.btAccept.Text = "Accept";
            this.btAccept.UseVisualStyleBackColor = true;
            this.btAccept.Click += new System.EventHandler(this.btAccept_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(736, 316);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(100, 28);
            this.btCancel.TabIndex = 10;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbServer);
            this.groupBox2.Controls.Add(this.tbDatabase);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(447, 76);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(389, 213);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection details";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(103, 44);
            this.tbServer.Margin = new System.Windows.Forms.Padding(4);
            this.tbServer.Name = "tbServer";
            this.tbServer.ReadOnly = true;
            this.tbServer.Size = new System.Drawing.Size(260, 22);
            this.tbServer.TabIndex = 9;
            // 
            // tbDatabase
            // 
            this.tbDatabase.Location = new System.Drawing.Point(103, 82);
            this.tbDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.ReadOnly = true;
            this.tbDatabase.Size = new System.Drawing.Size(260, 22);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbFirstRowHeader);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbSeparator);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(24, 196);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(381, 93);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File options";
            // 
            // cbFirstRowHeader
            // 
            this.cbFirstRowHeader.AutoSize = true;
            this.cbFirstRowHeader.Location = new System.Drawing.Point(136, 63);
            this.cbFirstRowHeader.Margin = new System.Windows.Forms.Padding(4);
            this.cbFirstRowHeader.Name = "cbFirstRowHeader";
            this.cbFirstRowHeader.Size = new System.Drawing.Size(18, 17);
            this.cbFirstRowHeader.TabIndex = 7;
            this.cbFirstRowHeader.UseVisualStyleBackColor = true;
            this.cbFirstRowHeader.CheckedChanged += new System.EventHandler(this.cbFirstRowHeader_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "First row header";
            // 
            // tbSeparator
            // 
            this.tbSeparator.Location = new System.Drawing.Point(135, 27);
            this.tbSeparator.Margin = new System.Windows.Forms.Padding(4);
            this.tbSeparator.Name = "tbSeparator";
            this.tbSeparator.Size = new System.Drawing.Size(77, 22);
            this.tbSeparator.TabIndex = 5;
            this.tbSeparator.TextChanged += new System.EventHandler(this.tbSeparator_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Field separator";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Connection";
            // 
            // conComboBox
            // 
            this.comboConnection.DisplayMember = "Name";
            this.comboConnection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboConnection.FormattingEnabled = true;
            this.comboConnection.Location = new System.Drawing.Point(113, 24);
            this.comboConnection.Name = "conComboBox";
            this.comboConnection.Size = new System.Drawing.Size(723, 24);
            this.comboConnection.TabIndex = 13;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbSchema);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tbTableName);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(24, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(381, 113);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Table options";
            // 
            // tbSchema
            // 
            this.tbSchema.Location = new System.Drawing.Point(136, 65);
            this.tbSchema.Margin = new System.Windows.Forms.Padding(4);
            this.tbSchema.Name = "tbSchema";
            this.tbSchema.Size = new System.Drawing.Size(77, 22);
            this.tbSchema.TabIndex = 5;
            this.tbSchema.TextChanged += new System.EventHandler(this.tbSchema_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Schema";
            // 
            // tbTableName
            // 
            this.tbTableName.Location = new System.Drawing.Point(136, 29);
            this.tbTableName.Margin = new System.Windows.Forms.Padding(4);
            this.tbTableName.Name = "tbTableName";
            this.tbTableName.Size = new System.Drawing.Size(217, 22);
            this.tbTableName.TabIndex = 3;
            this.tbTableName.TextChanged += new System.EventHandler(this.tbTableName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Table name";
            // 
            // FileLoadOptionsMultipleDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 357);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.comboConnection);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btAccept);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FileLoadOptionsMultipleDialog";
            this.Text = "FileLoadOptionsMultipleDialog";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAccept;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.TextBox tbDatabase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbFirstRowHeader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSeparator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboConnection;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSchema;
        private System.Windows.Forms.Label label2;
    }
}