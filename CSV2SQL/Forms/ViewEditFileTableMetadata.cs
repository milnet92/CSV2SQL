using CSV2SQL.Core;
using CSV2SQL.Core.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV2SQL.Forms
{
    public partial class ViewEditFileTableMetadata : Form
    {
        private bool executeActions;

        private bool metadataChanged;
        private bool namesChanged;
        public readonly FileTable FileTable;

        public ViewEditFileTableMetadata(FileTable fileTable, bool executeActions)
        {
            this.executeActions = executeActions;
            this.FileTable = fileTable;
            this.Icon = CSV2SQL.Properties.Resources.banana;

            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            // Configure column values
            var column = dgColumns.Columns["dataType"] as DataGridViewComboBoxColumn;
            column.DataSource = FileLoader.GetAvailableTypes();
            column.DisplayMember = "Name";

            this.Text = FileTable.TableName;
            tbPath.Text = FileTable.Path;
            tbTableName.Text = FileTable.TableName;
            tbSchema.Text = FileTable.Schema;

            foreach (var col in FileTable.Columns)
            {
                dgColumns.Rows.Add(col.Name, col.Type.Name, col.Length.ToString());
            }

            // Add eventhandler AFTER initialization
            dgColumns.CellValueChanged += dgColumns_CellValueChanged;
            tbTableName.TextChanged += NamesTextBoxTextChanged;
            tbSchema.TextChanged += NamesTextBoxTextChanged;
        }

        private void dgColumns_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            metadataChanged = true;
        }

        private void btAccept_Click(object sender, EventArgs e)
        {
            FileTableTemplate template = CreateTemlplateFromGrid();

            if (executeActions)
            {
                var result = DialogResult.OK;

                if (metadataChanged)
                {
                    result = MessageBox.Show("Metadata has been modified. Changes REQUIRE to reupload the file. Do you want to continue?",
                        "Metadata edited", MessageBoxButtons.OKCancel);
                }
                else if (namesChanged)
                {
                    result = MessageBox.Show("Metadata has been modified. Changes DO NOT REQUIRE to reupload the file. Do you want to continue?",
                        "Metadata edited", MessageBoxButtons.OKCancel);
                }

                DialogResult = result;

                if (result == DialogResult.OK)
                {
                    if (namesChanged)
                    {
                        FileTableManager.Instance.ModifyTableName(FileTable.Path, FileTable.ConnectionId, tbTableName.Text, tbSchema.Text);
                    }

                    if (metadataChanged)
                    {
                        FileTableManager.Instance.ModifyTemplate(FileTable.Path, FileTable.ConnectionId, template);
                    }
                }

                this.Close();
            }
            else
            {
                FileTable.FromTemplate = true;
                FileTable.Template = template;
            }

            DialogResult = DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private FileTableTemplate CreateTemlplateFromGrid()
        {
            FileTableTemplate template = new FileTableTemplate();

            for (int i = 0; i < dgColumns.Rows.Count; i++)
            {
                var row = dgColumns.Rows[i];
                string typeName = "System." + (string)row.Cells["DataType"].Value;

                FileTableColumn column = new FileTableColumn()
                {
                    Name = (string)row.Cells["ColumnName"].Value,
                    Type = Type.GetType(typeName),
                    Length = Convert.ToInt32(row.Cells["ColumnLength"].Value),
                };

                template.AddColumn(column);
            }

            return template;
        }

        private void NamesTextBoxTextChanged(object sender, EventArgs e)
        {
            namesChanged = true;
        }
    }
}
