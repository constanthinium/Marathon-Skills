using System;
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

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            Program.MoveToForm<MainForm>(this);
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            Program.MoveToForm<AuthorizationForm>(this);
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            Program.MoveToForm<RegisterAsARunnerForm2>(this);
        }
    }
}
