using System.Data.SqlClient;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class AddEditCharityForm : Form
    {
        private readonly int _charityId;
        private readonly SqlConnection _con;

        public AddEditCharityForm()
        {
            InitializeComponent();
            Program.LoadTime(label10);
        }

        public AddEditCharityForm(int charityId) : this()
        {
            _charityId = charityId;

            _con = new SqlConnection(Program.ConnectionString);
            _con.Open();
            var cmd = new SqlCommand(
                $"select CharityName, CharityDescription, CharityLogo from Charity where CharityId = {charityId}", _con);
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();

                placeholderTextBox2.Text = reader.GetString(0);
                placeholderTextBox1.Text = reader.GetString(1);
                pictureBox1.ImageLocation = "Images/" + reader.GetString(2);
            }
        }

        private void roundedButton1_Click(object sender, System.EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Images|*.jpg"
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;
            pictureBox1.ImageLocation = dialog.FileName;
            placeholderTextBox6.Text = dialog.SafeFileName;
        }

        private void roundedButton5_Click(object sender, System.EventArgs e)
        {
            Program.GoToForm<ManageChariForm>(this);
        }

        private void roundedButton4_Click(object sender, System.EventArgs e)
        {
            Program.GoToForm<MainForm>(this);
        }

        private void roundedButton2_Click(object sender, System.EventArgs e)
        {
            SqlCommand cmd;
            if (placeholderTextBox6.Text == "charity_logo.jpg")
            {
                cmd = new SqlCommand($@"
update Charity
set CharityName = '{placeholderTextBox2.Text}', CharityDescription = '{placeholderTextBox1.Text}'
where CharityId = {_charityId}
", _con);
            }
            else
            {
                pictureBox1.Image.Save("Images/" + placeholderTextBox6.Text);
                cmd = new SqlCommand($@"
update Charity
set CharityName = '{placeholderTextBox2.Text}', CharityDescription = '{placeholderTextBox1.Text}', CharityLogo = '{placeholderTextBox6.Text}'
where CharityId = {_charityId}
", _con);
            }
            cmd.ExecuteNonQuery();

            Program.GoToForm<ManageChariForm>(this);
        }
    }
}
