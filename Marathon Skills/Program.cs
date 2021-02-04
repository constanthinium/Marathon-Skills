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
            form.Closed += (sender, args) => Forms.Remove(form);
            Forms.Add(form);
            form.Show();

            formToClose?.Close();
        }
    }
}
