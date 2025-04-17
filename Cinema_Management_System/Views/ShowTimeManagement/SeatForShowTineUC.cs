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
                seatButton.BackColor = seat.condition.GetValueOrDefault(false) ? Color.Gray : Color.White;
                seatButton.Enabled = !seat.condition.GetValueOrDefault(false);
                seatButton.Click += SeatButton_Click;
               this.FLP_SeatForShowTime.Controls.Add(seatButton);
            }

        }
        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button clickedBtn = sender as Button;
            var seat = (SeatForShowTimesDTO)clickedBtn.Tag;

            // Ví dụ: toggle màu ghế, trạng thái chọn
            if (clickedBtn.BackColor == Color.White)
            {
                clickedBtn.BackColor = Color.Red;
                this.seatsSelect.Add(seat);
                // gui su kien ra ben ngoai

            }
            else if (clickedBtn.BackColor == Color.Red)
            {
                clickedBtn.BackColor = Color.White;
                this.seatsSelect.Remove(seat);
            }
            SeatSelected?.Invoke(seat);
        }

        private void SeatForShowTineUC_Load(object sender, EventArgs e)
        {

        }
    }
}
