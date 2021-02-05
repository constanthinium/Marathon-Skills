using System;
using System.Windows.Forms;
using Marathon_Skills.Dialogs;

namespace Marathon_Skills.Forms
{
    public partial class RunnerMenuForm : Form
    {
        public RunnerMenuForm()
        {
            InitializeComponent();
        }

        private void roundedButton6_Click(object sender, EventArgs e)
        {
            new ContactsDialog().ShowDialog();
        }
    }
}
