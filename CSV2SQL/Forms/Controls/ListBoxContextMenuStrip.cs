using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV2SQL.Forms.Controls
{
    public class ListBoxContextMenuStrip
    {
        protected int SelectedIndex;

        public ContextMenuStrip NoItemContextMenuStrip { get; set; }
        public ContextMenuStrip ItemContextMenuStrip { get; set; }
        public ListBox ListBox { get; set; }

        public ListBoxContextMenuStrip(ListBox listBox)
        {
            ListBox = listBox;

            ItemContextMenuStrip = new ContextMenuStrip();
            NoItemContextMenuStrip = new ContextMenuStrip();

            ListBox.MouseDown += ListBox_MouseDown;
        }

        protected virtual void UpdateNoItemActions() { }
        protected virtual void UpdateItemActions() { }

        private void ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SelectedIndex = IndexFromPoint(e.Location);

                if (SelectedIndex != -1)
                {
                    ItemContextMenuStrip.Items.Clear();
                    this.UpdateItemActions();
                    ItemContextMenuStrip.Show(ListBox.PointToScreen(e.Location));
                }
                else
                {
                    NoItemContextMenuStrip.Items.Clear();
                    this.UpdateNoItemActions();
                    NoItemContextMenuStrip.Show(ListBox.PointToScreen(e.Location));
                }
            }
        }

        public void AddNoItemAction(string action, EventHandler onClick)
        {
            if (NoItemContextMenuStrip.Items.ContainsKey(action)) return;
            var item = NoItemContextMenuStrip.Items.Add(action);
            item.Click += onClick;
        }

        public ToolStripMenuItem AddSubmenu(string menuName, Bitmap image = null)
        {
            var item = new System.Windows.Forms.ToolStripMenuItem();

            item.Name = menuName;
            item.Text = menuName;

            if (image != null)
                item.Image = image;

            ItemContextMenuStrip.Items.Add(item);

            return item;
        }

        public void AddItemAction(ToolStripMenuItem menu, string action, EventHandler onClick, Bitmap image = null)
        {
            var item = menu.DropDownItems.Add(action);

            if (image != null)
                item.Image = image;

            item.Click += onClick;

        }

        public void AddItemAction(string action, EventHandler onClick, Bitmap image = null)
        {
            var item = ItemContextMenuStrip.Items.Add(action);

            if (image != null)
                item.Image = image;

            item.Click += onClick;
        }

        public void RemoveItemAction(string action)
        {
            if (!ItemContextMenuStrip.Items.ContainsKey(action)) return;
            var item = ItemContextMenuStrip.Items[action];
            ItemContextMenuStrip.Items.Remove(item);
        }

        public void RemoveNoItemAction(string action)
        {
            if (!NoItemContextMenuStrip.Items.ContainsKey(action)) return;
            var item = NoItemContextMenuStrip.Items[action];
            NoItemContextMenuStrip.Items.Remove(item);
        }

        protected int IndexFromPoint(Point e)
        {
            if (ListBox.Items.Count != 0)
            {
                Rectangle rect = ListBox.GetItemRectangle(ListBox.Items.Count - 1);
                if (e.Y < rect.Bottom)
                {
                    return ListBox.IndexFromPoint(e.X, e.Y);
                }
            }
            return -1;
        }

        public CustomListBoxItem GetSelectedItem()
        {
            return (CustomListBoxItem)ListBox.Items[SelectedIndex];
        }
    }
}
