using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.MessageBox;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Cinema_Management_System.Views.StaffManagement
{
    public partial class EditStaffView : Form
    {
        private Guna2ShadowForm shadowForm;
        private Bitmap avatarImage;
        private Dictionary<Control, Label> errorMap;
        private StaffDTO staff;
        private string staffPhone;
        public EditStaffView(StaffDTO staff)
        {
            InitializeComponent();
            this.staff = staff;
            this.staffPhone = staff.PhoneNumber;
            SetupUI();
            LoadStaffData(staff);
            InitValidation();
        }

        private void SetupUI()
        {
            birth_Txt.Value = DateTime.Today;
            startDate_Txt.Value = DateTime.Today;
            startDate_Txt.MaxDate = DateTime.Today;
            birth_Txt.MaxDate = DateTime.Today;
            DragHelper.EnableDrag(this, control_Panel);
            shadowForm = new Guna2ShadowForm
            {
                ShadowColor = Color.Black,
                BorderRadius = 20
            };
            shadowForm.SetShadowForm(this);
        }

        private void LoadStaffData(StaffDTO staff)
        {
            name_Txt.Text = staff.FullName;
            sex_Txt.Text = staff.Gender;
            if (DateTime.TryParseExact(staff.Birth, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate))
            {
                birth_Txt.Value = birthDate;
            }
            else
            {
                birth_Txt.Value = DateTime.Today;
            }

            if (DateTime.TryParseExact(staff.NgayVaoLam, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedStartDate))
            {
                startDate_Txt.Value = parsedStartDate;
            }
            else
            {
                startDate_Txt.Value = DateTime.Today;
            }
            email_Txt.Text = staff.Email;
            phone_Txt.Text = staff.PhoneNumber;
            salary_Txt.Text = staff.Salary.ToString("N0");
            role_Txt.Text = staff.Role;

            if (staff.ImageSource != null)
            {
                avatar_Pic.Image = staff.ImageSource;
            }
        }

        private void InitValidation()
        {
            errorMap = new Dictionary<Control, Label>
            {
                { name_Txt, nameError_Txt },
                { email_Txt, emailError_Txt },
                { phone_Txt, phoneError_Txt },
                { salary_Txt, salaryError_Txt },
            };

            foreach (var entry in errorMap)
            {
                var control = entry.Key;
                control.TextChanged += (s, e) =>
                {
                    ValidateSingleField(control);
                    CheckAllFieldsValid();
                };

                control.Leave += (s, e) =>
                {
                    ValidateSingleField(control);
                    if (control == salary_Txt && decimal.TryParse(salary_Txt.Text, out var salary) && salary > 0)
                    {
                        salary_Txt.Text = salary.ToString("N0");
                    }
                };
            }

            birth_Txt.ValueChanged += (s, e) =>
            {
                ValidateSingleField(birth_Txt);
                CheckAllFieldsValid();
            };

            startDate_Txt.ValueChanged += (s, e) =>
            {
                ValidateSingleField(startDate_Txt);
                CheckAllFieldsValid();
            };

            HideAllErrorLabels();
        }
        private void HideAllErrorLabels()
        {
            foreach (var entry in errorMap)
            {
                entry.Value.Visible = false;
            }
        }
        private void ClearError(Control control)
        {
            if (errorMap.TryGetValue(control, out Label errorLabel))
            {
                errorLabel.Text = "";
                errorLabel.Visible = false;
            }
        }
        private void ValidateSingleField(Control control)
        {
            string error = GetErrorMessage(control);

            if (errorMap.TryGetValue(control, out Label label))
            {
                if (string.IsNullOrWhiteSpace(control.Text) && control != startDate_Txt && control != birth_Txt)
                {
                    error = "*Không được để trống!";
                }

                if (string.IsNullOrEmpty(error))
                {
                    ClearError(control);
                }
                else
                {
                    label.Text = error;
                    label.Visible = true;
                }
            }
        }

        private string GetErrorMessage(Control control)
        {
            string text = control.Text.Trim();

            if (control != startDate_Txt && control != birth_Txt && string.IsNullOrWhiteSpace(text))
            {
                return "*Không được để trống!";
            }

            if (control == birth_Txt)
            {
                DateTime birthDate = birth_Txt.Value.Date;
                DateTime today = DateTime.Today;
                int age = today.Year - birthDate.Year;
                if (birthDate > today.AddYears(-age)) age--;

                if (age < 16)
                    return "*Nhân viên phải từ 16 tuổi trở lên!";
            }

            if (control == email_Txt)
            {
                if (!text.Contains("@") || !text.Contains("."))
                    return "*Email không hợp lệ!";
            }

            if (control == phone_Txt)
            {
                if (!text.All(char.IsDigit) || text.Length != 10)
                    return "*SĐT phải có đúng 10 chữ số!";
                if (!text.StartsWith("0"))
                    return "*SĐT phải bắt đầu bằng số 0!";
                if (StaffDA.Instance.IsPhoneNumberExists(text) && text!=staffPhone)
                    return "*SĐT đã tồn tại trong hệ thống!";
            }

            if (control == startDate_Txt)
            {
                DateTime startDate = startDate_Txt.Value.Date;
                DateTime today = DateTime.Today;
                if (startDate < today)
                    return "*Ngày vào làm không được ở quá khứ!";
            }

            if (control == salary_Txt)
            {
                if (!decimal.TryParse(text.Replace(",", ""), out decimal salary) || salary < 0)
                    return "*Lương không hợp lệ!";
            }

            return string.Empty;
        }

        private void CheckAllFieldsValid()
        {
            bool allValid = errorMap.All(entry => string.IsNullOrEmpty(GetErrorMessage(entry.Key)));
            accept_Btn.Enabled = allValid;
        }

        private void chooseImage_Btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog { Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    avatarImage = new Bitmap(dialog.FileName);
                    avatar_Pic.Image = avatarImage;
                    CheckAllFieldsValid();
                }
            }
        }

        private void EditStaffView_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => name_Txt.Focus()));
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            LoadStaffData(staff);
            MessageBoxHelper.ShowInfo("Thông báo", "Đã khôi phục dữ liệu thành công");
        }


        private void UpdateStaffFromInput()
        {
            staff.FullName = name_Txt.Text;
            staff.Gender = sex_Txt.Text;
            staff.Birth = birth_Txt.Value.ToString("yyyy-MM-dd");
            staff.Email = email_Txt.Text.Trim();
            staff.PhoneNumber = phone_Txt.Text.Trim();
            staff.NgayVaoLam = startDate_Txt.Value.ToString("yyyy-MM-dd");
            staff.Salary = int.TryParse(salary_Txt.Text.Replace(",", ""), out int salary) ? salary : 0;
            staff.Role = role_Txt.Text.Trim();
            if (avatar_Pic.Image != null)
            {
                staff.ImageSource = new Bitmap(avatar_Pic.Image);
            }
        }


        private void accept_Btn_Click(object sender, EventArgs e)
        {
            UpdateStaffFromInput();

            if (!StaffDA.Instance.IsPhoneNumberExists(staff.PhoneNumber))
            {
                MessageBoxHelper.ShowError("Lỗi", "Số điện thoại đã tồn tại!");
                return;
            }

            DialogResult result = MessageBoxHelper.ShowQuestion("Thông báo", "Bạn có chắc chắn muốn cập nhật thông tin nhân viên này không?");

            if (result != DialogResult.Yes) return;
            StaffDA.Instance.UpdateStaff(staff);
            MessageBoxHelper.ShowInfo("Thông báo", "Cập nhật thông tin nhân viên thành công!");
            this.Close();
        }
    }
}
