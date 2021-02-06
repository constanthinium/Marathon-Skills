using System;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class AboutMarathonSkillsForm : Form
    {
        public AboutMarathonSkillsForm()
        {
            InitializeComponent();

            Program.LoadTime(label10);
        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            Program.GoToForm<DetailedInformationForm>(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.GoToForm<InteractiveMapForm>(this);
        }
    }
}
