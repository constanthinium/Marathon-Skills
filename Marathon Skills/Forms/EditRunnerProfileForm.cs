using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class EditRunnerProfileForm : Form
    {
        private readonly SqlConnection _con = new SqlConnection(Program.ConnectionString);
        private readonly int _runnerId;
        private bool _passwordChanged;

        public EditRunnerProfileForm(int runnerId)
        {
            InitializeComponent();
            _runnerId = runnerId;

            Program.LoadTime(label10);

            _con.Open();

            var adapter = new SqlDataAdapter("select Gender from Gender", _con);
            var set = new DataSet();
            adapter.Fill(set);
            comboBox1.DataSource = set.Tables[0];
            comboBox1.ValueMember = "Gender";

            var adapter2 = new SqlDataAdapter("select CountryName from Country", _con);
            var set2 = new DataSet();
            adapter2.Fill(set2);
            comboBox2.DataSource = set2.Tables[0];
            comboBox2.ValueMember = "CountryName";

            var adapter3 = new SqlDataAdapter("select RegistrationStatusId, RegistrationStatus from RegistrationStatus", _con);
            var set3 = new DataSet();
            adapter3.Fill(set3);
            comboBox3.DataSource = set3.Tables[0];
            comboBox3.DisplayMember = "RegistrationStatus";
            comboBox3.ValueMember = "RegistrationStatusId";

            var cmd = new SqlCommand($@"
select [User].Email, FirstName, LastName, Gender, DateOfBirth, CountryName, RegistrationStatus.RegistrationStatusId, PicturePath
from Runner
left join [User] on [User].Email = Runner.Email
left join Country on Runner.CountryCode = Country.CountryCode
left join Registration on Runner.RunnerId = Registration.RunnerId
left join RegistrationStatus on Registration.RegistrationStatusId = RegistrationStatus.RegistrationStatusId
where Runner.RunnerId = {runnerId}
", _con);
            string path;
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();

                label2.Text = reader.GetString(0);
                placeholderTextBox2.Text = reader.GetString(1);
                placeholderTextBox3.Text = reader.GetString(2);
                comboBox1.SelectedValue = reader.GetString(3);
                dateTimePicker1.Value = reader.GetDateTime(4);
                comboBox2.SelectedValue = reader.GetString(5);
                comboBox3.SelectedValue = !reader.IsDBNull(6) ? reader.GetInt32(6) : 0;
                path = reader.GetString(7);
            }

            placeholderTextBox6.Text = path;
            pictureBox1.ImageLocation = path;
        }

        private void Cancel(object sender, System.EventArgs e)
        {
            Program.MoveToForm<MainForm>(this);
        }

        private void Logout(object sender, System.EventArgs e)
        {
            Program.MoveToForm<MainForm>(this);
        }

        private void Save(object sender, System.EventArgs e)
        {
            if (comboBox3.SelectedValue == null)
            {
                MessageBox.Show("Выберите регистрационный статус");
                return;
            }

            var cmd = new SqlCommand($@"
update [User]
set FirstName = '{placeholderTextBox2.Text}', LastName = '{placeholderTextBox3.Text}'
from [User]
join Runner on [User].Email = Runner.Email
where RunnerId = {_runnerId}

update Runner
set Gender = '{comboBox1.SelectedValue}', DateOfBirth = '{dateTimePicker1.Value}', 
CountryCode = (select CountryCode from Country where CountryName = '{comboBox2.SelectedValue}'),
PicturePath = '{placeholderTextBox6.Text}'
where RunnerId = {_runnerId}

update Registration
set RegistrationStatusId = {comboBox3.SelectedValue}
where RunnerId = {_runnerId}
", _con);
            cmd.ExecuteNonQuery();

            if (_passwordChanged)
            {
                if (placeholderTextBox4.Text == placeholderTextBox1.Text)
                {
                    if (placeholderTextBox2.Text.Length >= 6 &&
                        placeholderTextBox2.Text.Any(c => char.IsUpper(c) || char.IsDigit(c) || char.IsPunctuation(c)))
                    {
                        var cmd2 = new SqlCommand($@"
update [User]
set Password = '{placeholderTextBox4.Text}'
from [User]
join Runner on [User].Email = Runner.Email
where RunnerId = {_runnerId}
", _con);
                        cmd2.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Пароль не содержит всех необходимых символов");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают");
                    return;
                }
            }

            MessageBox.Show("Данные сохранены");
        }

        private void Browse(object sender, System.EventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "Image|*.png" };
            if (dialog.ShowDialog() != DialogResult.OK) return;
            placeholderTextBox6.Text = pictureBox1.ImageLocation = dialog.FileName;
        }

        private void placeholderTextBox4_TextChanged(object sender, System.EventArgs e)
        {
            _passwordChanged = true;
        }
    }
}
