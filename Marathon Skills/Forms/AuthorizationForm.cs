using System.Data.SqlClient;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();

            Program.LoadTime(label10);
        }

        private void roundedButton1_Click(object sender, System.EventArgs e)
        {
            string roleId;

            var con = new SqlConnection(Program.ConnectionString);

            con.Open();
            roleId = (string)new SqlCommand($"select RoleId from [User] where Email = '{placeholderTextBox1.Text}' and Password = '{placeholderTextBox2.Text}'", con).ExecuteScalar();

            if (roleId != null)
            {
                switch (roleId)
                {
                    case "A":
                        Program.MoveToForm<AdministratorMenuForm>(this);
                        break;
                    case "R":
                        var cmd = new SqlCommand($"select RunnerId from Runner where Email = '{placeholderTextBox1.Text}'", con);
                        var runnerId = (int)cmd.ExecuteScalar();
                        Program.MoveToForm(this, new RunnerMenuForm(runnerId));
                        break;
                    case "C":
                        Program.MoveToForm<CoordinatorMenuForm>(this);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Введены неправильные данные");
            }
        }

        private void Back(object sender, System.EventArgs e)
        {
            Program.MoveToForm<MainForm>(this);
        }
    }
}
