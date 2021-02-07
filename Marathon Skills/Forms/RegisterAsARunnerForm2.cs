using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class RegisterAsARunnerForm2 : Form
    {
        private readonly SqlConnection _con = new SqlConnection(Program.ConnectionString);

        public RegisterAsARunnerForm2()
        {
            InitializeComponent();

            Program.LoadTime(label10);

            _con.Open();

            var adapter = new SqlDataAdapter("select Gender from Gender", _con);
            var table = new DataTable();
            adapter.Fill(table);
            comboBox1.DataSource = table;
            comboBox1.ValueMember = "Gender";

            var adapter2 = new SqlDataAdapter("select CountryName from Country", _con);
            var table2 = new DataTable();
            adapter2.Fill(table2);
            comboBox2.DataSource = table2;
            comboBox2.ValueMember = "CountryName";
        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            Program.GoToForm<RegisterAsARunnerForm>(this);
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            // SignUp

            if (
                placeholderTextBox1.Text == "" ||
                placeholderTextBox2.Text == "" ||
                placeholderTextBox3.Text == "" ||
                placeholderTextBox4.Text == "" ||
                placeholderTextBox5.Text == ""
            )
            {
                MessageBox.Show("Все поля обязательны для заполнения");
                return;
            }
            else if (!ValidateEmail(placeholderTextBox1.Text))
            {
                MessageBox.Show("Неподходящий Email");
                return;
            }
            else if (!(
                placeholderTextBox2.Text.Length >= 6 &&
                placeholderTextBox2.Text.Any(char.IsUpper) &&
                placeholderTextBox2.Text.Any(char.IsDigit) &&
                placeholderTextBox2.Text.Any(char.IsPunctuation)
                ))
            {
                MessageBox.Show("Неподходящий пароль");
                return;
            }
            else if (placeholderTextBox2.Text != placeholderTextBox3.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            else if (dateTimePicker1.Value.AddYears(10) > DateTime.Now)
            {
                MessageBox.Show("Вам должно быть не меньше 10 лет");
                return;
            }

            var command = placeholderTextBox6.Text == "" ? new SqlCommand($@"
insert into [User] (Email, Password, FirstName, LastName, RoleId)
values ('{placeholderTextBox1.Text}', '{placeholderTextBox2.Text}', '{placeholderTextBox4.Text}', '{placeholderTextBox5.Text}', 'R')

insert into Runner (Email, Gender, DateOfBirth, CountryCode, PicturePath)
output inserted.RunnerId
values ('{placeholderTextBox1.Text}', '{comboBox1.SelectedValue}', '{dateTimePicker1.Value}',
(select CountryCode from Country where CountryName = '{comboBox2.SelectedValue}'), null)
            ", _con) : new SqlCommand($@"
insert into [User] (Email, Password, FirstName, LastName, RoleId)
values ('{placeholderTextBox1.Text}', '{placeholderTextBox2.Text}', '{placeholderTextBox4.Text}', '{placeholderTextBox5.Text}', 'R')

insert into Runner (Email, Gender, DateOfBirth, CountryCode, PicturePath)
output inserted.RunnerId
values ('{placeholderTextBox1.Text}', '{comboBox1.SelectedValue}', '{dateTimePicker1.Value}',
(select CountryCode from Country where CountryName = '{comboBox2.SelectedValue}'), '{placeholderTextBox6.Text}')
            ", _con);

            var runnerId = (int)command.ExecuteScalar();

            Program.GoToForm(this, new RegisterForAnEventForm(runnerId));
        }

        private static bool ValidateEmail(string address)
        {
            try
            {
                return new MailAddress(address).Address == address;
            }
            catch
            {
                return false;
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "Image|*.jpg" };
            if (dialog.ShowDialog() != DialogResult.OK) return;
            placeholderTextBox6.Text = pictureBox1.ImageLocation = dialog.FileName;
        }
    }
}
