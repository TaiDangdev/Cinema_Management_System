using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Runtime.InteropServices;
using static Cinema_Management_System.AboutAccount_Form;

namespace Cinema_Management_System
{
    public partial class LoginForm : Form
    {
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            password_Txt.UseSystemPasswordChar = true;
            showMess_label.Visible = false;
            // bắt sự kiện KeyDown cho ô nhập
            username_Txt.KeyDown += new KeyEventHandler(OnEnterKeyPressed);
            password_Txt.KeyDown += new KeyEventHandler(OnEnterKeyPressed);
        }

        private void OnEnterKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                guna2GradientButton1_Click(sender, e);
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string username = username_Txt.Text.Trim();
            string password = password_Txt.Text.Trim();

            if(username == "" || password == "")
            {
                showMess_label.Text = "*Vui lòng điền đầy đủ thông tin đăng nhập!";
                showMess_label.Visible = true;
                return;
            }

            using(var db = new ConnectDataContext())
            {
                var user = (from acc in db.ACCOUNTs
                            join staff in db.STAFFs on acc.Staff_Id equals staff.Id
                            where acc.Username == username && acc.Password == password
                            select new {staff.Id,staff.Role}).FirstOrDefault();
                if(user != null)
                {
                    CurrentUser.StaffId = user.Id;
                    this.Hide();
                    if(user.Role == "Admin")
                    {
                        AdminForm adminForm = new AdminForm();
                        adminForm.Show();
                    }
                    else if(user.Role == "Staff")
                    {
                        showMess_label.Text = "Chưa làm form Staff";
                        showMess_label.Visible = true;
                    }
                }
                else
                {
                    showMess_label.Text = "*Tên tài khoản hoặc mật khẩu không đúng!";
                    showMess_label.Visible = true;
                }

            }
        }

        private void forgetpassword_Txt_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgetPasswordForm forgetPasswordForm = new ForgetPasswordForm();
            forgetPasswordForm.Show();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            if (password_Txt.UseSystemPasswordChar)
            {
                password_Txt.UseSystemPasswordChar = false;
                guna2PictureBox2.Image = Properties.Resources.visible;
            }
            else
            {
                password_Txt.UseSystemPasswordChar = true;
                guna2PictureBox2.Image = Properties.Resources.eye;
            }
        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y <= 50)
            {
                dragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void LoginForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
