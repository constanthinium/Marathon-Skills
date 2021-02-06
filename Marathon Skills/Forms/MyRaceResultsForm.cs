using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class MyRaceResultsForm : Form
    {
        private readonly int _runnerId;

        public MyRaceResultsForm(int runnerId)
        {
            _runnerId = runnerId;
            InitializeComponent();

            label5.Text = label6.Text = "";
            Program.LoadTime(label10);

            var con = new SqlConnection(Program.ConnectionString);
            con.Open();
            var cmd = new SqlCommand($@"
select Gender, convert(date, getdate() - DateOfBirth) as DateOfBirth, MarathonName, EventName, left(convert(varchar, cast(dateadd(s, RaceTime, 0) as time)), 8) as RaceTime, BibNumber
from Registration
join Runner on Registration.RunnerId = Runner.RunnerId
join RegistrationEvent on Registration.RegistrationId = RegistrationEvent.RegistrationId
join Event on RegistrationEvent.EventId = Event.EventId
join Marathon on Event.MarathonId = Marathon.MarathonId
where RaceTime is not null and left(convert(varchar, cast(dateadd(s, RaceTime, 0) as time)), 8) != '00:00:00' and Runner.RunnerId = {runnerId}
", con);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                label5.Text = reader.GetString(0);
                label6.Text = GetAgeInterval(DateTime.Now - reader.GetDateTime(1));

                label7.Text = reader.GetString(2);
                label8.Text = reader.GetString(3);
                label9.Text = reader.GetString(4);
                label11.Text = reader.GetInt16(5).ToString();
            }
            else MessageBox.Show("Вы не участвовали в марафонах");
        }

        private static string GetAgeInterval(TimeSpan span)
        {
            var age = span.Days * 365;
            if (age < 18) return "До 18";
            if (age <= 29) return "От 18 до 29";
            if (age <= 39) return "От 30 до 39";
            if (age <= 55) return "От 40 до 55";
            return age <= 70 ? "От 56 до 70" : "Более 70";
        }

        private void BackOk(object sender, EventArgs e)
        {
            Program.MoveToForm(this, new RunnerMenuForm(_runnerId));
        }

        private void Logout(object sender, EventArgs e)
        {
            Program.MoveToForm<MainForm>(this);
        }
    }
}
