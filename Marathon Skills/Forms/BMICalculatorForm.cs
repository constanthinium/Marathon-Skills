using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class BMICalculatorForm : Form
    {
        string currentGender = null;
        double currentBMI = 0;

        public BMICalculatorForm()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.BorderStyle = BorderStyle.Fixed3D;
            pictureBox3.BorderStyle = BorderStyle.None;
            currentGender = "male";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox4.BorderStyle = BorderStyle.Fixed3D;
            pictureBox3.BorderStyle = BorderStyle.None;
            currentGender = "female";
        }

        private void placeholderTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void placeholderTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            Program.GoToForm<DetailedInformationForm>(this);
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            Program.GoToForm<DetailedInformationForm>(this);
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            if (currentGender == null)
            {
                MessageBox.Show("Выберете свой пол");
                return;
            }
            else if (placeholderTextBox1 == null)
            {
                MessageBox.Show("Впишите свой рост");
                return;
            }
            else if (placeholderTextBox2 == null)
            {
                MessageBox.Show("Впишите свой вес");
                return;
            }

            if (currentGender == "male")
            {
                currentBMI = 
                label14.Text = currentBMR.ToString();
                label13.Text = (currentBMR * 1.2).ToString();
                label17.Text = (currentBMR * 1.375).ToString();
                label19.Text = (currentBMR * 1.55).ToString();
                label21.Text = (currentBMR * 1.725).ToString();
                label23.Text = (currentBMR * 1.9).ToString();
            }
            else if (currentGender == "female")
            {
                currentBMR = 655 + (9.6 * Convert.ToDouble(placeholderTextBox2.Text)) + (1.8 * Convert.ToDouble(placeholderTextBox1.Text)) - (4.7 * Convert.ToDouble(placeholderTextBox3.Text));
                label14.Text = currentBMR.ToString();
                label13.Text = (currentBMR * 1.2).ToString();
                label17.Text = (currentBMR * 1.375).ToString();
                label19.Text = (currentBMR * 1.55).ToString();
                label21.Text = (currentBMR * 1.725).ToString();
                label23.Text = (currentBMR * 1.9).ToString();
            }
        }
    }
}
