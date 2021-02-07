using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class AddEditCharityForm : Form
    {
        private readonly int _charityId;

        public AddEditCharityForm()
        {
            InitializeComponent();
        }

        public AddEditCharityForm(int charityId) : this()
        {
            _charityId = charityId;
        }
    }
}
