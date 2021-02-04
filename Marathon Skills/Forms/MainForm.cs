using System;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Program.LoadTime(label3);
        }

        private void ToSponsor(object sender, EventArgs e)
        {
            Program.MoveToForm<SponsorForm>(this);
        }
    }
}
