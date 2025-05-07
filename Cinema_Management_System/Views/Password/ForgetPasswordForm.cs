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
using System.IO;
using Guna.UI2.WinForms;
using Cinema_Management_System.Views.MessageBox;
using Cinema_Management_System.ViewModels;

namespace Cinema_Management_System
{
 
    public partial class ForgetPasswordForm : Form
    {
        private LoginForm _loginForm;

        private ConnectDataContext db = new ConnectDataContext();
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        private int slideIndex = 1;
        private Timer slideTimer;
        private int totalSlides = 9;

        private string generatedOTP;

        private bool isResendMode = false;

        public ForgetPasswordForm(LoginForm loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;
            this.Load += ForgetPasswordForm_Load;
            description_Txt.Text = $"Chúng tôi sẽ gửi mã đặt lại mật \nkhẩu thông qua Email liên kết với \ntài khoản trên ";
            panelCheck.Visible = true;
            panelChangePass.Visible = false;
            panelOTP.Visible = false;
        }

        private void forgetpassword_Txt_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private string GenerateOTP()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999).ToString();
        }

        private void ShowPanel(Control panelToShow)
        {
            panelCheck.Visible = false;
            panelOTP.Visible = false;
            panelChangePass.Visible = false;

            panelToShow.Visible = true;
            panelToShow.BringToFront();
        }



        private string MaskEmail(string email)
        {
            int indexAt = email.IndexOf('@');
            if (indexAt < 3) return "******@*****";

            string first = email.Substring(0, 2);  
            string lastBeforeAt = email.Substring(indexAt - 2, 2); 
            string firstAfterAt = email.Substring(indexAt + 1, 2);  
            string domain = email.Substring(indexAt + 1).Split('.')[0];
            return $"{first}*****{lastBeforeAt}@{firstAfterAt}*******";
        }

        private void ForgetPasswordForm_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => {
                username_Txt.Focus();
            }));
            showMess_label.Visible = false;
            panelCheck.Visible = true;
            panelOTP.Visible = false;
            username_Txt.KeyDown += new KeyEventHandler(OnEnterKeyPressed);
            slideTimer = new Timer();
            slideTimer.Interval = 3000;
            slideTimer.Tick += SlideTimer_Tick;
            slideTimer.Start();

            UpdatePosterImage();
        }

        private void OnEnterKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                confirm_Btn_Click(sender, e); 
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

        private async void back_Btn_Click(object sender, EventArgs e)
        {
            await FadeOutFormAsync(this);
            _loginForm.SetPassword("");
            _loginForm.SetError("");
            _loginForm.Opacity = 0;
            _loginForm.Show();
            await FadeInFormAsync(_loginForm);
        }

        private async Task FadeOutFormAsync(Form form)
        {
            for (double i = 1.0; i >= 0; i -= 0.1)
            {
                form.Opacity = i;
                await Task.Delay(30);
            }
            form.Hide();
            form.Opacity = 1.0;
        }

        private async Task FadeInFormAsync(Form form)
        {
            for (double i = 0; i <= 1.0; i += 0.1)
            {
                form.Opacity = i;
                await Task.Delay(30);
            }
        }

        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            slideIndex++;
            if (slideIndex > totalSlides)
                slideIndex = 1;

            UpdatePosterImage();
        }

        private void UpdatePosterImage()
        {
            try
            {
                string projectRoot = Application.StartupPath;
                string imagePath = Path.Combine(projectRoot, @"..\..\assets\StoryboardMovie", $"{slideIndex}.jpg");
                posterPic.Image = Image.FromFile(Path.GetFullPath(imagePath));
                posterPic.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi load ảnh: " + ex.Message);
            }
        }

        private async void accept_Btn_Click(object sender, EventArgs e)
        {
            string username = username_Txt.Text.Trim();
            if (isResendMode)
            {
                var user = db.STAFFs.Join(db.ACCOUNTs,
                                          staff => staff.Id,
                                          acc => acc.Staff_Id,
                                          (staff, acc) => new { staff, acc })
                                     .Where(u => u.acc.Username == username)
                                     .Select(u => new { u.staff.Email })
                                     .FirstOrDefault();

                if (user != null)
                {
                    generatedOTP = GenerateOTP();
                    error_Txt.Text = "*Mã OTP mới đã được gửi lại!";
                    error_Txt.ForeColor = Color.Green;
                    error_Txt.Visible = true;
                    await SendOtpEmailAsync(user.Email, generatedOTP);
                }
                else
                {
                    MessageBoxHelper.ShowError("Lỗi", "Không tìm thấy người dùng với tên tài khoản này!");
                }

                accept_Btn.Text = "Xác nhận";
                isResendMode = false;
                return;
            }

            string inputOTP = OTP_Txt.Text.Trim();

            if (string.IsNullOrEmpty(inputOTP))
            {
                error_Txt.Text = "*Vui lòng nhập mã OTP!";
                error_Txt.ForeColor = Color.Red;
                error_Txt.Visible = true;             
                return;
            }

            if (inputOTP != generatedOTP)
            {
                error_Txt.Text = "*Mã OTP không chính xác!";
                error_Txt.ForeColor = Color.Red;
                error_Txt.Visible = true;
                return;
            }

            error_Txt.Visible = false;
            user_Txt.Text = username;
            newPassword_Txt.Focus();

            guna2Transition1.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Mosaic;
            guna2Transition1.HideSync(panelOTP);
            ShowPanel(panelChangePass);
            guna2Transition1.ShowSync(panelChangePass);
            panelChangePass.BringToFront();
            this.BeginInvoke(new Action(() => {
                user_Txt.Focus();
            }));
        }

        private async void confirm_Btn_Click(object sender, EventArgs e)
        {
            string username = username_Txt.Text.Trim();

            if (username == "")
            {
                showMess_label.Text = "*Vui lòng nhập tên tài khoản!";
                showMess_label.Visible = true;
                return;
            }

            var user = db.STAFFs.Join(db.ACCOUNTs,
                                      staff => staff.Id,
                                      acc => acc.Staff_Id,
                                      (staff, acc) => new { staff, acc })
                                 .Where(u => u.acc.Username == username)
                                 .Select(u => new { u.staff.Email })
                                 .FirstOrDefault();

            if (user != null)
            {
                generatedOTP = GenerateOTP();

                guna2Transition1.AnimationType = Guna.UI2.AnimatorNS.AnimationType.HorizSlide;
                guna2Transition1.HideSync(panelCheck);
                ShowPanel(panelOTP);
                guna2Transition1.ShowSync(panelOTP);
                panelOTP.BringToFront();
                this.BeginInvoke(new Action(() => {
                    OTP_Txt.Focus();
                }));

                maskedEmail_Txt.Text = $"Mã bảo mật gồm 6 chữ số đã được \ngửi tới Email:\n{MaskEmail(user.Email)}";
                await SendOtpEmailAsync(user.Email, generatedOTP);
            }
            else
            {
                showMess_label.Text = "*Tài khoản không tồn tại!";
                showMess_label.Visible = true;
            }
        }

        private async Task SendOtpEmailAsync(string toEmail, string otp)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("truongnhatnguyen282005@gmail.com", "ltpj zfjw trwt bubn"),
                    EnableSsl = true
                };

                mail.From = new MailAddress("truongnhatnguyen282005@gmail.com");
                mail.To.Add(toEmail);
                mail.Subject = "🔐 Mã xác nhận OTP - StarCinema App";
                mail.Body = $@"
<html>
  <head>
    <style>
      body {{
        font-family: Arial, sans-serif;
        background-color: #f4f4f9;
        margin: 0;
        padding: 0;
      }}
      .container {{
        width: 100%;
        max-width: 600px;
        margin: 0 auto;
        padding: 20px;
        background: #ffffff;
        border-radius: 10px;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
      }}
      .header {{
        text-align: center;
        font-size: 20px;
        color: #333;
        margin-bottom: 15px;
      }}
      .otp-code {{
        font-size: 28px;
        font-weight: bold;
        color: #ffffff;
        background: linear-gradient(to right, rgb(203, 45, 62), rgb(239, 71, 58));
        padding: 15px;
        border-radius: 5px;
        text-align: center;
        margin: 20px auto;
      }}
      .text {{
        font-size: 16px;
        color: #555;
        text-align: center;
        margin: 10px 0;
      }}
      .footer {{
        text-align: center;
        margin-top: 20px;
        color: #777;
        font-size: 14px;
      }}
    </style>
  </head>
  <body>
    <div class='container'>
      <p class='text'>Chúng tôi đã nhận được yêu cầu đặt lại mật khẩu StarCinema App của bạn.</p>

      <div class='header'>
        <h3>Mã xác nhận OTP của bạn là:</h3>
      </div>

      <div class='otp-code'>
        {otp}
      </div>

      <p class='text'>Vui lòng sử dụng mã này để xác nhận khôi phục mật khẩu.</p>
      <p class='text'>Nếu bạn không yêu cầu mật khẩu mới, vui lòng bỏ qua tin nhắn này.</p>

      <div class='footer'>
        <p>Cảm ơn bạn đã sử dụng StarCinema App.</p>
      </div>
    </div>
  </body>
</html>";

                mail.IsBodyHtml = true;

                await smtp.SendMailAsync(mail);
            }
            catch
            {
                MessageBoxHelper.ShowError("Lỗi", "Không thể gửi mã OTP qua email. Vui lòng kiểm tra lại địa chỉ email của bạn.");
            }
        }
        private void notReceived_Label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            YesMessage confirmResend = new YesMessage(
        "Thông báo",
        "Bạn muốn gửi lại mã không? Vui lòng kiểm tra hộp thư rác trước.",
        MessageBoxType.Question
    );
            if (confirmResend.ShowDialog() == DialogResult.Yes)
            {
                isResendMode = true;
                accept_Btn.Text = "Gửi lại mã";
            }
        }

        private void acceptPass_Btn_Click(object sender, EventArgs e)
        {
            string newPassword = newPassword_Txt.Text.Trim();
            string confirmPassword = confirmPass_Txt.Text.Trim();
            string username = username_Txt.Text.Trim();

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                errorPass_Txt.Text = "*Vui lòng nhập đầy đủ thông tin!";
                errorPass_Txt.Visible = true;
                return;
            }

            if (!PasswordHelper.IsValidPassword(newPassword))
            {
                errorPass_Txt.Text = $"*Mật khẩu phải từ 8 ký tự, gồm chữ hoa,\nchữ thường và số!";
                errorPass_Txt.Visible = true;
                return;
            }

            if (newPassword != confirmPassword)
            {
                errorPass_Txt.Text = "*Xác nhận mật khẩu không khớp!";
                errorPass_Txt.Visible = true;
                return;
            }

            try
            {
                var account = db.ACCOUNTs.FirstOrDefault(a => a.Username == username);
                if (account != null)
                {
                    account.Password = PasswordHelper.EncryptSHA256(newPassword);
                    db.SubmitChanges();

                    MessageBoxHelper.ShowSuccess("Thông báo", "Đổi mật khẩu thành công!");
                    this.Close();
                    _loginForm.SetPassword("");
                    _loginForm.SetError("");
                    _loginForm.Show();
                }
                else
                {
                    errorPass_Txt.Text = "*Không tìm thấy tài khoản để cập nhật mật khẩu!";
                    errorPass_Txt.Visible = true;
                }
            }
            catch (Exception ex)
            {
                errorPass_Txt.Text = "*Lỗi khi đổi mật khẩu: " + ex.Message;
                errorPass_Txt.Visible = true;
            }
        }

        private void hidePass_Btn_Click(object sender, EventArgs e)
        {
            if (newPassword_Txt.UseSystemPasswordChar)
            {
                newPassword_Txt.UseSystemPasswordChar = false;
                hidePass_Btn.Image = Properties.Resources.visible;
            }
            else
            {
                newPassword_Txt.UseSystemPasswordChar = true;
                hidePass_Btn.Image = Properties.Resources.eye;
            }
        }

        private void hideConfirmPass_Btn_Click(object sender, EventArgs e)
        {
            if (confirmPass_Txt.UseSystemPasswordChar)
            {
                confirmPass_Txt.UseSystemPasswordChar = false;
                hideConfirmPass_Btn.Image = Properties.Resources.visible;
            }
            else
            {
                confirmPass_Txt.UseSystemPasswordChar = true;
                hideConfirmPass_Btn.Image = Properties.Resources.eye;
            }
        }
    }
}
