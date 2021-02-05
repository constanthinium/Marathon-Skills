using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using Marathon_Skills.Forms;

namespace Marathon_Skills
{
    internal static class Program
    {
        private static readonly ObservableCollection<Form> Forms = new ObservableCollection<Form>();
        public const string ConnectionString = @"Data Source=DESKTOP-Q9DUNC5\SQLEXPRESS;Initial Catalog=MarathonSkills;Integrated Security=True";

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var dispatcherForm = new Form { FormBorderStyle = FormBorderStyle.None, ShowInTaskbar = false };
            dispatcherForm.Load += (sender, args) => dispatcherForm.Size = Size.Empty;
            Forms.CollectionChanged += (sender, args) =>
            {
                if (Forms.Count == 0)
                    Application.Exit();
            };

            MoveToForm<MainForm>(null);

            Application.Run(dispatcherForm);
        }

        public static void MoveToForm<T>(Form formToClose) where T : Form, new()
        {
            var form = new T();
            Forms.Add(form);
            form.Closed += (sender, args) => Forms.Remove(form);
            form.Show();

            formToClose?.Close();
        }

        public static void MoveToForm(Form from, Form to)
        {
            Forms.Add(to);
            to.Closed += (sender, args) => Forms.Remove(to);
            to.Show();
            from.Close();
        }

        public static void LoadTime(Label label)
        {
            var time = new DateTime(2016, 11, 24, 6, 0, 0) - DateTime.Now;
            label.Text = $"{time.Days} дней {time.Hours} часов и {time.Minutes} минут до старта марафона!";
        }
    }
}
