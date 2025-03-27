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
                        YesMessage msgBox = new YesMessage("Thông báo","Cập nhật ảnh đại diện thành công!");
                        msgBox.ShowDialog();
                    }
                }
            }
        }
    }
}
