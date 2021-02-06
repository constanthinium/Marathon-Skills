using System;
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
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
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

            currentBMI = Convert.ToDouble(placeholderTextBox2.Text) / (Convert.ToDouble(placeholderTextBox1.Text) * Convert.ToDouble(placeholderTextBox1.Text));

            if (currentBMI < 18.5)
            {
                pictureBox1.Image = Properties.Resources.bmi_underweight_icon;
            }
            else if (currentBMI > 18.5 && currentBMI < 24.9)
            {
                pictureBox1.Image = Properties.Resources.bmi_healthy_icon;
            }
            else if (currentBMI > 25 && currentBMI < 29.9)
            {
                pictureBox1.Image = Properties.Resources.bmi_overweight_icon;
            }
            else if (currentBMI > 30)
            {
                pictureBox1.Image = Properties.Resources.bmi_obese_icon;
            }
        }
    }
}
