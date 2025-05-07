using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.MessageBox;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cinema_Management_System.Views.StaffManagement
{
    public partial class StaffManagementView : UserControl
    {
        private string _debounceKeyword = "";
        private enum SearchType { FullName, PhoneNumber }
        private SearchType _currentSearchType = SearchType.FullName;
        private Timer debounceTimer;
        public StaffManagementView()
        {
            InitializeComponent();
            SetupUI();
            InitializeDebounce();
        }

        private void SetupUI()
        {
            dgv_staff.AutoGenerateColumns = false;
            more_Btn.UseColumnTextForButtonValue = true;
            more_Btn.Text = "...";
            canhbao_label.Visible = false;
        }

        private void LoadStaffData()
        {
            if (StaffDA.Instance == null)
            {
                MessageBoxHelper.ShowError("Lỗi", "Không thể truy cập CustomerDA.");
                return;
            }
            var staffList = StaffDA.Instance.GetAllStaff() ?? new List<StaffDTO>();
            dgv_staff.DataSource = staffList;
        }


        private void Them_bnt_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AddStaffView"] == null)
            {
                AddStaffView addForm = new AddStaffView
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

                addForm.FormClosed += (s, args) => LoadStaffData();
            }
            else
            {
                Application.OpenForms["AddStaffView"].Activate();
            }
        }

        private void StaffManagementView_Load(object sender, EventArgs e)
        {
            LoadStaffData();
            this.BeginInvoke(new Action(() => dulieutim_txt.Focus()));
        }

        private void dgv_staff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_staff.Columns[e.ColumnIndex].Name == "more_Btn")
            {
                dgv_staff.ClearSelection();
                dgv_staff.Rows[e.RowIndex].Selected = true;

                string idFormat = dgv_staff.Rows[e.RowIndex].Cells["id_col"].Value.ToString();
                int id = StaffDA.Instance.GetIdFromIdFormat(idFormat); // Cần có phương thức này trong StaffDA
                string fullName = dgv_staff.Rows[e.RowIndex].Cells["Ten_col"].Value.ToString();
                string gender = dgv_staff.Rows[e.RowIndex].Cells["gioitinh_col"].Value.ToString();
                string email = dgv_staff.Rows[e.RowIndex].Cells["email_col"].Value.ToString();
                string phoneNumber = dgv_staff.Rows[e.RowIndex].Cells["sdt_col"].Value.ToString();
                string role = dgv_staff.Rows[e.RowIndex].Cells["role_col"].Value.ToString();

                StaffDTO selectedStaff = new StaffDTO(id, fullName, gender, email, phoneNumber, role);

                ContextMenuStrip menu = CreateContextMenu(selectedStaff);
                menu.Show(Cursor.Position);
            }
        }

        private ContextMenuStrip CreateContextMenu(StaffDTO staff)
        {
            ContextMenuStrip menu = new ContextMenuStrip
            {
                Renderer = new CustomMenuRenderer(),
                ShowImageMargin = false,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            menu.Items.Add("👤 Thông tin", null, (s, e) => DetailStaff(staff));
            menu.Items.Add("✏ Chỉnh sửa", null, (s, e) => EditStaff(staff));
            menu.Items.Add("🗑 Xóa", null, (s, e) => DeleteStaff(staff));
            menu.Items.Add("💰 Phát lương", null, (s, e) => PaySalary(staff));

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
            public override Color MenuItemSelected => Color.FromArgb(203, 45, 62); 
            public override Color MenuItemBorder => Color.FromArgb(239, 71, 58); 
            public override Color ToolStripDropDownBackground => Color.White; 
            public override Color MenuBorder => Color.LightGray;
        }

        private void EditStaff(StaffDTO staff)
        {
            StaffDTO selectedStaff = StaffDA.Instance.GetStaffById(staff.Id);
            if (Application.OpenForms["EditStaffView"] == null)
            {
                EditStaffView updateForm = new EditStaffView(selectedStaff)
                {
                    Opacity = 0
                };
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

                updateForm.FormClosed += (s, args) => LoadStaffData();
            }
            else
            {
                Application.OpenForms["EditStaffView"].Activate();
            }
        }

        private void DeleteStaff(StaffDTO staff)
        {
            var result = MessageBoxHelper.ShowQuestion("Xác nhận", "Bạn có chắc chắn muốn xóa nhân viên này?");
            if (result == DialogResult.Yes)
            {
                if (StaffDA.Instance.DeleteStaff(staff.Id))
                {
                    MessageBoxHelper.ShowSuccess("Thông báo", "Xóa nhân viên thành công!");
                    LoadStaffData();
                }
            }
        }

        private void DetailStaff(StaffDTO staff)
        {
            StaffDTO selectedStaff = StaffDA.Instance.GetStaffById(staff.Id);
            if (Application.OpenForms["StaffDetailView"] == null)
            {
                StaffDetailView updateForm = new StaffDetailView(selectedStaff) // Giả sử form UpdateStaff có constructor nhận StaffDTO
                {
                    Opacity = 0
                };
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

                updateForm.FormClosed += (s, args) => LoadStaffData();
            }
            else
            {
                Application.OpenForms["StaffDetailView"].Activate();
            }
        }

        private void PaySalary(StaffDTO staff)
        {
            DateTime today = DateTime.Today;

            bool daPhatLuong = StaffSalaryDA.Instance.IsSalaryPaidThisMonth(staff.Id, today);

            if (daPhatLuong)
            {
                MessageBoxHelper.ShowInfo("Thông báo", $"Nhân viên {staff.FullName} đã được phát lương trong tháng này rồi!");
                return;
            }

            int salary = StaffDA.Instance.GetStaffById(staff.Id).Salary;
            
            if (salary == 0)
            {
                MessageBoxHelper.ShowInfo("Thông báo", $"Lương của nhân viên {staff.FullName} hiện tại là 0, không thể phát lương!");
                return;
            }

            DialogResult dialogResult = MessageBoxHelper.ShowQuestion("Xác nhận", $"Bạn có chắc chắn muốn phát lương cho nhân viên {staff.FullName} không?");
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            else
            {
                bool success = StaffSalaryDA.Instance.PhatLuongTheoId(staff.Id, today, salary);

                if (success)
                {
                    MessageBoxHelper.ShowSuccess("Thành công", $"Đã phát lương cho nhân viên {staff.FullName}!");
                    LoadStaffData();
                }
                else
                {
                    MessageBoxHelper.ShowError("Lỗi", $"Không thể phát lương cho nhân viên {staff.FullName}.");
                }
            }    
        }

        private void xuatEXEL_bnt_Click(object sender, EventArgs e)
        {
            if (dgv_staff.Rows.Count == 0)
            {
                MessageBoxHelper.ShowInfo("Thông báo", "Không có dữ liệu để xuất!");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Lưu file Excel",
                FileName = "DanhSachNhanVien.xlsx"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add("Nhân viên");

                            var staffList = StaffDA.Instance.GetAllStaffFullInfo();

                            string[] headers = { "ID", "Họ và Tên", "Giới Tính", "Email", "Số Điện Thoại", "Chức Vụ", "Ngày Sinh", "Ngày Vào Làm", "Lương" };
                            for (int i = 0; i < headers.Length; i++)
                            {
                                ws.Cell(1, i + 1).Value = headers[i];
                            }

                            for (int i = 0; i < staffList.Count; i++)
                            {
                                var staff = staffList[i];
                                ws.Cell(i + 2, 1).Value = staff.IdFormat;
                                ws.Cell(i + 2, 2).Value = staff.FullName;
                                ws.Cell(i + 2, 3).Value = staff.Gender;
                                ws.Cell(i + 2, 4).Value = staff.Email;
                                ws.Cell(i + 2, 5).Value = staff.PhoneNumber;
                                ws.Cell(i + 2, 6).Value = staff.Role;
                                ws.Cell(i + 2, 7).Value = staff.Birth;
                                ws.Cell(i + 2, 8).Value = staff.NgayVaoLam;
                                ws.Cell(i + 2, 9).Value = staff.Salary;
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

        private void paySalary_Btn_Click(object sender, EventArgs e)
        {
            string[] s = DateTime.Today.ToString("yyyy-MM-dd").Split('-'); 
            DialogResult result = MessageBoxHelper.ShowQuestion("Thông báo", "Bạn có muốn phát lương cho nhân viên không?");
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                if (s[2] != "20")
                {
                    MessageBoxHelper.ShowInfo("Thông báo", "Hôm nay không phải ngày phát lương!");
                    return;
                }
                int count = StaffSalaryDA.Instance.PhatLuongAll();

                if (count > 0)
                {
                    MessageBoxHelper.ShowSuccess("Thông báo", $"Đã phát lương cho {count} nhân viên thành công!");
                    LoadStaffData();
                }
                else
                {
                    MessageBoxHelper.ShowInfo("Thông báo", "Tất cả nhân viên đã được phát lương trong tháng này rồi!");
                }
            }
        }

        private void InitializeDebounce()
        {
            debounceTimer = new Timer();
            debounceTimer.Interval = 300;
            debounceTimer.Tick += DebounceTimer_Tick;
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
            if (luachontim_cbb.SelectedItem?.ToString() == "Tên nhân viên")
                _currentSearchType = SearchType.FullName;
            else if (luachontim_cbb.SelectedItem?.ToString() == "Số điện thoại")
                _currentSearchType = SearchType.PhoneNumber;
        }

        private void DebounceTimer_Tick(object sender, EventArgs e)
        {
            debounceTimer.Stop();
            string keyword = _debounceKeyword;
            string searchType = _currentSearchType.ToString();
            var filtered = StaffDA.Instance.SearchStaff(keyword, searchType, 10) ?? new List<StaffDTO>();  
            dgv_staff.DataSource = filtered;
        }
    }
}
