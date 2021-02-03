using System;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var time = new DateTime(2016, 11, 24, 6, 0, 0) - DateTime.Now;
            label3.Text = $"{time.Days} дней {time.Hours} часов и {time.Minutes} минут до старта марафона!";
        }
    }
}
