using System.Data.SqlClient;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();

            // Миша: Необходимо реализовать всплывающее окно выбора роли при авторизации. См. презентацию при нажатии на кнопку Login.
            // Костя (через 22 часа): Нет, в зависимости от их роли происходит перенаправление на разные формы.
            // Чекай презу, там написано, что это ток для дебага диалог, так что пох

            Program.LoadTime(label10);
        }

        private void roundedButton1_Click(object sender, System.EventArgs e)
        {
            string roleId;

            using (var con = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=MarathonSkills;Trusted_Connection=True;"))
            {
                con.Open();
                roleId = (string)new SqlCommand($"select RoleId from [User] where Email = '{placeholderTextBox1.Text}' and Password = '{placeholderTextBox2.Text}'", con).ExecuteScalar();
            }

            if (roleId != null)
            {
                switch (roleId)
                {
                    case "A":
                        Program.MoveToForm<AdministratorMenuForm>(this);
                        break;
                    case "R":
                        Program.MoveToForm<RunnerMenuForm>(this);
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
