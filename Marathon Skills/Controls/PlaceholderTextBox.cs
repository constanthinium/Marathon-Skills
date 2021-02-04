using System.Drawing;
using System.Windows.Forms;

namespace Marathon_Skills.Controls
{
    internal class PlaceholderTextBox : TextBox
    {
        private string _placeholder;

        public new string Text
        {
            get => base.Text == _placeholder ? "" : base.Text;
            set => base.Text = value;
        }

        public string Placeholder
        {
            get => _placeholder;
            set
            {
                _placeholder = value;
                base.Text = value;
                ForeColor = Color.Gray;

                GotFocus += (sender, args) =>
                {
                    if (base.Text != _placeholder) return;
                    base.Text = "";
                    ForeColor = Color.Black;
                };

                LostFocus += (sender, args) =>
                {
                    if (base.Text != "") return;
                    base.Text = _placeholder;
                    ForeColor = Color.Gray;
                };
            }
        }
    }
}
