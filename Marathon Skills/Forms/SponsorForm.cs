using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class SponsorForm : Form
    {
        public SponsorForm()
        {
            InitializeComponent();

            var time = new DateTime(2016, 11, 24, 6, 0, 0) - DateTime.Now;
            label10.Text = $"{time.Days} дней {time.Hours} часов и {time.Minutes} минут до старта марафона!";

            var con = new SqlConnection(
                @"Server=localhost\SQLEXPRESS;Database=MarathonSkills;Trusted_Connection=True;");
            var adapter = new SqlDataAdapter(@"
select concat(FirstName, ', ', LastName, ' - ', BibNumber, ' (', Runner.CountryCode, ')') as Runner
from Runner
join [User] on Runner.Email = [User].Email
join Registration on Runner.RunnerId = Registration.RunnerId
join RegistrationEvent on Registration.RegistrationId = RegistrationEvent.RegistrationId
            ", con);
            con.Open();
            var set = new DataSet();
            adapter.Fill(set);

            // takes 25 seconds!!!
            comboBox1.DataSource = set.Tables[0];
            comboBox1.ValueMember = "Runner";
        }

        private void Submit(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Поля имя и владелец карты не могут быть пустыми");
                return;
            }

            if (!maskedTextBox1.MaskFull)
            {
                MessageBox.Show("Номер карты должен быть полностью заполнен");
                return;
            }

            if (!maskedTextBox2.MaskFull || !maskedTextBox3.MaskFull || int.Parse(maskedTextBox2.Text) > 12 ||
                new DateTime(int.Parse(maskedTextBox3.Text), int.Parse(maskedTextBox2.Text), 1) < DateTime.Now)
            {
                MessageBox.Show("Месяц и год срока действия должны быть заполнены, а также быть меньше, чем сегодняшняя дата");
                return;
            }

            if (!maskedTextBox4.MaskFull)
            {
                MessageBox.Show("CVC должен содержать 3 цифры");
                return;
            }

            MessageBox.Show("Пожертвование выполнено (нет)");
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            var labelText = label14.Text;
            label14.Text = int.Parse(labelText.Substring(0, labelText.IndexOf('$'))) + 10 + "$";
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            var val = int.Parse(label14.Text.Substring(0, label14.Text.IndexOf('$')));
            if (val > 10)
                label14.Text = val - 10 + "$";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out _))
                label14.Text = textBox1.Text + '$';
        }

        private void Back(object sender, EventArgs e)
        {
            DispatcherForm.OpenForm<MainForm>();
            Close();
        }
    }
}
