using System;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class SponsorConfirmForm : Form
    {
        public SponsorConfirmForm()
        {
            InitializeComponent();

            Program.LoadTime(label10);
        }

        private void Back(object sender, EventArgs e)
        {
            Program.MoveToForm<SponsorForm>(this);
        }
    }
}
