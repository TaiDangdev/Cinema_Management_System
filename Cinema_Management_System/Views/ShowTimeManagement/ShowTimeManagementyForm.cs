using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.ViewModels.ShowTimeManagementVM;
using Cinema_Management_System.Views.MessageBox;
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
using System.Windows.Input;
using System.Xml.Linq;
using static Cinema_Management_System.AboutAccount_Form;

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
            AboutAccount_Form.getRole();
            if(AboutAccount_Form.currentRole=="Nhân viên")
            {
                this.btn_AddShowTimeMovie.Hide();
            }
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
                Panel panel = CreateShowTimeButton(showTime, BtnShowTimeMovieVyAuditorium_Click);
                panel.Tag = showTime.Movie_id;
                this.FLP_ShowTimeMovie.Controls.Add(panel);
            }
        }

        // tao cac button chua thoing tin cua bo phim
        private Panel CreateShowTimeButton(ShowTimeDTO showTime, EventHandler clickHandler)
        {
            // Tạo panel chứa tiêu đề và ảnh phim
            var panel = new Panel
            {
                Size = new Size(220, 360),
                Margin = new Padding(5, 20, 5, 10),
                BorderStyle = BorderStyle.None
            };

            // Tạo label tiêu đề phim
            var lblTitle = new Label
            {
                Text = showTime.MovieTitle,
                AutoSize = false,
                Width = 220,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Padding = new Padding(5),
                AutoEllipsis = true,
            };

            // tao button chua hinh anh phim
            Button movieButton = new Button
            {
                Width = 220,
                Height = 260,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                BackgroundImageLayout = ImageLayout.Zoom,
                Cursor = System.Windows.Forms.Cursors.Hand
            };
            movieButton.FlatAppearance.BorderSize = 0;

            movieButton.Tag = -1;
            // Xử lý ảnh phim
            if (showTime.MovieImage != null && showTime.MovieImage.Length > 0)
            {
                try
                {
                    using (var ms = new System.IO.MemoryStream(showTime.MovieImage))
                    {
                        movieButton.BackgroundImage = Image.FromStream(ms);
                        //btn.Tag=showTime.ShowTimeID.ToString();
                    }
                }
                catch
                {
                    movieButton.BackgroundImage = Properties.Resources.add;
                }
            }
            else
            {
                movieButton.BackgroundImage = Properties.Resources.add;
            }
            movieButton.Tag = showTime.Movie_id; 
            if (clickHandler != null)
            {
                movieButton.Click += clickHandler;
            }
            SetupHoverEffect(movieButton, lblTitle);

            var btnMoreOptions = new Panel
            {
                Size = new Size(20, 20),
                Margin = new Padding(5, 20, 5, 10),
                BorderStyle = BorderStyle.None
            };

            btnMoreOptions.Top = 0;
            btnMoreOptions.Left = movieButton.Width - btnMoreOptions.Width - 10;
            movieButton.Top = btnMoreOptions.Bottom + 10;
            lblTitle.Top = movieButton.Bottom + 5;


            // **THÊM CẢ `btn` VÀ `lblTitle` VÀO `panel`**
            panel.Controls.Add(movieButton);      // Thêm nút hình ảnh vào panel
            panel.Controls.Add(lblTitle); // Thêm tiêu đề vào panel
            return panel;
        }

        // xu ly su kiện khi bấm vaò button chọn phim, => hiển thị ra xuất chiếu của bộ phim đó.
        private void BtnShowTimeMovieVyAuditorium_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ShowTimeByMovieForm frm = new ShowTimeByMovieForm((int)btn.Tag, idAutoriumSelect);
            frm.ShowDialog();
            this.load_ShowTimeMovie((int)btn.Tag);
            //this.load_ShowTimeMovie((int)btn.Tag);
            //idAutoriumSelect = (int)btn.Tag;
            // load lai du lieu neu thuc da chinh sua xong 
            this.load_ShowTimeMovie(-1);
            idAutoriumSelect = -1;
        }

        // su kien khi chon loc bang ngay
        private void BtnShowTimeMovieByDate_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ShowTimeByMovieForm frm = new ShowTimeByMovieForm((int)btn.Tag, this.DTP_SearchTimeMovie.Value);
            frm.ShowDialog();
            this.DTP_SearchTimeMovie_ValueChanged(this, EventArgs.Empty);
            //// load lai du lieu neu thuc da chinh sua xong
            //this.load_ShowTimeMovie(-1);
            //idAutoriumSelect = -1;
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
                Panel btn = CreateShowTimeButton(showTime, BtnShowTimeMovieByDate_Click);
                btn.Tag = showTime.Movie_id;
                this.FLP_ShowTimeMovie.Controls.Add(btn);
            }
        }


        /// <summary>
        /// Thêm hiệu ứng phóng to ảnh khi hover
        /// </summary>
        private void SetupHoverEffect(Button movieButton, Label titleLabel)
        {
            Timer zoomTimer = new Timer { Interval = 10 };
            Timer hideButtonTimer = new Timer { Interval = 2000 };
            int targetSize = 240;
            int originalSize = 220;
            bool zoomingIn = false;

            movieButton.MouseEnter += (s, e) =>
            {
                zoomingIn = true;
                zoomTimer.Start();
                titleLabel.ForeColor = Color.Red;
                hideButtonTimer.Stop();

            };

            movieButton.MouseLeave += (s, e) =>
            {
                zoomingIn = false;
                zoomTimer.Start();
                titleLabel.ForeColor = Color.Black;
                hideButtonTimer.Start();
            };

            hideButtonTimer.Tick += (s, e) =>
            {
                hideButtonTimer.Stop();
            };

            zoomTimer.Tick += (s, e) =>
            {
                if (zoomingIn)
                {
                    if (movieButton.Width < targetSize)
                    {
                        movieButton.Width += 2;
                        movieButton.Height += 2;
                        movieButton.Left -= 1;
                        movieButton.Top -= 1;
                    }
                    else zoomTimer.Stop();
                }
                else
                {
                    if (movieButton.Width > originalSize)
                    {
                        movieButton.Width -= 2;
                        movieButton.Height -= 2;
                        movieButton.Left += 1;
                        movieButton.Top += 1;
                    }
                    else zoomTimer.Stop();
                }
            };
        }

        private void btn_AddShowTimeMovie_Click_1(object sender, EventArgs e)
        {
            AddShowTimeForm frm = new AddShowTimeForm();
            frm.ShowDialog();
            this._viewModelShowTime.LoadShowTimes();
            this.load_ShowTimeMovie(-1);
            idAutoriumSelect = -1;
        }

        private void btn_ticketExchange_Click(object sender, EventArgs e)
        {
            BillSeatsForShowTimesExchangeForm billSeatsForShowTimesExchangeForm = new BillSeatsForShowTimesExchangeForm();
            billSeatsForShowTimesExchangeForm.ShowDialog();
        }
    }
}
