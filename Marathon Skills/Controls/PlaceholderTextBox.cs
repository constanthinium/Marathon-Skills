using System.Drawing;
using System.Windows.Forms;

namespace Marathon_Skills.Controls
{
    internal class PlaceholderTextBox : TextBox
    {
        private string _placeholder;

        public string Placeholder
        {
            get => _placeholder;
            set
            {
                _placeholder = value;
                Text = value;
                ForeColor = Color.Gray;

                GotFocus += (sender, args) =>
                {
                    if (Text != _placeholder) return;
                    Text = "";
                    ForeColor = Color.Black;
                };

                LostFocus += (sender, args) =>
                {
                    if (Text != "") return;
                    Text = _placeholder;
                    ForeColor = Color.Gray;
                };
            }
        }
    }
}