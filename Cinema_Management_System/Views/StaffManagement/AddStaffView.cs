using Cinema_Management_System.Views.MessageBox;
using CsvHelper.Configuration;
using CsvHelper;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using CsvHelper.Configuration.Attributes;
using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.ViewModels;

namespace Cinema_Management_System.Views.StaffManagement
{
    public partial class AddStaffView : Form
    {
        private Bitmap avatarImage;
        private bool isImageSelected = false;
        private Dictionary<Control, Label> errorMap;
        private Guna2ShadowForm shadowForm;

        public AddStaffView()
        {
            InitializeComponent();
            SetupUI();
            InitValidation();
        }

        private void SetupUI()
        {
            startDate_Txt.Value = DateTime.Today;
            birth_Txt.Value = DateTime.Today;
            startDate_Txt.MaxDate = DateTime.Today;
            birth_Txt.MaxDate = DateTime.Today;
            accept_Btn.Enabled = false;
            salary_Txt.Text = "0";
            DragHelper.EnableDrag(this, control_Panel);
            shadowForm = new Guna2ShadowForm
            {
                ShadowColor = Color.Black,
                BorderRadius = 20
            };
            shadowForm.SetShadowForm(this);
        }
        private void InitValidation()
        {
            errorMap = new Dictionary<Control, Label>
            {
                { name_Txt, nameError_Txt },
                { email_Txt, emailError_Txt },
                { phone_Txt, phoneError_Txt },
                { salary_Txt, salaryError_Txt },
                { nameAccount_Txt, nameAccountError_Txt },
                { pass_Txt, passError_Txt },
                { confirmPass_Txt, confirmPassError_Txt }
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
                if (StaffDA.Instance.IsPhoneNumberExists(text))
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

            if (control == pass_Txt)
            {
                if(!PasswordHelper.IsValidPassword(text))
                    return "*Mật khẩu phải từ 8 ký tự,bao gồm \nchữ hoa, chữ thường và số!";
            }

            if (control == confirmPass_Txt)
            {
                if (text != pass_Txt.Text)
                    return "*Mật khẩu xác nhận không khớp!";
            }

            return string.Empty;
        }
        private void CheckAllFieldsValid()
        {
            bool allValid = errorMap.All(entry => string.IsNullOrEmpty(GetErrorMessage(entry.Key)));
            accept_Btn.Enabled = allValid;
        }

        private bool ReadCSV(string filePath)
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    Delimiter = ",",
                    TrimOptions = TrimOptions.Trim,
                    IgnoreBlankLines = true
                };

                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<StaffData>().ToList();
                    if (records.Any())
                    {
                        var staff = records.First();
                        BindStaffToForm(staff);
                        return true;
                    }
                    else
                    {
                        MessageBoxHelper.ShowError("Lỗi", "Dữ liệu trong file không hợp lệ!");
                        return false;
                    }
                }
            }
            catch
            {
                MessageBoxHelper.ShowError("Lỗi", "Lỗi khi đọc file CSV");
                return false;
            }
        }

        private bool ReadExcel(string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rowCount = worksheet.LastRowUsed().RowNumber();

                    if (rowCount < 2)
                    {
                        MessageBoxHelper.ShowError("Lỗi", "File Excel không có dữ liệu để đọc (ít nhất cần 2 dòng).");
                        return false;
                    }

                    string[] formats = { "d/M/yyyy", "dd/MM/yyyy", "M/d/yyyy", "MM/dd/yyyy", "yyyy-MM-dd" };
                    bool hasValidData = false;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        var staff = ExtractStaffFromExcel(worksheet, row);
                        BindStaffToForm(staff);

                        if (!DateTime.TryParseExact(staff.BirthDate, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var birthDate))
                        {
                            MessageBoxHelper.ShowWarning("Cảnh báo", $"Dòng {row}: Ngày sinh không hợp lệ: {staff.BirthDate}");
                        }
                        else
                        {
                            birth_Txt.Value = birthDate;
                            hasValidData = true;
                        }

                        if (!DateTime.TryParseExact(staff.StartDate, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var startDate))
                        {
                            MessageBoxHelper.ShowWarning("Cảnh báo", $"Dòng {row}: Ngày vào làm không hợp lệ: {staff.StartDate}");
                        }
                        else if (startDate > DateTime.Today)
                        {
                            MessageBoxHelper.ShowWarning("Cảnh báo", $"Dòng {row}: Ngày vào làm không được ở tương lai: {staff.StartDate}");
                        }
                        else
                        {
                            startDate_Txt.Value = startDate;
                            hasValidData = true;
                        }
                    }
                    return hasValidData;
                }
            }
            catch
            {
                MessageBoxHelper.ShowError("Lỗi", "Lỗi khi đọc file Excel");
                return false;
            }
        }

        private StaffData ExtractStaffFromExcel(IXLWorksheet worksheet, int row)
        {
            return new StaffData
            {
                FullName = worksheet.Cell(row, 1).GetString(),
                Role = worksheet.Cell(row, 2).GetString(),
                Gender = worksheet.Cell(row, 3).GetString(),
                BirthDate = worksheet.Cell(row, 4).GetString(),
                StartDate = worksheet.Cell(row, 5).GetString(),
                Email = worksheet.Cell(row, 6).GetString(),
                PhoneNumber = worksheet.Cell(row, 7).GetString(),
                Salary = decimal.TryParse(worksheet.Cell(row, 8).GetString(), out var salary) ? salary : 0,
                Username = worksheet.Cell(row, 9).GetString(),
                Password = worksheet.Cell(row, 10).GetString(),
                ConfirmPassword = worksheet.Cell(row, 11).GetString()
            };
        }

        private void BindStaffToForm(StaffData staff)
        {
            name_Txt.Text = staff.FullName;
            role_Txt.Text = staff.Role;
            sex_Txt.Text = staff.Gender;
            email_Txt.Text = staff.Email;
            phone_Txt.Text = staff.PhoneNumber;
            salary_Txt.Text = staff.Salary.ToString("N0");
            nameAccount_Txt.Text = staff.Username;
            pass_Txt.Text = staff.Password;
            confirmPass_Txt.Text = staff.ConfirmPassword;

            string[] formats = { "d/M/yyyy", "dd/MM/yyyy", "M/d/yyyy", "MM/dd/yyyy", "yyyy-MM-dd" };

            if (DateTime.TryParseExact(staff.BirthDate, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var birthDate))
            {
                birth_Txt.Value = birthDate;
            }

            if (DateTime.TryParseExact(staff.StartDate, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var startDate))
            {
                startDate_Txt.Value = startDate;
            }

            CheckAllFieldsValid();
        }

        private void import_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Chọn file dữ liệu",
                Filter = "CSV Files & Excel Files|*.csv;*.xlsx",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                bool success = false;

                if (filePath.EndsWith(".csv"))
                {
                    success = ReadCSV(filePath);
                }
                else if (filePath.EndsWith(".xlsx"))
                {
                    success = ReadExcel(filePath);
                }

                if (success)
                {
                    MessageBoxHelper.ShowSuccess("Thông báo", "Dữ liệu đã được thêm thành công!");
                }
            }
        }

        private StaffDTO GetStaffDTOFromForm()
        {
            return new StaffDTO
            {
                FullName = name_Txt.Text.Trim(),
                Birth = birth_Txt.Value.ToString("dd/MM/yyyy"),
                Gender = sex_Txt.Text,
                Email = email_Txt.Text.Trim(),
                PhoneNumber = phone_Txt.Text.Trim(),
                Salary = int.Parse(salary_Txt.Text.Replace(",", "")),
                Role = role_Txt.Text,
                NgayVaoLam = startDate_Txt.Value.ToString("dd/MM/yyyy"),
                ImageSource = isImageSelected ? avatarImage : null
            };
        }

        private UserDTO GetUserDTOFromForm(int id)
        {
            return new UserDTO
            {
                Username = nameAccount_Txt.Text.Trim(),
                Password = pass_Txt.Text.Trim(),
                Staff_Id = id,
            };
        }

        private void chooseImage_Btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog { Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    avatarImage = new Bitmap(dialog.FileName);
                    avatar_Pic.Image = avatarImage;
                    isImageSelected = true;
                    CheckAllFieldsValid();
                }
            }
        }

        private void AddStaffView_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => name_Txt.Focus()));
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            foreach (var control in errorMap.Keys)
            {
                control.Text = string.Empty;
            }
            startDate_Txt.Value = DateTime.Today;
            birth_Txt.Value = DateTime.Today;
            avatar_Pic.Image = null;
            avatarImage = null;
            isImageSelected = false;
            salary_Txt.Text = "0";
            HideAllErrorLabels();
            accept_Btn.Enabled = false;
            name_Txt.Focus();
        }

        public class StaffData
        {
            [Name("Họ và tên")] public string FullName { get; set; }
            [Name("Chức vụ")] public string Role { get; set; }
            [Name("Giới tính")] public string Gender { get; set; }
            [Name("Ngày sinh")] public string BirthDate { get; set; }
            [Name("Ngày vào làm")] public string StartDate { get; set; }
            [Name("Email")] public string Email { get; set; }
            [Name("Số điện thoại")] public string PhoneNumber { get; set; }
            [Name("Lương")] public decimal Salary { get; set; }
            [Name("Tên tài khoản")] public string Username { get; set; }
            [Name("Mật khẩu")] public string Password { get; set; }
            [Name("Xác nhận mật khẩu")] public string ConfirmPassword { get; set; }
        }

        private void accept_Btn_Click(object sender, EventArgs e)
        {
            var staffDTO = GetStaffDTOFromForm();
            if (StaffDA.Instance.IsPhoneNumberExists(staffDTO.PhoneNumber))
            {
                MessageBoxHelper.ShowError("Lỗi", "Nhân viên đã tồn tại. Vui lòng kiểm tra lại.");
                return;
            }
            int newStaffId = StaffDA.Instance.AddStaff(staffDTO);
            var userDTO = GetUserDTOFromForm(newStaffId);
            UserDA.Instance.AddUser(userDTO.Staff_Id, userDTO.Username, PasswordHelper.EncryptSHA256(userDTO.Password));
            MessageBoxHelper.ShowSuccess("Thông báo", "Thêm nhân viên thành công!");
            this.Close();
        }
    }
}
