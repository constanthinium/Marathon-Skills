using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace Marathon_Skills.Forms
{
    public class DispatcherForm : Form
    {
        private static readonly ObservableCollection<Form> Forms = new ObservableCollection<Form>();

        public DispatcherForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            Load += (sender, args) => Size = Size.Empty;

            Forms.CollectionChanged += (sender, args) =>
            {
                if (Forms.Count == 0)
                    Application.Exit();
            };

            OpenForm<MainForm>();
        }

        public static void OpenForm<T>() where T : Form, new()
        {
            var form = new T();
            form.Closed += (sender, args) => Forms.Remove(form);
            Forms.Add(form);
            form.Show();
        }
    }
}
