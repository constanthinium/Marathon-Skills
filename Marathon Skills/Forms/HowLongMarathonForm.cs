using System;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class HowLongMarathonForm : Form
    {
        public HowLongMarathonForm()
        {
            InitializeComponent();

            Program.LoadTime(label10);
        }

        // Speed

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label11.Text = label2.Text;
            pictureBox1.Image = pictureBox2.Image;
            label3.Text = GetSpeedDescription(label2.Text, 0.03f);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            label11.Text = label4.Text;
            pictureBox1.Image = pictureBox3.Image;
            label3.Text = GetSpeedDescription(label4.Text, 0.12f);
        }

        private static string GetSpeedDescription(string who, float speed)
        {
            return $"{who} двигается со скоростью {speed} км/ч и завершит марафон за {42 / speed} часов";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            label11.Text = label5.Text;
            pictureBox1.Image = pictureBox4.Image;
            label3.Text = GetSpeedDescription(label5.Text, 35);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            label11.Text = label6.Text;
            pictureBox1.Image = pictureBox5.Image;
            label3.Text = GetSpeedDescription(label6.Text, 80);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            label11.Text = label7.Text;
            pictureBox1.Image = pictureBox6.Image;
            label3.Text = GetSpeedDescription(label7.Text, 345);
        }

        // Distance

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            label11.Text = label14.Text;
            pictureBox1.Image = pictureBox11.Image;
            label3.Text = GetDistanceDescription(label14.Text, 0.245f);
        }

        private static string GetDistanceDescription(string what, float length)
        {
            return $"{what} длиной {length} и может поместиться на длину марафона {(int)(42_000 / length)} раз";
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            label11.Text = label13.Text;
            pictureBox1.Image = pictureBox10.Image;
            label3.Text = GetDistanceDescription(label13.Text, 1.81f);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            label11.Text = label12.Text;
            pictureBox1.Image = pictureBox9.Image;
            label3.Text = GetDistanceDescription(label12.Text, 10f);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            label11.Text = label9.Text;
            pictureBox1.Image = pictureBox8.Image;
            label3.Text = GetDistanceDescription(label9.Text, 73f);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            label11.Text = label8.Text;
            pictureBox1.Image = pictureBox7.Image;
            label3.Text = GetDistanceDescription(label8.Text, 105f);
        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            Program.MoveToForm<DetailedInformationForm>(this);
        }
    }
}
