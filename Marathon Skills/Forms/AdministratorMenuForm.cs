using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class AdministratorMenuForm : Form
    {
        public AdministratorMenuForm()
        {
            InitializeComponent();
        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            Program.GoToForm<MainForm>(this);
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            Program.GoToForm<UserManagementForm>(this);
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            Program.GoToForm<VoluntererManagementForm>(this);
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            Program.GoToForm<ManageChariForm>(this);
        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            Program.GoToForm<InventoryForm>(this);
        }
    }
}
