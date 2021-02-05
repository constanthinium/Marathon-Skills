using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class SponsorDialog : Form
    {
        public SponsorDialog(string name, string desc, string logo)
        {
            InitializeComponent();

            label1.Text = name;
            textBox1.Text = desc;
            textBox1.Select(0, 0);
            pictureBox1.ImageLocation = "Images/" + logo;
        }
    }
}
