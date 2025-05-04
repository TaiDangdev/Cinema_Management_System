using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.CustomerManagement;
using Cinema_Management_System.Views.MessageBox;
using ClosedXML.Excel;
using Guna.UI2.WinForms.Suite;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Management_System.Views.StaffManagement
{
    public partial class StaffManagementView : UserControl
    {
        public StaffManagementView()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
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
            var staffList = StaffDA.Instance.GetAllStaff() ?? new List<object>();
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
            //if (Application.OpenForms["UpdateStaff"] == null)
            //{
            //    UpdateStaff updateForm = new UpdateStaff(staff) // Giả sử form UpdateStaff có constructor nhận StaffDTO
            //    {
            //        Opacity = 0
            //    };
            //    updateForm.Show();

            //    Timer fadeTimer = new Timer { Interval = 10 };
            //    fadeTimer.Tick += (s, args) =>
            //    {
            //        if (updateForm.Opacity < 1)
            //        {
            //            updateForm.Opacity += 0.05;
            //        }
            //        else
            //        {
            //            fadeTimer.Stop();
            //        }
            //    };
            //    fadeTimer.Start();

            //    updateForm.FormClosed += (s, args) => LoadStaffData();
            //}
            //else
            //{
            //    Application.OpenForms["UpdateStaff"].Activate();
            //}
        }

        private void DeleteStaff(StaffDTO staff)
        {
            //var result = MessageBoxHelper.ShowQuestion("Xác nhận", "Bạn có chắc chắn muốn xóa nhân viên này?");
            //if (result == DialogResult.Yes)
            //{
            //    if (StaffDA.Instance.DeleteStaff(staff.Id)) // Cần có phương thức này trong StaffDA
            //    {
            //        MessageBoxHelper.ShowSuccess("Thông báo", "Xóa nhân viên thành công!");
            //        LoadStaffData();
            //    }
            //}
        }

        private void PaySalary(StaffDTO staff)
        {
            //// Logic phát lương (có thể mở rộng tùy theo yêu cầu)
            //var result = MessageBoxHelper.ShowQuestion("Xác nhận", $"Bạn có muốn phát lương cho nhân viên {staff.FullName} không?");
            //if (result == DialogResult.Yes)
            //{
            //    // Giả sử bạn có phương thức PaySalary trong StaffDA (cần thêm nếu chưa có)
            //    bool success = StaffDA.Instance.PaySalary(staff.Id); // Cần thêm phương thức này
            //    if (success)
            //    {
            //        MessageBoxHelper.ShowSuccess("Thông báo", $"Phát lương cho nhân viên {staff.FullName} thành công!");
            //    }
            //    else
            //    {
            //        MessageBoxHelper.ShowError("Lỗi", "Không thể phát lương. Vui lòng thử lại.");
            //    }
            //}
        }

        private void xuatEXEL_bnt_Click(object sender, EventArgs e)
        {
            //if (dgv_staff.Rows.Count == 0)
            //{
            //    MessageBoxHelper.ShowInfo("Thông báo", "Không có dữ liệu để xuất!");
            //    return;
            //}

            //using (SaveFileDialog sfd = new SaveFileDialog()
            //{
            //    Filter = "Excel Workbook|*.xlsx",
            //    Title = "Lưu file Excel",
            //    FileName = "DanhSachNhanVien.xlsx"
            //})
            //{
            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //        try
            //        {
            //            using (XLWorkbook wb = new XLWorkbook())
            //            {
            //                var ws = wb.Worksheets.Add("Nhân viên");

            //                // Tạo header từ DataGridView
            //                for (int i = 0; i < dgv_staff.Columns.Count; i++)
            //                {
            //                    if (dgv_staff.Columns[i].Name != "more_Btn")
            //                    {
            //                        ws.Cell(1, i + 1).Value = dgv_staff.Columns[i].HeaderText;
            //                    }
            //                }

            //                // Ghi từng dòng dữ liệu
            //                for (int i = 0; i < dgv_staff.Rows.Count; i++)
            //                {
            //                    int colIndex = 1;
            //                    for (int j = 0; j < dgv_staff.Columns.Count; j++)
            //                    {
            //                        if (dgv_staff.Columns[j].Name != "Action") // Bỏ cột Action
            //                        {
            //                            ws.Cell(i + 2, colIndex).Value = dgv_staff.Rows[i].Cells[j].Value?.ToString();
            //                            colIndex++;
            //                        }
            //                    }
            //                }

            //                wb.SaveAs(sfd.FileName);
            //            }

            //            MessageBoxHelper.ShowSuccess("Thông báo", "Xuất file Excel thành công!");
            //        }
            //        catch
            //        {
            //            MessageBoxHelper.ShowError("Lỗi", "Lỗi khi xuất file");
            //        }
            //    }
            //}
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

                            // Lấy toàn bộ dữ liệu nhân viên từ StaffDA (bao gồm tất cả thông tin trừ ImageSource)
                            var staffList = StaffDA.Instance.GetAllStaffFullInfo(); // Cần thêm phương thức này

                            // Tạo header
                            string[] headers = { "ID", "Họ và Tên", "Giới Tính", "Email", "Số Điện Thoại", "Chức Vụ", "Ngày Sinh", "Ngày Vào Làm", "Lương" };
                            for (int i = 0; i < headers.Length; i++)
                            {
                                ws.Cell(1, i + 1).Value = headers[i];
                            }

                            // Ghi từng dòng dữ liệu
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
                    catch(Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Lỗi khi xuất file" + ex.Message);
                        //MessageBoxHelper.ShowError("Lỗi", "Lỗi khi xuất file" + ex.Message);
                    }
                }
            }

        }
    }
}
