using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.ViewModels.ShowTimeManagementVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Cinema_Management_System.Views.ShowTimeManagement
{
    public partial class ShowTimeManagementyForm : UserControl
    {
        private AuditoriumViewModels _viewModelAuditorium;
        private ShowTimeViewModels _viewModelShowTime;
        int idAutoriumSelect = -1;

        public ShowTimeManagementyForm()
        {
            InitializeComponent();
            // khoi tao AuditoriumViewModels de lay cac du lieu logic
            _viewModelAuditorium = new AuditoriumViewModels();
            _viewModelShowTime=new ShowTimeViewModels();
            this.LoadRoom();
            this.load_ShowTimeMovie(-1);
        }

        private void LoadRoom()
        {
            this.FLP_Auditorium.Controls.Clear();

            // Nút "Toàn bộ"
            Guna.UI2.WinForms.Guna2Button btnToanBo = CreateAuditoriumButton("Toàn bộ");
            btnToanBo.Tag = -1;
            this.FLP_Auditorium.Controls.Add(btnToanBo);
            foreach (var phong in _viewModelAuditorium.Auditoriums)
            {
                Guna.UI2.WinForms.Guna2Button btn = CreateAuditoriumButton(phong.Name);
                btn.Tag = phong.Id; // luu id cua tung phong de sau nay tien tinh toan
                this.FLP_Auditorium.Controls.Add(btn);
            }
            this.FLP_Auditorium.FlowDirection = FlowDirection.LeftToRight;
            this.FLP_Auditorium.WrapContents = false;
        }

        // tao cac button chon phong
        private Guna.UI2.WinForms.Guna2Button CreateAuditoriumButton(string text)
        {
            Guna.UI2.WinForms.Guna2Button btn = new Guna.UI2.WinForms.Guna2Button();
            btn.Text = text;
            btn.Size = new Size(80, 40);
            btn.Margin = new Padding(5);
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.FillColor = Color.White;
            btn.BorderRadius = 5;
            btn.BorderColor = Color.Black;
            btn.BorderThickness = 1;
            btn.Click += BtnAuditorium_Click;
            return btn;
        }

        void load_ShowTimeMovie(int id)
        {
            this.FLP_ShowTimeMovie.Controls.Clear(); // Xóa các control hiện có trong FlowLayoutPane
            // Tạo các nút cho từng phòng và thêm vào FlowLayoutPane
            foreach (var showTime in _viewModelShowTime.FilterMovieByAuditorium(id))
            {
                Guna.UI2.WinForms.Guna2Panel btn = CreateShowTimeButton(showTime, BtnShowTimeMovieVyAuditorium_Click);
                btn.Tag = showTime.Movie_id;
                this.FLP_ShowTimeMovie.Controls.Add(btn);
            }
        }

        // tao cac button chua thoing tin cua bo phim
        private Guna.UI2.WinForms.Guna2Panel CreateShowTimeButton(ShowTimeDTO showTime, EventHandler clickHandler)
        {
            // Tạo panel chứa tiêu đề và ảnh phim
            var panel = new Guna.UI2.WinForms.Guna2Panel
            {
                Size = new Size(220, 300), // Tăng chiều cao để chứa tiêu đề
                BorderRadius = 5,
                BorderColor = Color.Black,
                BorderThickness = 1,
                Margin = new Padding(15, 15, 10, 15) // Khoảng cách giữa các button
            };

            // Tạo label tiêu đề phim
            var lblTitle = new Label
            {
                Text = showTime.MovieTitle, // Tiêu đề phim
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 40
            };


            Guna.UI2.WinForms.Guna2ImageButton btn = new Guna.UI2.WinForms.Guna2ImageButton();
           
            btn.Tag = -1;
            // Xử lý ảnh phim
            if (showTime.MovieImage != null && showTime.MovieImage.Length > 0)
            {
                try
                {
                    using (var ms = new System.IO.MemoryStream(showTime.MovieImage))
                    {
                        btn.Image = Image.FromStream(ms);
                        //btn.Tag=showTime.ShowTimeID.ToString();
                    }
                }
                catch
                {
                    btn.Image = Properties.Resources.add;
                }
            }
            else
            {
                btn.Image = Properties.Resources.add;
            }
            btn.Tag = showTime.Movie_id; 
            btn.Size = new Size(220,260);
            btn.ImageSize = new Size(210, 250);
            if (clickHandler != null)
            {
                btn.Click += clickHandler;
            }
            btn.Margin = new Padding(10, 15, 10, 15);
            btn.HoverState.ImageSize = new Size(220, 260); // Giữ nguyên kích thước ảnh
            btn.Dock = DockStyle.Fill;
            // **THÊM CẢ `btn` VÀ `lblTitle` VÀO `panel`**
            panel.Controls.Add(btn);      // Thêm nút hình ảnh vào panel
            panel.Controls.Add(lblTitle); // Thêm tiêu đề vào panel
            return panel;
        }

        // xu ly su kiện khi bấm vaò button chọn phim, => hiển thị ra xuất chiếu của bộ phim đó.
        private void BtnShowTimeMovieVyAuditorium_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2ImageButton btn = sender as Guna.UI2.WinForms.Guna2ImageButton;
            ShowTimeByMovieForm frm = new ShowTimeByMovieForm((int)btn.Tag, idAutoriumSelect);
            frm.ShowDialog();
            this.load_ShowTimeMovie((int)btn.Tag);
            // load lai du lieu neu thuc da chinh sua xong 
            this.load_ShowTimeMovie(-1);
            idAutoriumSelect = -1;
        }

        // su kien khi chon loc bang ngay
        private void BtnShowTimeMovieByDate_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2ImageButton btn = sender as Guna.UI2.WinForms.Guna2ImageButton;
            ShowTimeByMovieForm frm = new ShowTimeByMovieForm((int)btn.Tag, this.DTP_SearchTimeMovie.Value);
            frm.ShowDialog();
            this.DTP_SearchTimeMovie_ValueChanged(this, EventArgs.Empty);
            //// load lai du lieu neu thuc da chinh sua xong
            this.load_ShowTimeMovie(-1);
            idAutoriumSelect = -1;
        }


        // su kien khi chon phong
        private void BtnAuditorium_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = sender as Guna.UI2.WinForms.Guna2Button;
            if ((int)btn.Tag < 0)
            {
                this.load_ShowTimeMovie(-1);
                idAutoriumSelect = -1;
            }
            else
            {
                this.load_ShowTimeMovie((int)(btn.Tag));
                idAutoriumSelect = (int)btn.Tag;
            }
        }

        // loc khi chọn theo ngày
        private void DTP_SearchTimeMovie_ValueChanged(object sender, EventArgs e)
        {
            this.load_ShowTimeMovie(-1);
            idAutoriumSelect = -1;
            this.DTP_SearchTimeMovie.CustomFormat = "dd/MM/yyyy"; // Hiển thị text thay vì ngày
            DateTime dateFilter = this.DTP_SearchTimeMovie.Value;
            List<ShowTimeDTO> ShowTimeList = ShowTimeDA.Instance.filterShowTimeByDate(dateFilter);
            this.FLP_ShowTimeMovie.Controls.Clear(); // Xóa các control hiện có trong FlowLayoutPane
            // Tạo các nút cho từng phòng và thêm vào FlowLayoutPane
            foreach (var showTime in ShowTimeList)
            {
                Guna.UI2.WinForms.Guna2Panel btn = CreateShowTimeButton(showTime, BtnShowTimeMovieByDate_Click);
                btn.Tag = showTime.Movie_id;
                this.FLP_ShowTimeMovie.Controls.Add(btn);
            }
        }

        private void btn_AddShowTimeMovie_Click(object sender, EventArgs e)
        {
            AddShowTimeForm frm = new AddShowTimeForm();
            frm.ShowDialog();
            this._viewModelShowTime.LoadShowTimes();
            this.load_ShowTimeMovie(-1);
            idAutoriumSelect = -1;
        }

    }
}
