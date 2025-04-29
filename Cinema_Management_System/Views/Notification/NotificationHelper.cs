using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Views.Notification
{
    public static class NotificationHelper
    {
        public static void AlertBoxInfo(Color backColor,Color color,string title,string text,Image icon)
        {
            NotificationView alertBox = new NotificationView();
            alertBox.BackColor = backColor;
            alertBox.ColorAlertBox = color;
            alertBox.TitleAlertBox = title;
            alertBox.ContentAlertBox = text;
            alertBox.IconAlertBox = icon;
            alertBox.ShowDialog();
        }

        public static void showWarning(string title, string text)
        {
            AlertBoxInfo(Color.LightGoldenrodYellow, Color.Goldenrod, title, text, Properties.Resources.icon_Warning);
        }
    }
}
