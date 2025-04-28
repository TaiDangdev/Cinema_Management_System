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
using ClosedXML.Excel;
using System.IO;


namespace Cinema_Management_System.Views.CustomerManagement
{
    public partial class CustomerManagementView : UserControl
    {
        private readonly CustomerDA _customerDA = new CustomerDA();
        private List<CustomerDTO> _allCustomers = new List<CustomerDTO>();
        private enum SearchType { FullName, PhoneNumber }
        private SearchType _currentSearchType = SearchType.FullName;
        private System.Windows.Forms.Timer debounceTimer;
        public CustomerManagementView()
        {
            InitializeComponent();

            dgv_customer.AutoGenerateColumns = false;
            Action.UseColumnTextForButtonValue = true;
            Action.Text = "...";

            canhbao_label.Visible = false;
            dulieutim_txt.TextChanged += dulieutim_txt_TextChanged;
            luachontim_cbb.SelectedIndexChanged += luachontim_cbb_SelectedIndexChanged;
            InitializeDebounce();


        }

        private void dulieutim_txt_TextChanged(object sender, EventArgs e)
        {
            if (luachontim_cbb.SelectedIndex <= 0)
            {
                canhbao_label.Visible = true;
                return;
            }

            canhbao_label.Visible = false;

            string keyword = dulieutim_txt.Text.ToLower();

            _debounceKeyword = dulieutim_txt.Text;
            debounceTimer.Stop();
            debounceTimer.Start();
        }

        private void luachontim_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (luachontim_cbb.SelectedItem?.ToString() == "Tên khách hàng")
                _currentSearchType = SearchType.FullName;
            else if (luachontim_cbb.SelectedItem?.ToString() == "Số điện thoại")
                _currentSearchType = SearchType.PhoneNumber;
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
            if (dgv_customer.Rows.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Lưu file Excel",
                FileName = "DanhSachKhachHang.xlsx"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add("Khách hàng");

                            // Tạo header từ DataGridView
                            for (int i = 0; i < dgv_customer.Columns.Count - 1; i++)
                            {
                                ws.Cell(1, i + 1).Value = dgv_customer.Columns[i].HeaderText;
                            }

                            // Ghi từng dòng dữ liệu
                            for (int i = 0; i < dgv_customer.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgv_customer.Columns.Count - 1; j++)
                                {
                                    ws.Cell(i + 2, j + 1).Value = dgv_customer.Rows[i].Cells[j].Value?.ToString();
                                }
                            }

                            wb.SaveAs(sfd.FileName);
                        }

                        System.Windows.Forms.MessageBox.Show("Xuất file Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_customer.CurrentRow != null)
            {

                var result = System.Windows.Forms.MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string idformat = dgv_customer.CurrentRow.Cells["id_col"].Value.ToString();
                    int id = _customerDA.GetIdFromIdFormat(idformat);
                    if (_customerDA.DeleteCustomer(id))
                    {
                        System.Windows.Forms.MessageBox.Show("Xóa thành công!");
                        LoadCustomerData(); // Gọi lại hàm load danh sách khách hàng
                    }
                }
            }
        }

        // thiết lập debounce
        private string _debounceKeyword = "";
        private void InitializeDebounce()
        {
            debounceTimer = new System.Windows.Forms.Timer();
            debounceTimer.Interval = 300; // 300ms
            debounceTimer.Tick += DebounceTimer_Tick;
        }
        private void DebounceTimer_Tick(object sender, EventArgs e)
        {
            debounceTimer.Stop();
            string keyword = _debounceKeyword;
            string searchType = _currentSearchType.ToString();
            var filtered = _customerDA.SearchCustomers(keyword, searchType, 10);
            dgv_customer.DataSource = filtered;
        }
    }
}
