using System.Data.SqlClient;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class ManageARunnerForm : Form
    {
        private readonly int _runnerId;

        public ManageARunnerForm(int runnerId)
        {
            InitializeComponent();

            Program.LoadTime(label10);
            _runnerId = runnerId;

            var con = new SqlConnection(Program.ConnectionString);
            con.Open();
            var cmd = new SqlCommand($@"
select Runner.Email, FirstName, LastName, Gender, cast(DateOfBirth as date), CharityName,
	SponsorshipTarget, RaceKitOptionId, EventName, MarathonName, PicturePath, RegistrationStatusId
from Runner
join [User] on Runner.Email = [User].Email
join Registration on Runner.RunnerId = Registration.RunnerId
join Charity on Registration.CharityId = Charity.CharityId
join RegistrationEvent on Registration.RegistrationId = RegistrationEvent.RegistrationId
join Event on RegistrationEvent.EventId = Event.EventId
join Marathon on Event.MarathonId = Marathon.MarathonId
where Runner.RunnerId = {runnerId}
", con);
            var reader = cmd.ExecuteReader();
            reader.Read();

            label5.Text = reader.GetString(0);
            label3.Text = reader.GetString(1);
            label6.Text = reader.GetString(2);
            label9.Text = reader.GetString(3);
            label12.Text = reader.GetDateTime(4).ToLongDateString();
            label23.Text = reader.GetString(5);
            label17.Text = "$" + reader.GetDecimal(6);
            label21.Text = reader.GetString(7);
            label14.Text = reader.GetString(8) + '\n' + reader.GetString(9);
            if (!reader.IsDBNull(10))
                pictureBox1.ImageLocation = reader.GetString(10);
            var status = reader.GetByte(11);
            switch (status)
            {
                case 1:
                    pictureBox2.Image = Properties.Resources.tick_icon;
                    pictureBox3.Image = Properties.Resources.cross_icon;
                    pictureBox4.Image = Properties.Resources.cross_icon;
                    pictureBox5.Image = Properties.Resources.cross_icon;
                    break;
                case 2:
                    pictureBox2.Image = Properties.Resources.tick_icon;
                    pictureBox3.Image = Properties.Resources.tick_icon;
                    pictureBox4.Image = Properties.Resources.cross_icon;
                    pictureBox5.Image = Properties.Resources.cross_icon;
                    break;
                case 3:
                    pictureBox2.Image = Properties.Resources.tick_icon;
                    pictureBox3.Image = Properties.Resources.tick_icon;
                    pictureBox4.Image = Properties.Resources.tick_icon;
                    pictureBox5.Image = Properties.Resources.cross_icon;
                    break;
                case 4:
                    pictureBox2.Image = Properties.Resources.tick_icon;
                    pictureBox3.Image = Properties.Resources.tick_icon;
                    pictureBox4.Image = Properties.Resources.tick_icon;
                    pictureBox5.Image = Properties.Resources.tick_icon;
                    break;
            }
        }

        private void roundedButton5_Click(object sender, System.EventArgs e)
        {
            Program.GoToForm<RunnerManagementForm>(this);
        }

        private void roundedButton4_Click(object sender, System.EventArgs e)
        {
            Program.GoToForm<MainForm>(this);
        }

        private void roundedButton3_Click(object sender, System.EventArgs e)
        {
            Program.GoToForm<CertificatePreviewForm>(this);
        }

        private void roundedButton2_Click(object sender, System.EventArgs e)
        {
            Program.GoToForm<EditRunnerProfileForm2>(this);
        }
    }
}
