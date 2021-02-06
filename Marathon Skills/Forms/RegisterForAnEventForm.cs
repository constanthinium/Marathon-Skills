using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class RegisterForAnEventForm : Form
    {
        private readonly int _runnerId;

        public RegisterForAnEventForm(int runnerId)
        {
            InitializeComponent();

            _runnerId = runnerId;

            Program.LoadTime(label10);
            label14.Text = "$0";

            var adapter = new SqlDataAdapter("select CharityId, CharityName from Charity", Program.ConnectionString);
            var set = new DataSet();
            adapter.Fill(set);
            comboBox1.DataSource = set.Tables[0];
            comboBox1.DisplayMember = "CharityName";
            comboBox1.ValueMember = "CharityId";
        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            Program.GoToForm<RegisterAsARunnerForm2>(this);
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
            {
                MessageBox.Show("Выберите хотя бы один вид марафона");
                return;
            }
            else if ((placeholderTextBox1.Text != "" ? int.Parse(placeholderTextBox1.Text) : 0) == 0)
            {
                MessageBox.Show("Сумма взноса не может быть нулевой");
                return;
            }
            else if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Выберите комплект");
                return;
            }

            var con = new SqlConnection(Program.ConnectionString);
            con.Open();
            var kit = 'A';

            if (radioButton2.Checked)
                kit = 'B';
            else if (radioButton3.Checked)
                kit = 'C';

            var cmd = new SqlCommand($@"
insert into Registration
(RunnerId, RegistrationDateTime, RaceKitOptionId, RegistrationStatusId, Cost, CharityId, SponsorshipTarget)
values
({_runnerId}, getdate(), '{kit}', 1, {int.Parse(placeholderTextBox1.Text)}, {comboBox1.SelectedValue}, {label14.Text.Substring(1)})
", con);

            cmd.ExecuteNonQuery();

            Program.GoToForm<RunnerConfirmForm>(this);
        }

        private void placeholderTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == '\b');
        }

        private void UpdatePrice(object sender, EventArgs e)
        {
            if (!int.TryParse(placeholderTextBox1.Text, out var result)) return;
            var sum = placeholderTextBox1.Text != "" ? result : 0;

            if (checkBox1.Checked)
                sum += 145;
            if (checkBox2.Checked)
                sum += 75;
            if (checkBox3.Checked)
                sum += 20;

            if (radioButton2.Checked)
                sum += 20;
            else if (radioButton3.Checked)
                sum += 45;

            label14.Text = "$" + sum;
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            Program.GoToForm<MainForm>(this);
        }
    }
}
