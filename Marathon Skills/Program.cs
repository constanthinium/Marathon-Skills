using System;
using System.Windows.Forms;
using Marathon_Skills.Forms;

namespace Marathon_Skills
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SponsorForm());
        }
    }
}
