using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class VoluntererManagementForm : Form
    {
        SqlConnection con = new SqlConnection(Program.ConnectionString);

        public VoluntererManagementForm()
        {
            InitializeComponent();

            dataGridView1.Columns.Add("LastName", "Фамилия");
            dataGridView1.Columns.Add("FirstName", "Имя");
            dataGridView1.Columns.Add("CountryName", "Почта");
            dataGridView1.Columns.Add("Gender", "Пол");

            con.Open();
            RefreshGrid("select LastName, FirstName, CountryName, Volunteer.Gender from Volunteer join Country on Volunteer.CountryCode = Country.CountryCode");

            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("select column_name from information_schema.columns where table_name = 'Volunteer'", con);
            DataTable dataTable2 = new DataTable();
            sqlDataAdapter2.Fill(dataTable2);
            dataTable2.Rows[0].Delete();
            dataTable2.Rows.InsertAt(dataTable2.NewRow(), 0);
            comboBox1.DataSource = dataTable2;
            comboBox1.ValueMember = "column_name";
        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            Program.GoToForm<AdministratorMenuForm>(this);
        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            Program.GoToForm<MainForm>(this);
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            Program.GoToForm<ImportVolunteersForm>(this);
        }

        private void RefreshGrid(string comand)
        {
            dataGridView1.Rows.Clear();
            SqlCommand cmd = new SqlCommand(comand, con);
            using (SqlDataReader sqlReader = cmd.ExecuteReader())
            {
                int i = 0;
                for (; sqlReader.Read(); i++)
                {
                    dataGridView1.Rows.Add();

                    dataGridView1[0, i].Value = sqlReader.GetString(0);
                    dataGridView1[1, i].Value = sqlReader.GetString(1);
                    dataGridView1[2, i].Value = sqlReader.GetString(2);
                    dataGridView1[3, i].Value = sqlReader.GetString(3);
                }
                label5.Text = i.ToString();
            }

        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            string command = $"select LastName, FirstName, CountryName, Volunteer.Gender from Volunteer join Country on Volunteer.CountryCode = Country.CountryCode ";
            if (!(comboBox1.SelectedValue is DBNull))
            {
                if (comboBox1.SelectedValue.ToString() == "CountryCode")
                {
                    command += "order by Volunteer.CountryCode";
                }
                else if (comboBox1.SelectedValue.ToString() == "Gender")
                {
                    command += "order by Volunteer.Gender";
                }
                else
                {
                    command += $"order by {comboBox1.SelectedValue}";
                }
            }
            RefreshGrid(command);
        }
    }
}
