using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class MySponsorshipForm : Form
    {
        private readonly int _runnerId;

        public MySponsorshipForm(int runnerId)
        {
            InitializeComponent();

            _runnerId = runnerId;
        }
    }
}
