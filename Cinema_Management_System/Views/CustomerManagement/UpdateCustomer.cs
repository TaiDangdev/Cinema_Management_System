using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.MessageBox;
using Guna.UI2.WinForms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace Cinema_Management_System.Views.CustomerManagement
{
    public partial class UpdateCustomer : Form
    {
        private CustomerDTO currentCustomer;
        private Guna2ShadowForm shadowForm;

        public UpdateCustomer(CustomerDTO customer)
        {
            InitializeComponent();
            SetupUI();
            LoadCustomerData(customer);
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

        private void LoadCustomerData(CustomerDTO customer)
        {
            currentCustomer = customer;
            TenKH_txt.Text = currentCustomer.FullName;
            SDT_txt.Text = currentCustomer.PhoneNumber;
            email_txt.Text = currentCustomer.Email;
            ngaysinh_date.Value = currentCustomer.Birth;
            if (currentCustomer.Gender.ToLower() == "nam")
                radnam.Checked = true;
            else
                radnu.Checked = true;
        }

        

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            ngaysinh_date.MaxDate = DateTime.Now;
        }

        private void SDT_txt_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SDT_txt.Text) || !System.Text.RegularExpressions.Regex.IsMatch(SDT_txt.Text, @"^0\d{9}$"))
            {
                sdt_error.Text = "SĐT phải gồm 10 chữ số và bắt đầu bằng 0!";
                sdt_error.Visible = true;
            }

            else if (System.Text.RegularExpressions.Regex.IsMatch(SDT_txt.Text, @"^0\d{9}$"))
                sdt_error.Visible = false;

        }

        private void TenKH_txt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TenKH_txt.Text))
            {
                tenKH_error.Text = "Vui lòng nhập tên khách hàng!";
                tenKH_error.Visible = true;
            }
            else if
             (!string.IsNullOrWhiteSpace(TenKH_txt.Text))
                tenKH_error.Visible = false;
        }

        private void email_txt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(email_error.Text) || !System.Text.RegularExpressions.Regex.IsMatch(email_txt.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.(com|net|org|edu|gov|vn)$"))
            {
                email_error.Text = "Email không hợp lệ!";
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

        private void huy_bnt_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBoxHelper.ShowQuestion("Thông báo", "Bạn có chắc chắn muốn hủy!");
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void capnhat_bnt_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            // Kiểm tra tên khách hàng
            if (string.IsNullOrWhiteSpace(TenKH_txt.Text))
            {
                tenKH_error.Text = "Vui lòng nhập tên khách hàng!";
                tenKH_error.Visible = true;
                isValid = false;
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(SDT_txt.Text) ||
                !System.Text.RegularExpressions.Regex.IsMatch(SDT_txt.Text, @"^0\d{9}$"))
            {
                sdt_error.Text = "SĐT phải gồm 10 chữ số và bắt đầu bằng 0!";
                sdt_error.Visible = true;
                isValid = false;
            }

            // Kiểm tra email
            if (string.IsNullOrWhiteSpace(email_txt.Text) ||
                !System.Text.RegularExpressions.Regex.IsMatch(email_txt.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.(com|net|org|edu|gov|vn)$"))
            {
                email_error.Text = "Email không hợp lệ!";
                email_error.Visible = true;
                isValid = false;
            }
            // kiểm tra giới tính
            if (!radnam.Checked && !radnu.Checked)
            {

                gioitinh_error.Text = "Vui lòng chọn giới tính!";
                gioitinh_error.Visible = true;
                isValid = false;
            }

            if (!isValid)
                return;

            var newcustomer = new CustomerDTO
            {
                Id = currentCustomer.Id,
                FullName = TenKH_txt.Text.Trim(),
                Gender = radnam.Checked ? "Nam" : "Nữ",
                PhoneNumber = SDT_txt.Text.Trim(),
                Email = email_txt.Text.Trim(),
                Birth = ngaysinh_date.Value
            };


            if (CustomerDA.Instance.UpdateCustomer(newcustomer))
            {
                MessageBoxHelper.ShowSuccess("Thông báo", "Chỉnh sửa thông tin khách hàng thành công!");
                this.Close();
            }
            else
            {
                MessageBoxHelper.ShowError("Lỗi", "Cập nhật thông tin khách hàng không thành công!");
            }
        }
    }
}
