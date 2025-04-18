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
using TheArtOfDevHtmlRenderer.Adapters;

namespace Cinema_Management_System.Views.CustomerManagement
{
    public partial class UpdateCustomer : Form
    {
        private CustomerDA _customerDA = new CustomerDA();
        private CustomerDTO currentCustomer;
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        public UpdateCustomer(CustomerDTO customer)
        {
            InitializeComponent();
            currentCustomer = customer;
            TenKH_txt.Text = currentCustomer.FullName;
            SDT_txt.Text = currentCustomer.PhoneNumber;
            email_txt.Text = currentCustomer.Email;
            ngaysinh_date.Value = currentCustomer.Birth;
            if (currentCustomer.Gender.ToLower() == "nam")
                radnam.Checked = true;
            else if (currentCustomer.Gender.ToLower() == "nữ")
                radnu.Checked = true;
            else
                radkhac.Checked = true;
            tenKH_error.Visible = false;
            sdt_error.Visible = false;
            email_error.Visible = false;
        }

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            ngaysinh_date.MaxDate = DateTime.Now;

        }


        private void huy_bnt_Click(object sender, EventArgs e)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Bạn có chắc chắn muốn hủy!",
                                                    "Thông báo",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();

            }
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
            if (string.IsNullOrEmpty(email_error.Text) || !System.Text.RegularExpressions.Regex.IsMatch(email_txt.Text, @"^[\w\.-]+@[\w\.-]+\.\w{1,8}$"))
            {
                email_error.Text = "Email không hợp lệ!";
                email_error.Visible = true;
            }
            else email_error.Visible = false;
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
                !System.Text.RegularExpressions.Regex.IsMatch(email_txt.Text, @"^[\w\.-]+@[\w\.-]+\.\w{2,4}$"))
            {
                email_error.Text = "Email không hợp lệ!";
                email_error.Visible = true;
                isValid = false;
            }
             // kiểm tra giới tính
            if (!radnam.Checked && !radnu.Checked && !radkhac.Checked)
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
                Gender = radnam.Checked ? "Nam" : radnu.Checked ? "Nữ" : "Khác",
                PhoneNumber = SDT_txt.Text.Trim(),
                Email = email_txt.Text.Trim(),
                Birth = ngaysinh_date.Value
            };


            if (_customerDA.UpdateCustomer(newcustomer))
            {
                System.Windows.Forms.MessageBox.Show("Chỉnh sửa thông tin khách hàng thành công!",
                                                        "Thông báo",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Chỉnh sửa thông tin khách hàng thất bại.");
            }

        }
        private void Gender_CheckedChanged(object sender, EventArgs e)
        {
            if (radnam.Checked || radnu.Checked || radkhac.Checked)
            {
                gioitinh_error.Visible = false;
            }
        }
    }
}
