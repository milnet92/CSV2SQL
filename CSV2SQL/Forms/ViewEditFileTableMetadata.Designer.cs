namespace CSV2SQL.Forms
{
    partial class ViewEditFileTableMetadata
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
            this.tbPath = new System.Windows.Forms.TextBox();
            this.tbTableName = new System.Windows.Forms.TextBox();
            this.dgColumns = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSchema = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btAccept = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Table name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Path";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(140, 27);
            this.tbPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(496, 22);
            this.tbPath.TabIndex = 2;
            // 
            // tbTableName
            // 
            this.tbTableName.Location = new System.Drawing.Point(140, 59);
            this.tbTableName.Margin = new System.Windows.Forms.Padding(4);
            this.tbTableName.Name = "tbTableName";
            this.tbTableName.Size = new System.Drawing.Size(223, 22);
            this.tbTableName.TabIndex = 3;
            // 
            // dgColumns
            // 
            this.dgColumns.AllowUserToAddRows = false;
            this.dgColumns.AllowUserToDeleteRows = false;
            this.dgColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.DataType,
            this.ColumnLength});
            this.dgColumns.Location = new System.Drawing.Point(37, 121);
            this.dgColumns.Margin = new System.Windows.Forms.Padding(4);
            this.dgColumns.Name = "dgColumns";
            this.dgColumns.RowHeadersWidth = 51;
            this.dgColumns.Size = new System.Drawing.Size(600, 311);
            this.dgColumns.TabIndex = 4;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Column name";
            this.ColumnName.MinimumWidth = 6;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 125;
            // 
            // DataType
            // 
            this.DataType.HeaderText = "Data type";
            this.DataType.MinimumWidth = 6;
            this.DataType.Name = "DataType";
            this.DataType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DataType.Width = 125;
            // 
            // ColumnLength
            // 
            this.ColumnLength.HeaderText = "Max. length";
            this.ColumnLength.MinimumWidth = 6;
            this.ColumnLength.Name = "ColumnLength";
            this.ColumnLength.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnLength.Width = 125;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Metadata";
            // 
            // tbSchema
            // 
            this.tbSchema.Location = new System.Drawing.Point(464, 59);
            this.tbSchema.Margin = new System.Windows.Forms.Padding(4);
            this.tbSchema.Name = "tbSchema";
            this.tbSchema.Size = new System.Drawing.Size(172, 22);
            this.tbSchema.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(395, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Schema";
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(537, 453);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(100, 28);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btAccept
            // 
            this.btAccept.Location = new System.Drawing.Point(416, 453);
            this.btAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(100, 28);
            this.btAccept.TabIndex = 9;
            this.btAccept.Text = "Accept";
            this.btAccept.UseVisualStyleBackColor = true;
            this.btAccept.Click += new System.EventHandler(this.btAccept_Click);
            // 
            // ViewEditFileTableMetadata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 498);
            this.Controls.Add(this.dgColumns);
            this.Controls.Add(this.btAccept);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.tbSchema);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTableName);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ViewEditFileTableMetadata";
            this.Text = "ViewFileTableMetadata";
            ((System.ComponentModel.ISupportInitialize)(this.dgColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.DataGridView dgColumns;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSchema;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btAccept;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewComboBoxColumn DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLength;
    }
}