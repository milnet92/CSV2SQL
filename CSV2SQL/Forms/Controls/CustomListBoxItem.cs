using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV2SQL.Forms.Controls
{
    public class CustomListBoxItem
    {
        public string Key 
        { 
            get
            {
                return Title + "-" + Text;
            } 
        }

        public string Title { get; set; }
        public string Text { get; set; }
        public Image Image { get; set; }

        public bool IsSelected;

        public Color ForegroundColor { get; set; } = Color.Black;
        public Color SelectedForegroundColor { get; set; } = Color.White;

        protected Color FontColor { get
            {
                if (IsSelected) return SelectedForegroundColor;
                else return ForegroundColor;
            }
        }

        public CustomListBoxItem(string title, string text, Image image)
        {
            Title = title;
            Text = text;
            Image = image;
        }

        public virtual void DrawForListBox(ListBox listBox, DrawItemEventArgs e)
        {
            Font titleFont = new Font(e.Font.FontFamily, e.Font.Size * 0.7f, FontStyle.Italic);

            e.DrawBackground();

            e.Graphics.DrawImage(this.Image, 2, e.Bounds.Y, listBox.ItemHeight, listBox.ItemHeight);
            var textRect = e.Bounds;

            textRect.Y += 12;
            textRect.X += listBox.ItemHeight + 10;

            Rectangle titleRect = new Rectangle(textRect.X, e.Bounds.Y, textRect.Width, textRect.Height / 2);

            e.DrawFocusRectangle();

            TextRenderer.DrawText(e.Graphics, this.Title, titleFont, titleRect, FontColor, TextFormatFlags.Left);
            TextRenderer.DrawText(e.Graphics, this.Text, e.Font, textRect, FontColor, TextFormatFlags.Left);
        }
    }
}
