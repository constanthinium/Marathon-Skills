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
        }

        private void roundedButton6_Click(object sender, EventArgs e)
        {
            new ContactsDialog().ShowDialog();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            Program.MoveToForm(this, new RegisterForAnEventForm(_runnerId));
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            Program.MoveToForm(this, new MyRaceResultsForm(_runnerId));
        }
    }
}
