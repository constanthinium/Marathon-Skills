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
    public partial class InteractiveMapForm : Form
    {
        public InteractiveMapForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ClearAll();
            label1.Text = "42km Полный марафон";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ClearAll();
            label1.Text = "21km Полу марафон";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ClearAll();
            label1.Text = "5km Fun Run";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ClearAll();
            label1.Text = "1";
            label3.Text = "Avenida Rudge";
            pictureBox13.Image = Properties.Resources.map_icon_drinks;
            label5.Text = "Напитки";
            pictureBox14.Image = Properties.Resources.map_icon_energy_bars;
            label6.Text = "Энергетические батончики";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ClearAll();
            label1.Text = "2";
            label3.Text = "Theatro Municipal";
            pictureBox13.Image = Properties.Resources.map_icon_drinks;
            label5.Text = "Напитки";
            pictureBox14.Image = Properties.Resources.map_icon_energy_bars;
            label6.Text = "Энергетические батончики";
            pictureBox15.Image = Properties.Resources.map_icon_toilets;
            label8.Text = "Туалеты";
            pictureBox16.Image = Properties.Resources.map_icon_information;
            label9.Text = "Информация";
            pictureBox17.Image = Properties.Resources.map_icon_medical;
            label10.Text = "Мед пункт";
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ClearAll();
            label1.Text = "3";
            label3.Text = "Parque do Ibirapuera";
            pictureBox13.Image = Properties.Resources.map_icon_drinks;
            label5.Text = "Напитки";
            pictureBox14.Image = Properties.Resources.map_icon_energy_bars;
            label6.Text = "Энергетические батончики";
            pictureBox15.Image = Properties.Resources.map_icon_toilets;
            label8.Text = "Туалеты";
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ClearAll();
            label1.Text = "4";
            label3.Text = "Jardim Luzitania";
            pictureBox13.Image = Properties.Resources.map_icon_drinks;
            label5.Text = "Напитки";
            pictureBox14.Image = Properties.Resources.map_icon_energy_bars;
            label6.Text = "Энергетические батончики";
            pictureBox15.Image = Properties.Resources.map_icon_toilets;
            label8.Text = "Туалеты";
            pictureBox16.Image = Properties.Resources.map_icon_medical;
            label9.Text = "Мед пункт";
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ClearAll();
            label1.Text = "5";
            label3.Text = "Iguatemi";
            pictureBox13.Image = Properties.Resources.map_icon_drinks;
            label5.Text = "Напитки";
            pictureBox14.Image = Properties.Resources.map_icon_energy_bars;
            label6.Text = "Энергетические батончики";
            pictureBox15.Image = Properties.Resources.map_icon_toilets;
            label8.Text = "Туалеты";
            pictureBox16.Image = Properties.Resources.map_icon_information;
            label9.Text = "Информация";
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            ClearAll();
            label1.Text = "6";
            label3.Text = "Rua Lisboa";
            pictureBox13.Image = Properties.Resources.map_icon_drinks;
            label5.Text = "Напитки";
            pictureBox14.Image = Properties.Resources.map_icon_energy_bars;
            label6.Text = "Энергетические батончики";
            pictureBox15.Image = Properties.Resources.map_icon_toilets;
            label8.Text = "Туалеты";
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            ClearAll();
            label1.Text = "7";
            label3.Text = "Cemitério da Consolação";
            pictureBox13.Image = Properties.Resources.map_icon_drinks;
            label5.Text = "Напитки";
            pictureBox14.Image = Properties.Resources.map_icon_energy_bars;
            label6.Text = "Энергетические батончики";
            pictureBox15.Image = Properties.Resources.map_icon_toilets;
            label8.Text = "Туалеты";
            pictureBox16.Image = Properties.Resources.map_icon_information;
            label9.Text = "Информация";
            pictureBox17.Image = Properties.Resources.map_icon_medical;
            label10.Text = "Мед пункт";
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            ClearAll();
            label1.Text = "8";
            label3.Text = "Cemitério da Consolação";
            pictureBox13.Image = Properties.Resources.map_icon_drinks;
            label5.Text = "Напитки";
            pictureBox14.Image = Properties.Resources.map_icon_energy_bars;
            label6.Text = "Энергетические батончики";
            pictureBox15.Image = Properties.Resources.map_icon_toilets;
            label8.Text = "Туалеты";
            pictureBox16.Image = Properties.Resources.map_icon_information;
            label9.Text = "Информация";
            pictureBox17.Image = Properties.Resources.map_icon_medical;
            label10.Text = "Мед пункт";
        }

        public void ClearAll()
        {
            label1.Text = "";
            label3.Text = "";
            pictureBox13.Image = null;
            label5.Text = "";
            pictureBox14.Image = null;
            label6.Text = "";
            pictureBox15.Image = null;
            label8.Text = "";
            pictureBox16.Image = null;
            label9.Text = "";
            pictureBox17.Image = null;
            label10.Text = "";
        }
    }
}
