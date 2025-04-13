using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                this.txt_TimeStartMovie.Text = showTimSelect.StartTime.ToString();
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
                    seat.condition = true;
                }

                // Cập nhật trạng thái ghế trong cơ sở dữ liệu
                try
                {
                    SeatForShowTimeDA.Instance.UpdateSeatCondition(seatsShowTime);
                    MessageBox.Show("Hóa đơn đã được tạo thành công! Các ghế đã được đặt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string note = this.txt_Note.Text;
                    _addBillShowTimeViewModel.AddBillShowTime(showTimSelect, seatsShowTime.Count,note); 

                    // (Tùy chọn) Làm mới giao diện ghế nếu cần
                    OnBillCreated?.Invoke(this, EventArgs.Empty); // gui du lieu ra ben ngoai
                    this.Refresh();
                    this.txt_TotalPrice.ResetText();
                    this.txt_Seats.ResetText();
                    this.seatsShowTime.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu trạng thái ghế: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ghế trước khi tạo hóa đơn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
