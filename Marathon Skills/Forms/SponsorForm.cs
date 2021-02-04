using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class SponsorForm : Form
    {
        private bool _disableLongQueries = false;

        private readonly SqlConnection _con = new SqlConnection(
            @"Server=localhost\SQLEXPRESS;Database=MarathonSkills;Trusted_Connection=True;");

        public SponsorForm()
        {
            InitializeComponent();

            Program.LoadTime(label10);

            if (!_disableLongQueries)
            {
                var adapter = new SqlDataAdapter(@"
select concat(FirstName, ', ', LastName, ' - ', BibNumber, ' (', Runner.CountryCode, ')') as Runner
from Runner
join [User] on Runner.Email = [User].Email
join Registration on Runner.RunnerId = Registration.RunnerId
join RegistrationEvent on Registration.RegistrationId = RegistrationEvent.RegistrationId
            ", _con);
                _con.Open();
                var set = new DataSet();

                // Takes 25 seconds:
                adapter.Fill(set);

                comboBox1.DataSource = set.Tables[0];
                comboBox1.ValueMember = "Runner";
            }
            else
                comboBox1.Items.Add("Ahmad, Adkin - 1518 (IRL)");

            Cursor.Current = Cursors.Arrow;
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

            // TODO: ну что-нибудь надо сюда вставить уж точно
            //new SqlCommand("insert into Sponsorship (SponsorName, RegistrationId, Amount)" +
            //               $"values '{textBox2.Text}', СЮДА-ТО ЧТО БЛЯТЬ ВСТАВЛЯТЬ, '{label14.Text.Substring(0, label14.Text.Length - 1)}'", _con)
            //    .ExecuteNonQuery();

            Program.MoveToForm(this, new SponsorConfirmForm(
                (comboBox1.SelectedValue ?? comboBox1.SelectedItem).ToString(), label12.Text, label14.Text));
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            label14.Text = "$" + (int.Parse(label14.Text.Substring(1)) + 10);
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            var val = int.Parse(label14.Text.Substring(1));
            if (val > 10)
                label14.Text = "$" + (val - 10);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out _))
                label14.Text = textBox1.Text + '$';
        }

        private void Back(object sender, EventArgs e)
        {
            Program.MoveToForm<MainForm>(this);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == '\b');
        }
    }
}
