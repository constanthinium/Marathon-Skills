using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class UserManagementForm : Form
    {
        SqlConnection con = new SqlConnection(Program.ConnectionString);

        public UserManagementForm()
        {
            InitializeComponent();

            dataGridView1.Columns.Add("FirstName", "Имя");
            dataGridView1.Columns.Add("LastName", "Фамилия");
            dataGridView1.Columns.Add("Email", "Почта");
            dataGridView1.Columns.Add("RoleName", "Роль");
            dataGridView1.Columns.Add(new DataGridViewButtonColumn());

            con.Open();
            RefreshGrid("select FirstName, LastName, Email, RoleName from [User] join Role on [User].RoleId = [Role].RoleId");

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select RoleId, RoleName from Role", con);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
            comboBox1.DataSource = dataTable;
            comboBox1.ValueMember = "RoleId";
            comboBox1.DisplayMember = "RoleName";

            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("select column_name from information_schema.columns where table_name = 'User'", con);
            DataTable dataTable2 = new DataTable();
            sqlDataAdapter2.Fill(dataTable2);
            dataTable2.Rows[1].Delete();
            dataTable2.Rows.InsertAt(dataTable2.NewRow(),0);
            comboBox2.DataSource = dataTable2;
            comboBox2.ValueMember = "column_name";
        }

        private void roundedButton2_Click(object sender, System.EventArgs e)
        {
            Program.GoToForm<AddANewUserForm>(this);
        }

        private void roundedButton1_Click(object sender, System.EventArgs e)
        {
            string command = $"select FirstName, LastName, Email, RoleName from [User] join Role on [User].RoleId = [Role].RoleId ";
            if (!(comboBox1.SelectedValue is DBNull))
            {
                command += $"where [User].RoleId = '{comboBox1.SelectedValue}' ";
            }
            if (textBox1.Text != "")
            {
                if (command.Contains("where"))
                {
                    command += $"and (Email like '%{textBox1.Text}%' or FirstName like '%{textBox1.Text}%' or LastName like '%{textBox1.Text}%') ";
                }
                else
                {
                    command += $"where Email like '%{textBox1.Text}%' or FirstName like '%{textBox1.Text}%' or LastName like '%{textBox1.Text}%' ";
                }
            }
            if (!(comboBox2.SelectedValue is DBNull))
            {
                if (comboBox2.SelectedValue.ToString() == "RoleId")
                {
                    command += "order by [User].RoleId";
                }
                else
                {
                    command += $"order by {comboBox2.SelectedValue}";
                }
            }
            RefreshGrid(command);
        }

        private void roundedButton4_Click(object sender, System.EventArgs e)
        {
            Program.GoToForm<MainForm>(this);
        }

        private void roundedButton5_Click(object sender, System.EventArgs e)
        {
            Program.GoToForm<AdministratorMenuForm>(this);
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
                    dataGridView1[4, i].Value = "Edit";
                }
                label4.Text = i.ToString();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                Program.GoToForm(this, new EditAUserForm(dataGridView1[2, e.RowIndex].Value.ToString()));
            }
            
        }
    }
}
