using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Cinema_Management_System
{
    public partial class ForgetPasswordForm : Form
    {
        private ConnectDataContext db = new ConnectDataContext();
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        public ForgetPasswordForm()
        {
            InitializeComponent();
        }

        private void forgetpassword_Txt_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private string GenerateNewPassword(int length = 8)
        {
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string specialChars = "!@#$%^&*()-_=+";

            if (length < 8) length = 8; // đảm bảo tối thiểu 8 ký tự

            // chọn ngẫu nhiên một ký tự từ mỗi loại
            StringBuilder password = new StringBuilder();
            password.Append(uppercase[GetRandomNumber(uppercase.Length)]);
            password.Append(lowercase[GetRandomNumber(lowercase.Length)]);
            password.Append(digits[GetRandomNumber(digits.Length)]);
            password.Append(specialChars[GetRandomNumber(specialChars.Length)]);

            // bổ sung các ký tự còn lại ngẫu nhiên
            string allChars = uppercase + lowercase + digits + specialChars;
            for (int i = 4; i < length; i++)
            {
                password.Append(allChars[GetRandomNumber(allChars.Length)]);
            }

            // trộn ngẫu nhiên các ký tự để không bị dự đoán dễ dàng
            return new string(password.ToString().ToCharArray().OrderBy(_ => GetRandomNumber(100)).ToArray());
        }

        // hàm tạo số ngẫu nhiên an toàn
        private int GetRandomNumber(int max)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] randomNumber = new byte[4];
                rng.GetBytes(randomNumber);
                return BitConverter.ToInt32(randomNumber, 0) & int.MaxValue % max;
            }
        }

        private void SendNewPasswordEmail(string toEmail, string newPassword)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("truongnhatnguyen282005@gmail.com");
                mail.To.Add(toEmail);
                mail.Subject = "🔐 Yêu cầu đặt lại mật khẩu - Cinema Management System";
                mail.Body = $@"
            <html>
            <body style='font-family: Arial, sans-serif;'>
                <h2 style='color: #2E86C1;'>Khôi phục mật khẩu của bạn</h2>
                <p>Xin chào,</p>
                <p>Bạn đã yêu cầu đặt lại mật khẩu cho tài khoản của mình.</p>
                <p><b>Mật khẩu mới của bạn:</b> <span style='color: #C0392B; font-weight: bold;'>{newPassword}</span></p>
                <p>Vui lòng đăng nhập và đổi mật khẩu ngay để bảo mật tài khoản.</p>
                <hr>
                <p>Nếu bạn không thực hiện yêu cầu này, vui lòng bỏ qua email.</p>
                <p>Trân trọng,</p>
                <p><b>Đội ngũ hỗ trợ - Cinema Management System</b></p>
            </body>
            </html>";
                mail.IsBodyHtml = true; // Cho phép HTML trong email

                smtp.Port = 587;// Cổng 587 được sử dụng để gửi email với STARTTLS.
                smtp.Credentials = new NetworkCredential("truongnhatnguyen282005@gmail.com", "ltpj zfjw trwt bubn");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi gửi email: " + ex.Message);
            }
        }

        private void confirm_Btn_Click_1(object sender, EventArgs e)
        {
            string username = username_Txt.Text.Trim();
            string email = email_Txt.Text.Trim();

            if(username == "" || email == "")
            {
                showMess_label.Text = "*Vui lòng nhập đầy đủ thông tin!";
                showMess_label.Visible = true;
                return;
            }

            var user = db.STAFFs.Join(db.ACCOUNTs, staff => staff.Id ,acc => acc.Staff_Id,(staff,acc)
                => new {staff,acc}).Where(u=> u.acc.Username == username && u.staff.Email==email)
                .Select(u=>new {u.staff.Email,u.acc}).FirstOrDefault();
            if (user != null)
            {
                string newPassword = GenerateNewPassword();
                user.acc.Password = newPassword;
                db.SubmitChanges();
                SendNewPasswordEmail(user.Email, newPassword);
                showMess_label.Text = "*Mật khẩu mới đã được gửi đến email của bạn!";
                showMess_label.Visible = true;
            }
            else
            {
                showMess_label.Text = "*Tên đăng nhập hoặc email không đúng!";
                showMess_label.Visible = true;
            }
        }

        private void ForgetPasswordForm_Load(object sender, EventArgs e)
        {
            showMess_label.Visible = false;
            username_Txt.KeyDown += new KeyEventHandler(OnEnterKeyPressed);
            email_Txt.KeyDown += new KeyEventHandler(OnEnterKeyPressed);
        }

        private void OnEnterKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                confirm_Btn_Click_1(sender, e); 
            }
        }


        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ForgetPasswordForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void ForgetPasswordForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void ForgetPasswordForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y <= 50)
            {
                dragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }
    }
}
