using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class ManageChariForm : Form
    {
        public ManageChariForm()
        {
            InitializeComponent();

            Program.LoadTime(label10);

            dataGridView.Columns.Add("CharityName", "Charity Name");
            dataGridView.Columns.Add("CharityDescription", "Charity Description");
            dataGridView.Columns.Add(new DataGridViewImageColumn
            { HeaderText = "Charity Logo", ImageLayout = DataGridViewImageCellLayout.Zoom });
            dataGridView.Columns.Add(new DataGridViewButtonColumn());

            using (var con = new SqlConnection(Program.ConnectionString))
            {
                con.Open();
                var cmd = new SqlCommand("select CharityName, CharityDescription, CharityLogo from Charity", con);
                using (var reader = cmd.ExecuteReader())
                {
                    for (var i = 0; reader.Read(); i++)
                    {
                        dataGridView.Rows.Add();
                        dataGridView.Rows[i].Height = 64;
                        dataGridView[0, i].Value = reader.GetString(0);
                        dataGridView[1, i].Value = reader.GetString(1);
                        dataGridView[2, i].Value = Image.FromFile("Images/" + reader.GetString(2));
                        dataGridView[3, i].Value = "Edit";
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                Program.GoToForm(this, new AddEditCharityForm(e.RowIndex + 1));
            }
        }

        private void roundedButton5_Click(object sender, System.EventArgs e)
        {
            Program.GoToForm<AdministratorMenuForm>(this);
        }

        private void roundedButton1_Click(object sender, System.EventArgs e)
        {
            Program.GoToForm<AddEditCharityForm>(this);
        }
    }
}
