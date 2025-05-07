using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using static Cinema_Management_System.AboutAccount_Form;
using Cinema_Management_System.Views;
using System.Threading.Tasks;
using Cinema_Management_System.Views.MessageBox;
using Cinema_Management_System.Views.Notification;
using Cinema_Management_System.Views.StaffForm;
using Cinema_Management_System.ViewModels;
using Cinema_Management_System.Models.DAOs;

namespace Cinema_Management_System
{
    public partial class LoginForm : Form
    {

        private int slideIndex = 1;
        private Timer slideTimer;
        private int totalSlides = 9;

        public LoginForm()
        {
            InitializeComponent();
            DragHelper.EnableDrag(this,this);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            InitializeForm();
            this.BeginInvoke(new Action(() => {
                username_Txt.Focus();
            }));
            StartSlideShow();
            Task.Run(() => UpdateMovieStatusAsync());
        }

        private void InitializeForm()
        {
            password_Txt.UseSystemPasswordChar = true;
            showMess_label.Visible = false;

            username_Txt.KeyDown += OnEnterKeyPressed;
            password_Txt.KeyDown += OnEnterKeyPressed;
        }

        private void StartSlideShow()
        {
            slideTimer = new Timer
            {
                Interval = 3000
            };
            slideTimer.Tick += SlideTimer_Tick;
            slideTimer.Start();

            UpdatePosterImage();
        }

        private async Task UpdateMovieStatusAsync()
        {
            try
            {
                await Task.Run(() =>
                {
                    using (var db = new ConnectDataContext())
                    {
                        db.ExecuteCommand("EXEC [dbo].[sp_UpdateMovieStatus]");
                    }
                });
            }
            catch
            {
                MessageBoxHelper.ShowError("Lỗi","Lỗi cập nhật trạng thái phim");
            }
        }

        private void OnEnterKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                login_Btn_Click(sender, e);
            }
        }

        private async void forgetpassword_Txt_Click(object sender, EventArgs e)
        { 
            await FadeOutFormAsync(this);
            ForgetPasswordForm forgetPasswordForm = new ForgetPasswordForm(this);
            forgetPasswordForm.Opacity = 0;
            forgetPasswordForm.Show();
            await FadeInFormAsync(forgetPasswordForm);
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
            slideIndex = (slideIndex % totalSlides) + 1;
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
            catch
            {
                MessageBoxHelper.ShowError("Lỗi", "Lỗi load ảnh");
            }
        }

        private void login_Btn_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;



            var user = AuthenticateUser(username_Txt.Text.Trim(), password_Txt.Text.Trim());
            if (user != null)
            {
                NavigateToRoleSpecificForm(user.Role, user.Id);
            }
            else
            {
                ShowError("*Tên tài khoản hoặc mật khẩu không đúng!");
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(username_Txt.Text) || string.IsNullOrWhiteSpace(password_Txt.Text))
            {
                ShowError("*Vui lòng điền đầy đủ thông tin đăng nhập!");
                return false;
            }
            return true;
        }

        private dynamic AuthenticateUser(string username, string password)
        {
            password = PasswordHelper.EncryptSHA256(password);
            using (var db = new ConnectDataContext())
            {
                return (from acc in db.ACCOUNTs
                        join staff in db.STAFFs on acc.Staff_Id equals staff.Id
                        where acc.Username == username && acc.Password == password
                        select new { staff.Id, staff.Role }).FirstOrDefault();
            }
        }

        private void NavigateToRoleSpecificForm(string role, int staffId)
        {
            CurrentUser.StaffId = staffId;
            this.Hide();
            if (role == "Quản lý")
            {
                new AdminForm().Show();
            }
            else if (role == "Nhân viên")
            {
                new StaffForm().Show();
            }
        }

        private void ShowError(string message)
        {
            showMess_label.Text = message;
            showMess_label.Visible = true;
        }

        private void hide_Pic_Click(object sender, EventArgs e)
        {
            password_Txt.UseSystemPasswordChar = !password_Txt.UseSystemPasswordChar;
            hide_Pic.Image = password_Txt.UseSystemPasswordChar
                ? Properties.Resources.eye
                : Properties.Resources.visible;
        }

        private void close_Btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void SetPassword(string password)
        {
            password_Txt.Text = password;
        }

        public void SetError(string error)
        {
            showMess_label.Text = error;
        }
    }
}
