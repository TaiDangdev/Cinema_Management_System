using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.MessageBox;
using Cinema_Management_System.Views.ShowTimeManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Navigation;
using static Cinema_Management_System.AboutAccount_Form;

namespace Cinema_Management_System.ViewModels.ShowTimeManagementVM
{
    public partial class BillShowTimeForm : Form
    {
        public ShowTimeDTO showTimSelect;
        public List<SeatForShowTimesDTO> seatsShowTime;
        public event EventHandler OnBillCreated;
        AddBillShowTimeViewModel _addBillShowTimeViewModel;

        public BillShowTimeForm()
        {
            InitializeComponent();
            _addBillShowTimeViewModel = new AddBillShowTimeViewModel();
        }

        public void LoadinfoMovie()
        {
            if (this.showTimSelect != null)
            {
                this.txt_Movie.Text = showTimSelect.MovieTitle.ToString();
                this.txt_NameAuditorium.Text = showTimSelect.AuditoriumName.ToString();
                this.txt_NameCinema.Text = "Cinema";
                this.txt_TimeStartMovie.Text = showTimSelect.StartTime.ToString("dd/MM/yyyy HH:mm");
                this.txt_priceOfTicket.Text = showTimSelect.SeatTicketPrice.ToString("F2") + "VND";
            }
        }


        public void AddSeatToBill(SeatForShowTimesDTO seat)
        {
            this.txt_Seats.Clear();
            if (!seatsShowTime.Any(s => s.IdSeatForShowTimes == seat.IdSeatForShowTimes))
            {
                seatsShowTime.Add(seat);
                // Cập nhật giao diện hóa đơn nếu cần, ví dụ:
                this.txt_Seats.Text = string.Join(", ", seatsShowTime.Select(s => s.location));
                long total = Convert.ToInt64(this.showTimSelect.SeatTicketPrice) * seatsShowTime.Count;
                this.txt_TotalPrice.Text = total.ToString("F2") + "VND";
            }
            else
            {
                seatsShowTime.Remove(seat);
                long total = Convert.ToInt64(this.showTimSelect.SeatTicketPrice) * seatsShowTime.Count;
                this.txt_Seats.Text = string.Join(", ", seatsShowTime.Select(s => s.location));
                this.txt_TotalPrice.Text = total.ToString("F2") + "VND";
            }
        }


        private void btn_AddBill_Click(object sender, EventArgs e)
        {
            if (seatsShowTime != null && seatsShowTime.Any())
            {
                // Đặt condition = true cho tất cả ghế trong danh sách
                foreach (var seat in seatsShowTime)
                {
                    seat.condition = 0;
                }
                try
                {
                    string note = this.txt_Note.Text;
                    string discountText = this.txt_discount.Text.Trim();
                    double discount = 0;
                    int MaBill;
                    if (string.IsNullOrEmpty(discountText))
                    {
                        
                        discount = 0;
                        MaBill = _addBillShowTimeViewModel.AddBillShowTime(showTimSelect, seatsShowTime.Count, note, (int)discount, CurrentUser.StaffId);
                        
                    }
                    else
                    {
                        if (double.TryParse(discountText, out discount))
                        {
                            // Chuyển đổi thành công, bạn có thể sử dụng discount ở đây
                        }
                        else
                        {
                            MessageBoxHelper.ShowWarning("Giảm giá không hợp lệ", "Cảnh báo");
                        }
                        MaBill = _addBillShowTimeViewModel.AddBillShowTime(showTimSelect, seatsShowTime.Count, note, (int)discount, CurrentUser.StaffId, this.txt_member.Text.Trim());
                    }
                    if (MaBill != -1)
                    {
                        DataSet BillDataSet = this.InfoBill(MaBill);
                        BillTicketForms billTicket = new BillTicketForms(BillDataSet);
                        foreach (var seat in seatsShowTime)
                        {
                            seat.condition = MaBill;
                        }
                        SeatForShowTimeDA.Instance.UpdateSeatCondition(seatsShowTime);
                        // Đặt condition = maBill cho tất cả ghế trong danh sách

                        MessageBoxHelper.ShowSuccess("Thành công", "Chọn ghế thành công");
                        billTicket.ShowDialog();
                    }
                    // (Tùy chọn) Làm mới giao diện ghế nếu cần
                    try
                    {
                        if (!string.IsNullOrEmpty(this.txt_discount.Text))
                        {
                            //CustomerDA customerDA = new CustomerDA();
                            var member = CustomerDA.Instance.GetCustomerByPhoneNumber(this.txt_member.Text.Trim());
                            if (member != null)
                            {
                                CustomerDA.Instance.UpdatePoint(this.txt_member.Text.Trim(), seatsShowTime.Count);  // Gọi UpdatePoint khi khách hàng hợp lệ
                            }
                            else
                            {
                                MessageBoxHelper.ShowWarning("Số điện thoại không hợp lệ hoặc không tồn tại!", "Cảnh báo");
                            }
                        }
                    }
                    catch
                    {
                        MessageBoxHelper.ShowError("Lỗi", "Lỗi khi cập nhật điểm cho hội viên!");
                    }
                    OnBillCreated?.Invoke(this, EventArgs.Empty); // gui du lieu ra ben ngoai
                    this.Refresh();
                    this.txt_TotalPrice.ResetText();
                    this.txt_Seats.ResetText();
                    this.seatsShowTime.Clear();
                    this.txt_discount.Clear();
                    this.txt_member.Clear();
                    this.txt_Note.Clear();
                }
                catch
                {
                    MessageBoxHelper.ShowError("Lỗi", "Lỗi khi lưu trạng thái ghế!");
                }
            }
            else
            {
                MessageBoxHelper.ShowWarning("Cảnh báo", "Vui lòng chọn ít nhất một ghế trước khi tạo hóa đơn!");
            }
        }

        private void btn_SearchMember_Click(object sender, EventArgs e)
        {
            string idTheHoiVien = this.txt_member.Text.Trim();
            if (!string.IsNullOrEmpty(idTheHoiVien))
            {
                // Kiểm tra thẻ hội viên
                var member = CustomerDA.Instance.GetCustomerByPhoneNumber(idTheHoiVien);
                if (member != null)
                {
                    long total = Convert.ToInt64(this.showTimSelect.SeatTicketPrice) * seatsShowTime.Count;
                    int discount = member.Point / 20;
                    double GiamGia = total * discount / 100;
                    this.txt_discount.Text = GiamGia.ToString("F2");
                    this.txt_TotalPrice.Text = (total - GiamGia).ToString("F2") + "VND";
                }
                else
                {
                    MessageBoxHelper.ShowWarning("Cảnh báo", "Thẻ hội viên không tồn tại!");
                    this.txt_member.Clear();
                    this.txt_discount.Clear();
                }
            }
            else
            {
                MessageBoxHelper.ShowWarning("Cảnh báo", "Vui lòng nhập mã thẻ hội viên!");
            }

        }

        private DataSet InfoBill(int idBill)
        {
            DataSet billDataSet = new DataSet();
            DataTable billTable = new DataTable("BillReport");
            // tao dataTable
            billTable.Columns.Add("SoDon", typeof(string));
            billTable.Columns.Add("TenPhim", typeof(string));
            billTable.Columns.Add("Phong", typeof(string));
            billTable.Columns.Add("Ghe", typeof(string));
            billTable.Columns.Add("GiaVe", typeof(string));
            billTable.Columns.Add("NgayGioChieu", typeof(string));
            billTable.Columns.Add("NhanVien", typeof(string));
            billTable.Columns.Add("TheHoiVien", typeof(string));
            billTable.Columns.Add("GiamGia", typeof(string));
            billTable.Columns.Add("TongTienVe", typeof(string));
            billTable.Columns.Add("Tong", typeof(string));

            //tao thong tin bill
            DataRow dataRow = billTable.NewRow();
            dataRow["SoDon"] = idBill.ToString();
            dataRow["TenPhim"] = showTimSelect.MovieTitle.ToString();
            dataRow["Phong"] = showTimSelect.AuditoriumName.ToString();
            dataRow["Ghe"] = this.txt_Seats.Text;
            dataRow["GiaVe"] = showTimSelect.SeatTicketPrice.ToString("F2") + "VND";
            dataRow["NgayGioChieu"] = showTimSelect.StartTime.ToString("dd/MM/yyyy HH:mm:ss");
            AboutAccount_Form.GetNameStaff();
            dataRow["NhanVien"] = AboutAccount_Form.currentUserName; // Thay thế bằng tên nhân viên thực tế
            dataRow["TheHoiVien"] = this.txt_member.Text.Trim();
            dataRow["GiamGia"] = this.txt_discount.Text.Trim();
            long total = Convert.ToInt64(this.showTimSelect.SeatTicketPrice) * seatsShowTime.Count;
            dataRow["TongTienVe"] = total.ToString("F2") + "VND";
            dataRow["Tong"] = this.txt_TotalPrice.Text.Trim();
            billTable.Rows.Add(dataRow);

            billDataSet.Tables.Add(billTable);
            return billDataSet;
        }
    }
}