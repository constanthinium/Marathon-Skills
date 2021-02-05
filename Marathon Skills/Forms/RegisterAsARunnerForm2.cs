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
        private readonly SqlConnection _con = new SqlConnection(
            "Server=localhost\\SQLEXPRESS;Database=MarathonSkills;Trusted_Connection=True;");

        private SqlDataAdapter _adapter;
        private DataSet _set;

        public RegisterAsARunnerForm2()
        {
            InitializeComponent();

            Program.LoadTime(label10);

            _con.Open();

            _adapter = new SqlDataAdapter("select Gender from Gender", _con);
            _set = new DataSet();
            _adapter.Fill(_set);
            comboBox1.DataSource = _set.Tables[0];
            comboBox1.ValueMember = "Gender";

            var adapter2 = new SqlDataAdapter("select CountryName from Country", _con);
            var set2 = new DataSet();
            adapter2.Fill(set2);
            comboBox2.DataSource = set2.Tables[0];
            comboBox2.ValueMember = "CountryName";
        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            Program.MoveToForm<RegisterAsARunnerForm>(this);
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
                placeholderTextBox2.Text.Any(c => char.IsUpper(c)) &&
                placeholderTextBox2.Text.Any(c => char.IsDigit(c)) &&
                placeholderTextBox2.Text.Any(c => char.IsPunctuation(c))
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
                MessageBox.Show("Вам должны быть не меньше 10 лет");
                return;
            }

            var command = new SqlCommand($@"
insert into Runner (Email, Gender, DateOfBirth, CountryCode, PicturePath)
values ('{placeholderTextBox1.Text}', '{comboBox1.SelectedValue}', '{dateTimePicker1.Value}',
'{placeholderTextBox2.Text}', {(placeholderTextBox6.Text != "" ? '\'' + placeholderTextBox6.Text + '\'' : null)})

insert into [User] (Email, Password, FirstName, LastName, RoleId)
values ('{placeholderTextBox1.Text}', '{placeholderTextBox2.Text}', '{placeholderTextBox4.Text}', '{placeholderTextBox5.Text}', 'R')
            ", _con);
            command.ExecuteNonQuery();

            Program.MoveToForm<RegisterForAnEventForm>(this);
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
            pictureBox1.ImageLocation = dialog.FileName;
            placeholderTextBox6.Text = dialog.SafeFileName;
        }
    }
}
