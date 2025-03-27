using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Management_System.Views.MessageBox
{
    public partial class YesMessage : Form
    {
        public YesMessage(string title,string message)
        {
            InitializeComponent();

            title_txt.Text = title;
            message_Txt.Text = message;

            message_Txt.Left = (this.ClientSize.Width - message_Txt.Width) / 2;
            message_Txt.Top = (this.ClientSize.Height - message_Txt.Height) / 2;

            SystemSounds.Hand.Play();
        }

        private void close_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
