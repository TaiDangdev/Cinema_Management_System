
using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.ViewModels.ShowTimeManagementVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace Cinema_Management_System.Views.ShowTimeManagement
{
    public partial class AddShowTimeForm : Form
    {
        private ShowTimeViewModels _viewModelShowTime;
        private AuditoriumViewModels _viewModelAuditorium;
        bool AddStatus = true;
        ShowTimeDTO _showTimeUpdate;
        public AddShowTimeForm()
        {
            InitializeComponent();
            _viewModelShowTime = new ShowTimeViewModels();
            _viewModelAuditorium= new AuditoriumViewModels();
            this.LoadListMovie();
            this.LoadAuditorium();
            this.AddStatus = true;
            DTP_DateShowTimeMovie.Value = DateTime.Now.Date;
        }

        public AddShowTimeForm(ShowTimeDTO showtimeUpdate)
        {
            InitializeComponent();
            _showTimeUpdate = showtimeUpdate;
            _viewModelShowTime = new ShowTimeViewModels();
            _viewModelAuditorium = new AuditoriumViewModels();
            this.LoadListMovie();
            this.LoadAuditorium();
            this.AddStatus = false;
            this.Label_Title.Text = "Sửa xuất chiếu";
            this.LoadinfoShowTime(showtimeUpdate);
            DTP_DateShowTimeMovie.Value = DateTime.Now.Date;
        }

        // hien thi thong hien hien co
        private void LoadinfoShowTime(ShowTimeDTO showTimeUpdate)
        {
            if (showTimeUpdate == null) return;

            // Gán giá trị của suất chiếu vào các controls trên form
            CB_NameShowTime.SelectedValue = showTimeUpdate.Movie_id;
            CB_Auditorium.SelectedValue = showTimeUpdate.Auditorium_Id;
            DTP_DateShowTimeMovie.Value = showTimeUpdate.StartTime.Date;
            txt_TimeMovieStart.Text = showTimeUpdate.StartTime.ToString("HH:mm");
            txt_PriceTicket.Text = showTimeUpdate.SeatTicketPrice.ToString("F0");
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadListMovie()
        {
            // lay danh sach cac bo phim
            this.CB_NameShowTime.Items.Clear();
            List<MOVIE> danhSachPhim = _viewModelShowTime.LoadListMovie();
            if (danhSachPhim != null && danhSachPhim.Count > 0)
            {
                CB_NameShowTime.DataSource = danhSachPhim;
                CB_NameShowTime.DisplayMember = "Title"; // Hiển thị tên phim
                CB_NameShowTime.ValueMember = "id"; // Lưu ID phim
            }
        }

        private void LoadAuditorium()
        {
           this.CB_Auditorium.Items.Clear();
            List<Auditorium> ListAuditorium = _viewModelAuditorium.Auditoriums;
            if(ListAuditorium!=null && ListAuditorium.Count > 0)
            {
                CB_Auditorium.DataSource= ListAuditorium;
                CB_Auditorium.DisplayMember = "Name";
                CB_Auditorium.ValueMember = "Id";
            }
        }

        private void AddShowTimeForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_AddShowTimeMovie_Click(object sender, EventArgs e)
        {
            try
            {
                if (CB_NameShowTime.SelectedItem == null || CB_Auditorium.SelectedItem == null)
                {
                    System.Windows.Forms.MessageBox.Show("Vui lòng chọn đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int movieID = (int)CB_NameShowTime.SelectedValue;
                int auditoriumID = (int)CB_Auditorium.SelectedValue;
                DateTime showDate = DTP_DateShowTimeMovie.Value.Date;
                TimeSpan showTime = TimeSpan.Parse(this.txt_TimeMovieStart.Text);
                int ticketPrice;

                if (!int.TryParse(txt_PriceTicket.Text, out ticketPrice))
                {
                    System.Windows.Forms.MessageBox.Show("Giá vé không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Neu la formn Add ShowTime
                if (this.AddStatus)
                {
                    bool success = _viewModelShowTime.AddShowTime(movieID, showDate, showTime, auditoriumID, ticketPrice);

                    if (success)
                    {
                        System.Windows.Forms.MessageBox.Show("Thêm suất chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Thêm suất chiếu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // Neu la Form Update Showtime
                else
                {

                    bool success = _viewModelShowTime.UpdateShowTime(_showTimeUpdate.ShowTimeID,movieID, showDate, showTime, auditoriumID, ticketPrice);

                    if (success)
                    {
                        System.Windows.Forms.MessageBox.Show("Sửa xuất chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Thêm suất chiếu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Thêm suất chiếu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
