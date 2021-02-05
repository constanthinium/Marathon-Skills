using System;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class RunnerConfirmForm : Form
    {
        public RunnerConfirmForm()
        {
            InitializeComponent();

            Program.LoadTime(label10);
        }

        private void Home(object sender, EventArgs e)
        {
            Program.MoveToForm<MainForm>(this);
        }
    }
}
