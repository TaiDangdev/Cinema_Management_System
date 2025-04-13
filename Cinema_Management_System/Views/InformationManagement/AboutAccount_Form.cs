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

namespace Cinema_Management_System
{
    public partial class AboutAccount_Form : UserControl
    {
        public AboutAccount_Form()
        {
            InitializeComponent();
        }

        public static class CurrentUser
        {
            public static int StaffId {  get; set; }
        }

        private void AboutAccount_Form_Load(object sender, EventArgs e)
        {
            loadUserData();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidatePasswordInput()
        {
            bool isValid = true;

            // Validate Old Password
            if (string.IsNullOrWhiteSpace(oldPass_Txt.Text))
            {
                errorProvider1.SetError(oldPass_Txt, "Old Password is required.");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(oldPass_Txt, string.Empty);
            }

            // Validate New Password
            if (string.IsNullOrWhiteSpace(newPass_Txt.Text))
            {
                errorProvider1.SetError(newPass_Txt, "New Password is required.");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(newPass_Txt, string.Empty);
            }

            // Validate Confirm Password
            if (string.IsNullOrWhiteSpace(confirmPass_Txt.Text))
            {
                errorProvider1.SetError(confirmPass_Txt, "Confirm Password is required.");
                isValid = false;
            }
            else if (newPass_Txt.Text != confirmPass_Txt.Text)
            {
                errorProvider1.SetError(confirmPass_Txt, "Passwords do not match.");
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


                // chuyển đổi ảnh sang mảng byte
                byte[] imageBytes = File.ReadAllBytes(imagePath);

                using (var db = new ConnectDataContext())
                {
                    var user = db.STAFFs.FirstOrDefault(s => s.Id == CurrentUser.StaffId);
                    if (user != null)
                    {
                        user.ImageSource = imageBytes;
                        db.SubmitChanges();
                        //YesMessage msgBox = new YesMessage("Thông báo","Cập nhật ảnh đại diện thành công!");
                        //msgBox.ShowDialog();
                    }
                }
            }
        }

        private void changePass_Btn_Click(object sender, EventArgs e)
        {
            //string oldPassword = oldPass_Txt.Text;  // Giả sử có một TextBox cho mật khẩu cũ
            //string newPassword = newPass_Txt.Text;  // Giả sử có một TextBox cho mật khẩu mới
            //string confirmPassword = confirmPass_Txt.Text;  // Giả sử có một TextBox cho xác nhận mật khẩu mới

            //// Kiểm tra nếu mật khẩu cũ trống
            //if (string.IsNullOrEmpty(oldPassword))
            //{
            //    MessageBox.Show("Mật khẩu cũ không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //// Kiểm tra nếu mật khẩu mới trống
            //if (string.IsNullOrEmpty(newPassword))
            //{
            //    MessageBox.Show("Mật khẩu mới không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //// Kiểm tra nếu mật khẩu xác nhận không trùng với mật khẩu mới
            //if (newPassword != confirmPassword)
            //{
            //    MessageBox.Show("Mật khẩu xác nhận không trùng khớp với mật khẩu mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //// Gọi phương thức đổi mật khẩu trong UserDA
            //bool result = UserDA.ChangePassword(CurrentUser.StaffId, oldPassword, newPassword);

            //if (result)
            //{
            //    MessageBox.Show("Mật khẩu đã được thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Mật khẩu cũ không chính xác hoặc có lỗi xảy ra.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            if (ValidatePasswordInput())
            {
                string oldPassword = oldPass_Txt.Text;
                string newPassword = newPass_Txt.Text;
                string confirmPassword = confirmPass_Txt.Text;

                // Gọi phương thức đổi mật khẩu trong UserDA
                bool result = UserDA.ChangePassword(CurrentUser.StaffId, oldPassword, newPassword);

                if (result)
                {
                    MessageBox.Show("Mật khẩu đã được thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không chính xác hoặc có lỗi xảy ra.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please correct the highlighted errors.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
