using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class RegisterAsARunnerForm : Form
    {
        public RegisterAsARunnerForm()
        {
            InitializeComponent();

            Program.LoadTime(label10);
        }

        private void roundedButton5_Click(object sender, System.EventArgs e)
        {
            Program.MoveToForm<MainForm>(this);
        }
    }
}
