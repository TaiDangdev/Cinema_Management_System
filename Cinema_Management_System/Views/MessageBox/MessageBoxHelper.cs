using System.Windows.Forms;

namespace Cinema_Management_System.Views.MessageBox
{
    public static class MessageBoxHelper
    {
        public static void ShowError(string title, string message)
        {
            using (var box = new YesMessage(title, message, MessageBoxType.Error))
            {
                box.ShowDialog();
            }
        }

        public static void ShowWarning(string title, string message)
        {
            using (var box = new YesMessage(title, message, MessageBoxType.Warning))
            {
                box.ShowDialog();
            }
        }

        public static void ShowSuccess(string title, string message)
        {
            using (var box = new YesMessage(title, message, MessageBoxType.Success))
            {
                box.ShowDialog();
            }
        }

        public static DialogResult ShowQuestion(string title, string message)
        {
            using (var box = new YesMessage(title, message, MessageBoxType.Question))
            {
                return box.ShowDialog();
            }
        }

        public static void ShowInfo(string title, string message)
        {
            using (var box = new YesMessage(title, message, MessageBoxType.Info))
            {
                box.ShowDialog();
            }
        }

    }
}
