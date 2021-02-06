using System;
using System.Windows.Forms;
using Marathon_Skills.Dialogs;

namespace Marathon_Skills.Forms
{
    public partial class RunnerMenuForm : Form
    {
        private readonly int _runnerId;

        public RunnerMenuForm(int runnerId)
        {
            InitializeComponent();

            _runnerId = runnerId;

            Program.LoadTime(label10);
        }

        private void roundedButton6_Click(object sender, EventArgs e)
        {
            new ContactsDialog().ShowDialog();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            Program.GoToForm(this, new RegisterForAnEventForm(_runnerId));
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            Program.GoToForm(this, new MyRaceResultsForm(_runnerId));
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            Program.GoToForm(this, new EditRunnerProfileForm(_runnerId));
        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            Program.GoToForm(this, new MySponsorshipForm(_runnerId));
        }

        private void roundedButton7_Click(object sender, EventArgs e)
        {
            Program.GoToForm<MainForm>(this);
        }
    }
}
