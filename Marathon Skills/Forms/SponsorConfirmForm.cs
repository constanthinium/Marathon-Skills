using System;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class SponsorConfirmForm : Form
    {
        public SponsorConfirmForm(string runner, string fund, string amount)
        {
            InitializeComponent();

            Program.LoadTime(label10);

            label3.Text = runner;
            label13.Text = fund;
            label14.Text = amount;
        }

        private void Back(object sender, EventArgs e)
        {
            Program.GoToForm<SponsorForm>(this);
        }
    }
}
