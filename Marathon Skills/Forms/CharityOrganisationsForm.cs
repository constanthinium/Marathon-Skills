using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class CharityOrganisationsForm : Form
    {
        public CharityOrganisationsForm()
        {
            InitializeComponent();

            Program.LoadTime(label10);

            panel3.Controls.Clear();

            var con = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=MarathonSkills;Trusted_Connection=True;");
            con.Open();
            var reader = new SqlCommand("select CharityName, CharityDescription, CharityLogo from Charity", con).ExecuteReader();

            var foreColor = Color.FromArgb(80, 80, 80);

            for (var offset = 0; reader.Read(); offset += 250)
            {
                panel3.Controls.Add(new PictureBox
                {
                    Location = new Point(0, offset),
                    AutoSize = true,
                    Image = Image.FromFile("Images/" + reader.GetString(2)),
                    Size = new Size(60, 60),
                    SizeMode = PictureBoxSizeMode.StretchImage
                });

                panel3.Controls.Add(new Label
                {
                    Font = new Font(new FontFamily("Arial"), 14),
                    Text = reader.GetString(0),
                    Location = new Point(65, offset),
                    ForeColor = foreColor,
                    Size = new Size(466,22)
                });

                panel3.Controls.Add(new Label
                {
                    Font = new Font(new FontFamily("Arial"), 10.5f),
                    Text = reader.GetString(1),
                    Location = new Point(65, offset + 28),
                    ForeColor = foreColor,
                    Size = new Size(670, 200)
                });
            }
        }
    }
}
