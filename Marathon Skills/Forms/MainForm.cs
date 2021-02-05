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
            if (MessageBox.Show("Загрузка может продлиться до 30 секунд. Продолжить?", "Долгая загрузка",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
            Cursor.Current = Cursors.WaitCursor;
            Program.MoveToForm<SponsorForm>(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.MoveToForm<RegisterAsARunnerForm>(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.MoveToForm<DetailedInformationForm>(this);
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            Program.MoveToForm<AuthorizationForm>(this);
        }
    }
}
