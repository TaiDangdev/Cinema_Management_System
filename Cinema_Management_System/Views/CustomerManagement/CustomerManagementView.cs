using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.ViewModels.CustomerManagement;
using TheArtOfDevHtmlRenderer.Adapters;
using Guna.UI2.WinForms;

namespace Cinema_Management_System.Views.CustomerManagement
{
    public partial class CustomerManagementView : UserControl
    {
        private readonly CustomerDA _customerDA = new CustomerDA();
        private List<CustomerDTO> _allCustomers = new List<CustomerDTO>();
        private enum SearchType { FullName, PhoneNumber }
        private SearchType _currentSearchType = SearchType.FullName;
        public CustomerManagementView()
        {
            InitializeComponent();

            dgv_customer.AutoGenerateColumns = false;
            Action.UseColumnTextForButtonValue = true;
            Action.Text = "...";

            canhbao_label.Visible = false;
            dulieutim_txt.TextChanged += dulieutim_txt_TextChanged;
            luachontim_cbb.SelectedIndexChanged += luachontim_cbb_SelectedIndexChanged;


        }

        private void dulieutim_txt_TextChanged(object sender, EventArgs e)
        {
            if (luachontim_cbb.SelectedIndex <= 0)
            {
                canhbao_label.Visible = true;
                return;
            }
            
            canhbao_label.Visible=false;

            string keyword = dulieutim_txt.Text.ToLower();

            var filtered = _allCustomers.Where(c =>
              (_currentSearchType == SearchType.FullName && c.FullName.ToLower().Contains(keyword)) ||
              (_currentSearchType == SearchType.PhoneNumber && c.PhoneNumber.Contains(keyword))
                ).ToList();

            dgv_customer.DataSource = filtered;
        }

        private void luachontim_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (luachontim_cbb.SelectedItem?.ToString() == "Tên khách hàng")
                _currentSearchType = SearchType.FullName;
            else if (luachontim_cbb.SelectedItem?.ToString() == "Số điện thoại")
                _currentSearchType= SearchType.PhoneNumber;
        }

        public void CustomerManagementView_Load(object sender, EventArgs e)
        {
            LoadCustomerData();
            dulieutim_txt.Focus();
        }

        private void LoadCustomerData()
        {
            try
            {
                _allCustomers = _customerDA.GetAllCustomer();
                dgv_customer.DataSource = _allCustomers;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message);
            }
        }



        private void dgv_customer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_customer.Columns[e.ColumnIndex].Name == "Action")
            {
                // Lưu thông tin hàng được chọn (tuỳ bạn dùng SelectedCustomer hay lưu index)
                dgv_customer.ClearSelection();
                dgv_customer.Rows[e.RowIndex].Selected = true;

                // Hiển thị menu tại vị trí con trỏ chuột
                var mousePos = dgv_customer.PointToClient(Cursor.Position);
                chucnang_menu.Show(dgv_customer, mousePos);
            }
        }

        private void xuatEXEL_bnt_Click(object sender, EventArgs e)
        {

        }

        private void Them_bnt_Click(object sender, EventArgs e)
        {
            var Addform = new AddCustomer();
            Addform.ShowDialog();
            LoadCustomerData();
        }

        private void chỉnhSửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_customer.CurrentRow != null)
            {
                // Lấy dữ liệu từ dòng đang chọn
                string idformat = dgv_customer.CurrentRow.Cells["id_col"].Value.ToString();
                int id = _customerDA.GetIdFromIdFormat(idformat);
                string fullName = dgv_customer.CurrentRow.Cells["Ten_col"].Value.ToString();
                string phone = dgv_customer.CurrentRow.Cells["sdt_col"].Value.ToString();
                string email = dgv_customer.CurrentRow.Cells["email_col"].Value.ToString();
                DateTime birth = Convert.ToDateTime(dgv_customer.CurrentRow.Cells["ngaysinh_col"].Value);
                string gender = dgv_customer.CurrentRow.Cells["gioitinh_col"].Value.ToString();

                // Tạo DTO
                CustomerDTO selectedCustomer = new CustomerDTO()
                {
                    Id = id,
                    FullName = fullName,
                    PhoneNumber = phone,
                    Email = email,
                    Birth = birth,
                    Gender = gender,
                };
                //System.Windows.Forms.MessageBox.Show("id là " +id);

                // Truyền DTO vào form UpdateCustomer
                UpdateCustomer updateForm = new UpdateCustomer(selectedCustomer);
                updateForm.ShowDialog();
                LoadCustomerData();
            }
        }
    }
}
