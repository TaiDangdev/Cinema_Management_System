using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Management_System.Views.Notification
{
    public partial class NotificationView : Form
    {
        public NotificationView()
        {
            InitializeComponent();
        }

        public Color BackColorAlertBox
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        public Color ColorAlertBox
        {
            get { return panelAlert.BackColor; }
            set { panelAlert.BackColor = titleAlert_Txt.ForeColor = contentAlert_Txt.ForeColor = value; }
        }

        public Image IconAlertBox
        {
            get { return alert_pic.Image; }
            set { alert_pic.Image = value; }
        }

        public string TitleAlertBox
        {
            get { return titleAlert_Txt.Text; }
            set { titleAlert_Txt.Text = value; }
        }

        public string ContentAlertBox
        {
            get { return contentAlert_Txt.Text; }
            set { contentAlert_Txt.Text = value; }
        }

        private void PositionAlertBox()
        {
            int xPos = 0;
            int yPos = 0;
            xPos = Screen.GetWorkingArea(this).Width;
            yPos = Screen.GetWorkingArea(this).Height;
            this.Location = new Point(xPos - this.Width, yPos - this.Height);
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            panelAlert.Width = panelAlert.Width + 5;
            if (panelAlert.Width >= 500)
            {
                timerAnimation.Stop();
                this.Close();
            }
        }

        private void NotificationView_Load(object sender, EventArgs e)
        {
            PositionAlertBox();
            timerAnimation.Start();
        }    
    }
}
