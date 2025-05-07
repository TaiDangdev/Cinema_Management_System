using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Cinema_Management_System.Views.MessageBox;
using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.ViewModels;

namespace Cinema_Management_System
{
    public partial class AboutAccount_Form : UserControl
    {
        public static string currentRole;
        public static string currentUserName;

        public AboutAccount_Form()
        {
            InitializeComponent();
            this.loadUserData();
        }


        public static class CurrentUser
        {
            public static int StaffId {  get; set; }
            public static string Role { get; set; }

            public static string NameStaff { get; set; }

        }

        private void AboutAccount_Form_Load(object sender, EventArgs e)
        {
            loadUserData();
        }

        public static void getRole()
        {
            try
            {
                using (var db = new ConnectDataContext())
                {
                    var staff = db.STAFFs.FirstOrDefault(s => s.Id == CurrentUser.StaffId);
                    if (staff != null)
                    {
                        CurrentUser.Role = staff.Role;
                        currentRole = staff.Role;
                    }
                }
            }
            catch
            {
                MessageBoxHelper.ShowError("Lỗi","Lỗi tải dữ liệu");
            }

        }

        public static void GetNameStaff()
        {   try 
            {
                using (var db = new ConnectDataContext())
                {
                    var staff = db.STAFFs.FirstOrDefault(s => s.Id == CurrentUser.StaffId);
                    if (staff != null)
                    {
                        currentUserName = staff.FullName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadUserData()
        {
            try
            {
                using (var db = new ConnectDataContext())
                {
                    var staff = db.STAFFs.FirstOrDefault(s => s.Id == CurrentUser.StaffId);
                    if (staff != null)
                    {
                        nameStaff_Txt.Text = staff.FullName;
                        //nameStaff_Txt.MaximumSize = new Size(avatar_Panel.Width - 20, 0); 
                        //nameStaff_Txt.TextAlign = ContentAlignment.MiddleCenter;
                        fullname_txt.Text = staff.FullName;
                        birth_txt.Text = staff.Birth.ToString("dd/MM/yyyy");
                        ngayvaolam_txt.Text = staff.NgayVaoLam.ToString("dd/MM/yyyy");
                        role_txt.Text = staff.Role;
                        gender_txt.Text = staff.Gender;
                        phone_txt.Text = staff.PhoneNumber;
                        salary_txt.Text = staff.Salary.ToString();
                        email_txt.Text = staff.Email;

                        if (staff.ImageSource != null) {
                            using (MemoryStream ms = new MemoryStream(staff.ImageSource.ToArray()))
                            {
                                avatar_pic.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            avatar_pic.Image = Properties.Resources.icons8_person_32;
                        }
                    }

                    nameStaff_Txt.AutoSize = true;
                    nameStaff_Txt.MaximumSize = new Size(avatar_Panel.Width - 20, 0); 
                    nameStaff_Txt.TextAlign = ContentAlignment.TopCenter; 
                    nameStaff_Txt.Location = new Point(
                        (avatar_Panel.Width - nameStaff_Txt.Width) / 2, 
                        nameStaff_Txt.Location.Y 
                    );
                    CurrentUser.Role = staff.Role;
                    currentRole=staff.Role;
                }
            }
            catch
            {
                MessageBoxHelper.ShowError("Lỗi", "Lỗi tải dữ liệu");
            }
        }

        private bool ValidatePasswordInput()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(oldPass_Txt.Text))
            {
                errorProvider1.SetError(oldPass_Txt, "Vui lòng nhập mật khẩu cũ");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(oldPass_Txt, string.Empty);
            }

            if (string.IsNullOrWhiteSpace(newPass_Txt.Text))
            {
                errorProvider1.SetError(newPass_Txt, "Vui lòng nhập mật khẩu mới");
                isValid = false;
            }
            else if(!PasswordHelper.IsValidPassword(newPass_Txt.Text))
            {
                errorProvider1.SetError(newPass_Txt, "Mật khẩu phải từ 8 ký tự,gồm chữ hoa,chữ thường và số");
                isValid = false;
            }    
            else
            {
                errorProvider1.SetError(newPass_Txt, string.Empty);
            }

            if (string.IsNullOrWhiteSpace(confirmPass_Txt.Text))
            {
                errorProvider1.SetError(confirmPass_Txt, "Vui lòng nhập xác nhận mật khẩu");
                isValid = false;
            }
            else if (newPass_Txt.Text != confirmPass_Txt.Text)
            {
                errorProvider1.SetError(confirmPass_Txt, "Mật khẩu không khớp");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(confirmPass_Txt, string.Empty);
            }

            return isValid;
        }


        private void changeAvatar_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                avatar_pic.Image = Image.FromFile(imagePath);


                byte[] imageBytes = File.ReadAllBytes(imagePath);

                using (var db = new ConnectDataContext())
                {
                    var user = db.STAFFs.FirstOrDefault(s => s.Id == CurrentUser.StaffId);
                    if (user != null)
                    {
                        user.ImageSource = imageBytes;
                        db.SubmitChanges();
                        MessageBoxHelper.ShowSuccess("Thông báo", "Cập nhật ảnh đại diện thành công!");
                    }
                }
            }
        }

        private void changePass_Btn_Click(object sender, EventArgs e)
        {
            if (ValidatePasswordInput())
            {
                string oldPassword = PasswordHelper.EncryptSHA256(oldPass_Txt.Text);
                string newPassword = PasswordHelper.EncryptSHA256(newPass_Txt.Text);
                string confirmPassword = confirmPass_Txt.Text;

                bool result = UserDA.ChangePassword(CurrentUser.StaffId, oldPassword, newPassword);

                if (result)
                {
                    MessageBoxHelper.ShowSuccess("Thông báo", "Đổi mật khẩu thành công!");
                    oldPass_Txt.Clear();
                    newPass_Txt.Clear();
                    confirmPass_Txt.Clear();
                }
                else
                {
                    MessageBoxHelper.ShowError("Lỗi", "Mật khẩu cũ không chính xác!");
                }
            }
            else
            {
                MessageBoxHelper.ShowError("Lỗi", "Vui lòng kiểm tra lại thông tin nhập vào!");
            }
        }

        private void hideOldPass_Btn_Click(object sender, EventArgs e)
        {
            if (oldPass_Txt.UseSystemPasswordChar)
            {
                oldPass_Txt.UseSystemPasswordChar = false;
                hideOldPass_Btn.Image = Properties.Resources.visible;
            }
            else
            {
                oldPass_Txt.UseSystemPasswordChar = true;
                hideOldPass_Btn.Image = Properties.Resources.eye;
            }
        }

        private void hidePass_Btn_Click(object sender, EventArgs e)
        {
            if (newPass_Txt.UseSystemPasswordChar)
            {
                newPass_Txt.UseSystemPasswordChar = false;
                hidePass_Btn.Image = Properties.Resources.visible;
            }
            else
            {
                newPass_Txt.UseSystemPasswordChar = true;
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
