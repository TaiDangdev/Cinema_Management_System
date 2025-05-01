using System;
using System.Drawing;
using System.Windows.Forms;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Models.DAOs;
using Guna.UI2.WinForms;
using Cinema_Management_System.Views.MessageBox;

namespace Cinema_Management_System.Views.CustomerManagement
{
    public partial class AddCustomer : Form
    {
        private Guna2ShadowForm shadowForm;

        public AddCustomer()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            tenKH_error.Visible = false;
            sdt_error.Visible = false;
            email_error.Visible = false;
            gioitinh_error.Visible = false;
            ngaysinh_date.MaxDate = DateTime.Today;
            DragHelper.EnableDrag(this, control_Panel);
            shadowForm = new Guna2ShadowForm
            {
                ShadowColor = Color.Black,
                BorderRadius = 20
            };
            shadowForm.SetShadowForm(this);
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => TenKH_txt.Focus()));
        }

        private void TenKH_txt_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TenKH_txt.Text))
            {
                tenKH_error.Text = "*Vui lòng nhập tên khách hàng!";
                tenKH_error.Visible = true;
            }
            else if
             (!string.IsNullOrWhiteSpace(TenKH_txt.Text))
                tenKH_error.Visible = false;
        }

        private void SDT_txt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SDT_txt.Text) || !System.Text.RegularExpressions.Regex.IsMatch(SDT_txt.Text, @"^0\d{9}$"))
            {
                sdt_error.Text = "*SĐT phải gồm 10 chữ số và bắt đầu bằng 0!";
                sdt_error.Visible = true;
            }

            else if (System.Text.RegularExpressions.Regex.IsMatch(SDT_txt.Text, @"^0\d{9}$"))
                sdt_error.Visible = false;
        }

        private void email_txt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(email_error.Text) || !System.Text.RegularExpressions.Regex.IsMatch(email_txt.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.(com|net|org|edu|gov|vn)$"))
            {
                email_error.Text = "*Email không hợp lệ!";
                email_error.Visible = true;
            }
            else email_error.Visible = false;
        }

        private void Gender_CheckedChanged(object sender, EventArgs e)
        {
            if (radnam.Checked || radnu.Checked)
            {
                gioitinh_error.Visible = false;
            }
        }

        private void xacnhan_bnt_Click_1(object sender, EventArgs e)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(TenKH_txt.Text))
            {
                tenKH_error.Text = "*Vui lòng nhập tên khách hàng!";
                tenKH_error.Visible = true;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(SDT_txt.Text) ||
                !System.Text.RegularExpressions.Regex.IsMatch(SDT_txt.Text, @"^0\d{9}$"))
            {
                sdt_error.Text = "*SĐT phải gồm 10 chữ số và bắt đầu bằng 0!";
                sdt_error.Visible = true;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(email_txt.Text) ||
                !System.Text.RegularExpressions.Regex.IsMatch(email_txt.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.(com|net|org|edu|gov|vn|yahoo)$"))
            {
                email_error.Text = "*Email không hợp lệ!";
                email_error.Visible = true;
                isValid = false;
            }

            if (!radnam.Checked && !radnu.Checked)
            {

                gioitinh_error.Text = "*Vui lòng chọn giới tính!";
                gioitinh_error.Visible = true;
                isValid = false;
            }

            if (!isValid)
                return;

            var customer = new CustomerDTO
            {
                FullName = TenKH_txt.Text.Trim(),
                Gender = radnam.Checked ? "Nam" : "Nữ",
                PhoneNumber = SDT_txt.Text.Trim(),
                Email = email_txt.Text.Trim(),
                Birth = ngaysinh_date.Value,
                RegDate = DateTime.Now,
                Point = 0
            };


            if (CustomerDA.Instance.AddCustomer(customer))
            {
                MessageBoxHelper.ShowSuccess("Thông báo","Thêm khách hàng thành công!");
                this.Close();
            }
        }

        private void HUY_bnt_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBoxHelper.ShowQuestion("Thông báo", "Bạn có chắc chắn muốn hủy?");
            if (result == DialogResult.Yes)
            {
                this.Close();

            }
        }
    }
}
