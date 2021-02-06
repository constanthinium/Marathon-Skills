using System.Windows.Forms;

namespace Marathon_Skills
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(placeholderTextBox1.Text);
        }
    }
}
