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
using static Cinema_Management_System.Views.MovieManagement.MovieManagementView;
using Cinema_Management_System.Views.MessageBox;


namespace Cinema_Management_System.Views.CustomerManagement
{
    public partial class CustomerManagementView : UserControl
    {
        private string _debounceKeyword = "";
        private List<CustomerDTO> _allCustomers = new List<CustomerDTO>();
        private enum SearchType { FullName, PhoneNumber }
        private SearchType _currentSearchType = SearchType.FullName;
        private Timer debounceTimer;
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
            this.BackColor = SystemColors.Control;
        }

        public void LoadCustomerData()
        {
            if (CustomerDA.Instance == null)
            {
                MessageBoxHelper.ShowError("Lỗi", "Không thể truy cập CustomerDA.");
                return;
            }
            _allCustomers = CustomerDA.Instance.GetAllCustomer() ?? new List<CustomerDTO>();
            dgv_customer.DataSource = _allCustomers;
        }

        private void dgv_customer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_customer.Columns[e.ColumnIndex].Name == "Action")
            {
                dgv_customer.ClearSelection();
                dgv_customer.Rows[e.RowIndex].Selected = true;

                string idformat = dgv_customer.Rows[e.RowIndex].Cells["id_col"].Value.ToString();
                int id = CustomerDA.Instance.GetIdFromIdFormat(idformat);
                string fullName = dgv_customer.Rows[e.RowIndex].Cells["Ten_col"].Value.ToString();
                string phone = dgv_customer.Rows[e.RowIndex].Cells["sdt_col"].Value.ToString();
                string email = dgv_customer.Rows[e.RowIndex].Cells["email_col"].Value.ToString();
                DateTime birth = Convert.ToDateTime(dgv_customer.Rows[e.RowIndex].Cells["ngaysinh_col"].Value);
                string gender = dgv_customer.Rows[e.RowIndex].Cells["gioitinh_col"].Value.ToString();

                CustomerDTO selectedCustomer = new CustomerDTO
                {
                    Id = id,
                    FullName = fullName,
                    PhoneNumber = phone,
                    Email = email,
                    Birth = birth,
                    Gender = gender
                };

                ContextMenuStrip menu = CreateContextMenu(selectedCustomer);
                menu.Show(Cursor.Position);
            }
        }

        private ContextMenuStrip CreateContextMenu(CustomerDTO customer)
        {
            ContextMenuStrip menu = new ContextMenuStrip
            {
                Renderer = new CustomMenuRenderer(),
                ShowImageMargin = false,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            menu.Items.Add("✏ Chỉnh sửa", null, (s, e) => EditCustomer(customer));
            menu.Items.Add("🗑 Xóa", null, (s, e) => DeleteCustomer(customer));

            return menu;
        }

        public class CustomMenuRenderer : ToolStripProfessionalRenderer
        {
            public CustomMenuRenderer() : base(new CustomColorTable()) { }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                if (e.Item.Selected)
                {
                    e.TextColor = Color.White;
                }
                else
                {
                    e.TextColor = Color.Black;
                }
                base.OnRenderItemText(e);
            }
        }

        public class CustomColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(203, 45, 62); // Màu khi hover
            public override Color MenuItemBorder => Color.FromArgb(239, 71, 58); // Viền khi hover
            public override Color ToolStripDropDownBackground => Color.White; // Màu nền chính
            public override Color MenuBorder => Color.LightGray; // Viền ngoài của menu
        }

        private void EditCustomer(CustomerDTO customer)
        {
            if (Application.OpenForms["UpdateCustomer"] == null)
            {
                UpdateCustomer updateForm = new UpdateCustomer(customer)
                {
                    Opacity = 0
                }
                ;
                updateForm.Show();

                Timer fadeTimer = new Timer { Interval = 10 };
                fadeTimer.Tick += (s, args) =>
                {
                    if (updateForm.Opacity < 1)
                    {
                        updateForm.Opacity += 0.05;
                    }
                    else
                    {
                        fadeTimer.Stop();
                    }
                };
                fadeTimer.Start();

                updateForm.FormClosed += (s, args) => LoadCustomerData();
            }
            else
            {
                Application.OpenForms["UpdateCustomer"].Activate();
            }
        }

        private void DeleteCustomer(CustomerDTO customer)
        {
            var result = MessageBoxHelper.ShowQuestion("Xác nhận", "Bạn có chắc chắn muốn xóa khách hàng này?");
            if (result == DialogResult.Yes)
            {
                if (CustomerDA.Instance.DeleteCustomer(customer.Id))
                {
                    MessageBoxHelper.ShowSuccess("Thông báo", "Xóa khách hàng thành công!");
                    LoadCustomerData();
                }
            }
        }

        private void xuatEXEL_bnt_Click(object sender, EventArgs e)
        {
            if (dgv_customer.Rows.Count == 0)
            {
                MessageBoxHelper.ShowInfo("Thông báo", "Không có dữ liệu để xuất!");
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

                        MessageBoxHelper.ShowSuccess("Thông báo", "Xuất file Excel thành công!");
                    }
                    catch
                    {
                        MessageBoxHelper.ShowError("Lỗi", "Lỗi khi xuất file");
                    }
                }
            }
        }

        private void Them_bnt_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AddCustomer"] == null)
            {
                AddCustomer addForm = new AddCustomer
                {
                    Opacity = 0 
                };
                addForm.Show();

                Timer fadeTimer = new Timer { Interval = 10 };
                fadeTimer.Tick += (s, args) =>
                {
                    if (addForm.Opacity < 1)
                    {
                        addForm.Opacity += 0.05;
                    }
                    else
                    {
                        fadeTimer.Stop();
                    }
                };
                fadeTimer.Start();

                addForm.FormClosed += (s, args) => LoadCustomerData();
            }
            else
            {
                Application.OpenForms["AddCustomer"].Activate();
            }

        }

        private void InitializeDebounce()
        {
            debounceTimer = new Timer();
            debounceTimer.Interval = 300;
            debounceTimer.Tick += DebounceTimer_Tick;
        }

        private void DebounceTimer_Tick(object sender, EventArgs e)
        {
            debounceTimer.Stop();
            string keyword = _debounceKeyword;
            string searchType = _currentSearchType.ToString();
            var filtered = CustomerDA.Instance.SearchCustomers(keyword, searchType, 10) ?? new List<CustomerDTO>();
            dgv_customer.DataSource = filtered;
        }
    }
}
