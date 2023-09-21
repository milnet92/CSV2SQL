using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSV2SQL.Core;

namespace CSV2SQL.Forms.Controls
{
    public partial class CustomListBox : ListBox, IObserver<DBConnectionObserverContract>, IObserver<FileTableMetadataObserverContract>
    {
        private List<CustomListBoxItem> notFilteredItems = new List<CustomListBoxItem>();
        public bool IsFiltered { get; private set; }

        public CustomListBox()
        {
            DoubleBuffered = true;
            DrawMode = DrawMode.OwnerDrawVariable;
            IntegralHeight = false;
        }

        public void OnCompleted()
        {
            // No Op
        }

        public void OnError(Exception error)
        {
            // No Op
        }

        public void OnNext(FileTableMetadataObserverContract value)
        {
            var listBox = GetFileListBoxItemFromFileTable(value.FileTable);

            switch (value.NotifyActionType)
            {
                case Enums.NotifyActionType.Add:
                    AddItem(new FileListBoxItem(value.FileTable, FileListBoxItem.FormatDisplayPath(value.FileTable.Path), value.FileTable.TableName));
                    break;
                case Enums.NotifyActionType.Update:
                    if (listBox != null)
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            listBox.Text = value.FileTable.TableName;
                        }));
                    }
                    break;
                case Enums.NotifyActionType.Delete:
                    if (listBox != null)
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            this.Items.Remove(listBox);
                        }));
                    }
                    break;
            }

            this.Invalidate();
        }

        private FileListBoxItem GetFileListBoxItemFromFileTable(FileTable fileTabe)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                FileListBoxItem listBox = (FileListBoxItem)this.Items[i];

                if (listBox.FileTable == fileTabe)
                {
                    return listBox;
                }
            }

            return null;
        }

        public void OnNext(DBConnectionObserverContract value)
        {
            switch (value.NotifyActionType)
            {
                case Enums.NotifyActionType.Add:
                    AddItem(new ConnectionListBoxItem(value.Id, value.DBConnection.Server, value.DBConnection.DataBase));
                    break;
                case Enums.NotifyActionType.Update:
                    {
                        foreach (ConnectionListBoxItem item in this.Items)
                        {
                            if (item.ConnectionId == value.Id)
                            {
                                item.Title = value.DBConnection.Server;
                                item.Text = value.DBConnection.DataBase;
                            }
                        }
                    }
                    break;
                case Enums.NotifyActionType.Delete:
                    {
                        for (int i = 0; i < this.Items.Count; i++)
                        {
                            if (((ConnectionListBoxItem)this.Items[i]).ConnectionId == value.Id)
                            {
                                this.Items.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    break;
            }

            this.Invalidate();
        }

        public bool AddItem(CustomListBoxItem item)
        {
            if (ItemExists(item)) return false;

            this.Invoke(new MethodInvoker(() =>
            {
                this.Items.Add(item);
            }));

            return true;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= 0 && Items.Count > 0)
            {
                CustomListBoxItem item = (CustomListBoxItem)Items[e.Index];

                item.DrawForListBox(this, e);
            }
        }

        private bool ItemExists(CustomListBoxItem item)
        {
            foreach (CustomListBoxItem item1 in this.Items)
            {
                if (item.Key == item1.Key) return true;
            }

            return false;
        }

        public void OrderByTitle()
        {
            List<CustomListBoxItem> items = new List<CustomListBoxItem>();

            foreach (CustomListBoxItem item in this.Items)
                items.Add(item);

            this.Items.Clear();
            foreach (CustomListBoxItem item in items.OrderBy(itm => itm.Title))
            {
                this.Items.Add(item);
            }
        }

        public void FilterByTitle(string title)
        {
            if (!IsFiltered)
            {
                foreach (CustomListBoxItem item in this.Items)
                {
                    notFilteredItems.Add(item);
                }
            }

            this.BeginUpdate();
            this.Items.Clear();

            if (!string.IsNullOrEmpty(title))
            {
                foreach (var itm in notFilteredItems.Where(i => i.Title == title))
                {
                    this.Items.Add(itm);
                }

                IsFiltered = true;
            }
            else
            {
                this.Items.AddRange(notFilteredItems.ToArray());
                notFilteredItems.Clear();
                IsFiltered = false;
            }

            this.EndUpdate();
        }
    }
}
