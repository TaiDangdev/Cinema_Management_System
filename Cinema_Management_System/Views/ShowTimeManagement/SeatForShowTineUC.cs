using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Management_System.Views.ShowTimeManagement
{
    public partial class SeatForShowTineUC : UserControl
    {
        public List<SeatForShowTimesDTO> seatsSelect;
        public ShowTimeDTO showTimeselect;
        public event Action<SeatForShowTimesDTO> SeatSelected;

        public SeatForShowTineUC()
        {
            InitializeComponent();
            this.seatsSelect = new List<SeatForShowTimesDTO>();
            this.LoadSeatForSowTime();
        }

        public void LoadSeatForSowTime()
        {
            //System.Windows.Forms.MessageBox.Show("hahaha");
            this.FLP_SeatForShowTime.Controls.Clear();
            
            var seatList = SeatForShowTimeDA.Instance.GetSeatByShowTimes(showTimeselect);

            foreach (var seat in seatList) { 
                Button seatButton=new Button();
                seatButton.Tag = seat; 
                seatButton.Text=seat.location.ToString();
                seatButton.Width = 42;
                seatButton.Height = 36;
                seatButton.Margin = new Padding(4,2,4,2);
                seatButton.FlatStyle = FlatStyle.Flat;
                seatButton.FlatAppearance.BorderSize = 1;
                seatButton.FlatAppearance.BorderColor = Color.Green; // ✅ Viền màu xanh
                seatButton.BackColor = seat.condition.HasValue ? Color.Gray : Color.White;
                //seatButton.Enabled = !seat.condition.GetValueOrDefault(false);
                seatButton.Click += SeatButton_Click;
                seatButton.MouseDown += SeatButton_RightClick; // Đăng ký sự kiện chuột phải
                this.FLP_SeatForShowTime.Controls.Add(seatButton);
            }

        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button clickedBtn = sender as Button;
            var seat = (SeatForShowTimesDTO)clickedBtn.Tag;
            if (clickedBtn.BackColor == Color.Gray)
            {
                return;
            }
            // Ví dụ: toggle màu ghế, trạng thái chọn
            if (clickedBtn.BackColor == Color.White)
            {
                clickedBtn.BackColor = Color.Red;
                this.seatsSelect.Add(seat);
                // gui su kien ra ben ngoai
                SeatSelected?.Invoke(seat);

            }
            else if (clickedBtn.BackColor == Color.Red)
            {
                clickedBtn.BackColor = Color.White;
                this.seatsSelect.Remove(seat);
                SeatSelected?.Invoke(seat);
            }

        }


        private void SeatButton_RightClick(object sender, MouseEventArgs e)
        {
            Button clickedBtn = sender as Button;
            var seat = (SeatForShowTimesDTO)clickedBtn.Tag;

            if (e.Button == MouseButtons.Right && clickedBtn.BackColor == Color.Gray) // Nếu ghế màu xám
            {
                // Tạo một Menu ngữ cảnh (ContextMenuStrip)
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                // Tùy chọn "Hủy ghế"
                ToolStripMenuItem cancelSeatItem = new ToolStripMenuItem("Hủy ghế");
                cancelSeatItem.Click += (s, args) => CancelSeat(seat, clickedBtn);
                contextMenu.Items.Add(cancelSeatItem);

                //// Tùy chọn "Sửa thông tin ghế"
                //ToolStripMenuItem editSeatItem = new ToolStripMenuItem("Sửa thông tin ghế");
                //editSeatItem.Click += (s, args) => EditSeat(seat);
                //contextMenu.Items.Add(editSeatItem);

                //// Hiển thị menu ngữ cảnh
                contextMenu.Show(clickedBtn, e.Location);
            }
        }

        private void CancelSeat(SeatForShowTimesDTO seat, Button clickedBtn)
        {
            SeatForShowTimesDTO seatForShowTimesReset = (SeatForShowTimesDTO)clickedBtn.Tag;
            //MessageBoxHelper.ShowQuestion("Hủy ghế", $"Bạn có chắc chắn muốn hủy ghế {seatForShowTimesDTO.location} không?");
            if (DialogResult.No == MessageBoxHelper.ShowQuestion("Hủy ghế", $"Bạn có chắc chắn muốn hủy ghế {seatForShowTimesReset.IdSeatForShowTimes} không?"))
            {
                return;
            }
            else
            {
                SeatForShowTimeDA.Instance.ResetSeatsCodition(seatForShowTimesReset.IdSeatForShowTimes); 
            }
            clickedBtn.BackColor = Color.White;
            // Cập nhật lại trạng thái ghế nếu cần thiết
            // Ví dụ: Cập nhật cơ sở dữ liệu ghế về trạng thái chưa được chọn.
        }

        private void EditSeat(SeatForShowTimesDTO seat)
        {
            // Sửa thông tin ghế (ví dụ: hiển thị một form chỉnh sửa thông tin ghế)
            //MessageBox.Show($"Chỉnh sửa thông tin ghế {seat.location}");
        }


    }
}
