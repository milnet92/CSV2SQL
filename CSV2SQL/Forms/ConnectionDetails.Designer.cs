namespace CSV2SQL.Forms
{
    partial class ConnectionDetails
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbDatabase = new System.Windows.Forms.TextBox();
            this.tbTimeout = new System.Windows.Forms.TextBox();
            this.tbConnectionString = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbStat = new System.Windows.Forms.TextBox();
            this.tbErrorMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Database";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Connection string";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Timeout";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(142, 18);
            this.tbServer.Name = "tbServer";
            this.tbServer.ReadOnly = true;
            this.tbServer.Size = new System.Drawing.Size(213, 20);
            this.tbServer.TabIndex = 4;
            // 
            // tbDatabase
            // 
            this.tbDatabase.Location = new System.Drawing.Point(142, 49);
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.ReadOnly = true;
            this.tbDatabase.Size = new System.Drawing.Size(213, 20);
            this.tbDatabase.TabIndex = 5;
            // 
            // tbTimeout
            // 
            this.tbTimeout.Location = new System.Drawing.Point(142, 80);
            this.tbTimeout.Name = "tbTimeout";
            this.tbTimeout.ReadOnly = true;
            this.tbTimeout.Size = new System.Drawing.Size(66, 20);
            this.tbTimeout.TabIndex = 6;
            // 
            // tbConnectionString
            // 
            this.tbConnectionString.Location = new System.Drawing.Point(142, 116);
            this.tbConnectionString.Name = "tbConnectionString";
            this.tbConnectionString.ReadOnly = true;
            this.tbConnectionString.Size = new System.Drawing.Size(386, 20);
            this.tbConnectionString.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(390, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "State";
            // 
            // tbStat
            // 
            this.tbStat.Location = new System.Drawing.Point(428, 18);
            this.tbStat.Name = "tbStat";
            this.tbStat.ReadOnly = true;
            this.tbStat.Size = new System.Drawing.Size(100, 20);
            this.tbStat.TabIndex = 9;
            // 
            // tbErrorMessage
            // 
            this.tbErrorMessage.Location = new System.Drawing.Point(36, 152);
            this.tbErrorMessage.Multiline = true;
            this.tbErrorMessage.Name = "tbErrorMessage";
            this.tbErrorMessage.ReadOnly = true;
            this.tbErrorMessage.Size = new System.Drawing.Size(492, 68);
            this.tbErrorMessage.TabIndex = 10;
            // 
            // ConnectionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(572, 238);
            this.Controls.Add(this.tbErrorMessage);
            this.Controls.Add(this.tbStat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbConnectionString);
            this.Controls.Add(this.tbTimeout);
            this.Controls.Add(this.tbDatabase);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ConnectionDetails";
            this.Text = "Connection details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.TextBox tbDatabase;
        private System.Windows.Forms.TextBox tbTimeout;
        private System.Windows.Forms.TextBox tbConnectionString;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbStat;
        private System.Windows.Forms.TextBox tbErrorMessage;
    }
}