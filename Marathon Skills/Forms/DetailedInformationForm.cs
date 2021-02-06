using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class DetailedInformationForm : Form
    {
        public DetailedInformationForm()
        {
            InitializeComponent();

            Program.LoadTime(label10);
        }

        private void roundedButton5_Click(object sender, System.EventArgs e)
        {
            Program.MoveToForm<MainForm>(this);
        }

        private void roundedButton1_Click(object sender, System.EventArgs e)
        {
            Program.MoveToForm<AboutMarathonSkillsForm>(this);
        }
    }
}
