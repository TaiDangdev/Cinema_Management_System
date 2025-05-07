
using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.ViewModels.ShowTimeManagementVM;
using Guna.UI2.WinForms.Suite;
using Guna.UI2.WinForms;
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
using System.Windows.Media.Media3D;

namespace Cinema_Management_System.Views.ShowTimeManagement
{
    public partial class AddShowTimeForm : Form
    {
        private ShowTimeViewModels _viewModelShowTime;
        private AuditoriumViewModels _viewModelAuditorium;
        bool AddStatus = true;
        ShowTimeDTO _showTimeUpdate;
        private Guna2ShadowForm shadowForm;
        public AddShowTimeForm()
        {
            InitializeComponent();
            _viewModelShowTime = new ShowTimeViewModels();
            _viewModelAuditorium= new AuditoriumViewModels();
            CB_NameShowTime.Enabled = true;
            DTP_DateShowTimeMovie.Enabled = true;
            DTP_TimeStartShowTimes.Enabled = true;
            this.LoadListMovie();
            this.LoadAuditorium();
            this.AddStatus = true;
            DTP_DateShowTimeMovie.Value = DateTime.Now.Date;
            SetupUI();
        }

        private void SetupUI()
        {
            DragHelper.EnableDrag(this, control_Panel);
            shadowForm = new Guna2ShadowForm
            {
                ShadowColor = Color.Black,
                BorderRadius = 20
            };
            shadowForm.SetShadowForm(this);
        }

        public AddShowTimeForm(ShowTimeDTO showtimeUpdate)
        {
            InitializeComponent();
            _showTimeUpdate = showtimeUpdate;
            _viewModelShowTime = new ShowTimeViewModels();
            _viewModelAuditorium = new AuditoriumViewModels();
            CB_NameShowTime.Enabled = false;
            DTP_DateShowTimeMovie.Enabled = false;
            DTP_TimeStartShowTimes.Enabled = false;
            this.LoadListMovie();
            this.LoadAuditorium();
            this.AddStatus = false;
            this.Label_Title.Text = "Sửa xuất chiếu";
            this.LoadinfoShowTime(showtimeUpdate);
            DTP_DateShowTimeMovie.Value = showtimeUpdate.StartTime.Date;
        }

        // hien thi thong hien hien co
        private void LoadinfoShowTime(ShowTimeDTO showTimeUpdate)
        {
            if (showTimeUpdate == null) return;

            // Gán giá trị của suất chiếu vào các controls trên form
            CB_NameShowTime.SelectedValue = showTimeUpdate.Movie_id;
            CB_Auditorium.SelectedValue = showTimeUpdate.Auditorium_Id;
            DTP_DateShowTimeMovie.Value = showTimeUpdate.StartTime.Date;
            this.DTP_TimeStartShowTimes.Text = showTimeUpdate.StartTime.ToString("HH:mm");
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
                    MessageBoxHelper.ShowError("Lỗi", "Vui lòng chọn đầy đủ thông tin!");
                    //System.Windows.Forms.MessageBox.Show("Vui lòng chọn đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int movieID = (int)CB_NameShowTime.SelectedValue;
                int auditoriumID = (int)CB_Auditorium.SelectedValue;
                DateTime showDate = DTP_DateShowTimeMovie.Value.Date;
                TimeSpan showTime = this.DTP_TimeStartShowTimes.Value.TimeOfDay;
                int ticketPrice;

                if (!int.TryParse(txt_PriceTicket.Text, out ticketPrice))
                {
                    MessageBoxHelper.ShowError("Lỗi", "Giá vé không hợp lệ!");
                    return;
                }
                // Neu la formn Add ShowTime
                if (this.AddStatus)
                {
                    bool success = _viewModelShowTime.AddShowTime(movieID, showDate, showTime, auditoriumID, ticketPrice);

                    if (success)
                    {
                        MessageBoxHelper.ShowSuccess("Thông báo", "Thêm suất chiếu thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBoxHelper.ShowError("Lỗi", "Thêm suất chiếu thất bại!");
                    }
                }
                // Neu la Form Update Showtime
                else
                {

                    bool success = _viewModelShowTime.UpdateShowTime(_showTimeUpdate.ShowTimeID,movieID, showDate, showTime, auditoriumID, ticketPrice);

                    if (success)
                    {
                        MessageBoxHelper.ShowSuccess("Thông báo", "Sửa xuất chiếu thành công!");
                        //System.Windows.Forms.MessageBox.Show("Sửa xuất chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBoxHelper.ShowError("Lỗi", "Sửa xuất chiếu thất bại!");
                        //System.Windows.Forms.MessageBox.Show("Sửa xuất chiếu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch
            {
                MessageBoxHelper.ShowError("Lỗi", "Thêm suất chiếu thất bại!");
                //System.Windows.Forms.MessageBox.Show("Thêm suất chiếu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
