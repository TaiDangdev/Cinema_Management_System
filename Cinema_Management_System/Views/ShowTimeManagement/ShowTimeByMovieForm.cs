using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.ViewModels.ShowTimeManagementVM;
using Cinema_Management_System.Views.MessageBox;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Cinema_Management_System.Views.ShowTimeManagement
{


    public partial class ShowTimeByMovieForm : Form
    {
        // menu khi click chuột phải vào các button
        private ContextMenuStrip showTimeContextMenu;
        int _filterAuditorium = -1;
        int _idMovie = -1;
        DateTime _DateFilter;
        BillShowTimeForm billShowTimeForm;


        public ShowTimeByMovieForm()
        {
            InitializeComponent();
        }

        // hien thi theo phim va phong
        public ShowTimeByMovieForm(int idMovie,int idAuditorium)
        {
            InitializeComponent();
            this.LoadInfoMovie(idMovie);
            this.LoadShowTimesForMovie(idMovie, idAuditorium);
            _filterAuditorium = idAuditorium;
            this._idMovie = idMovie;
            this.seatForShowTineUC1.Hide();
            this.panel_showTimes.Show();
        }

        public ShowTimeByMovieForm(int idMovie,DateTime datefilter)
        {
            InitializeComponent();
            this.LoadInfoMovie(idMovie);
            this.LoadShowTimesForMovie(idMovie, datefilter);
            this._DateFilter = datefilter;
            this._idMovie = idMovie;
            this.seatForShowTineUC1.Hide();
            this.panel_showTimes.Show();
        }

        private void LoadInfoMovie(int idMovie)
        {
            MOVIE currentMovie=MovieDA.Instance.GetMovieById(idMovie);
            if (currentMovie == null)
            {
                MessageBoxHelper.ShowError("Lỗi", "Không thể lấy thông tin phim. Vui lòng thử lại!");
            }
            else
            {
                this.txt_MovieName.Text = currentMovie.Title.ToString();
                this.txt_Director.Text = currentMovie.Director.ToString();
                this.txt_Genre.Text = currentMovie.Genre.ToString();
                this.txt_Country.Text = currentMovie.Country.ToString();
                this.txt_Length.Text = currentMovie.Length.ToString();
                this.txt_DescribeMovie.Text = currentMovie.Description.ToString();

                if (currentMovie.ImageSource != null)
                {
                    using (MemoryStream ms = new MemoryStream(currentMovie.ImageSource.ToArray()))
                    {
                        this.PB_imageMovie.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    this.PB_imageMovie.Image = Properties.Resources.icons8_person_32;
                }
            }
        }
        // loc cac xuat chieu theo ngay va phim
        private void LoadShowTimesForMovie(int idMovie,DateTime dateFilter)
        {
            this.LoadShowTimesForMovie(idMovie, _filterAuditorium);
            this.FLP_ShowTimeFoerMovie.Controls.Clear();
            CreateContextMenu(); // Tạo menu chỉ 1 lần
            List<ShowTimeDTO> showTimelist = ShowTimeDA.Instance.filterShowTimeByDateAndMovie(idMovie, dateFilter);
            foreach (ShowTimeDTO showTime in showTimelist)
            {
                if (DateTime.Compare(showTime.StartTime.Date, dateFilter.Date) ==0)
                {
                    string text = $"{showTime.StartTime:dd/MM/yyyy}\n{showTime.StartTime:HH:mm} - {showTime.EndTime:HH:mm}";
                    Guna.UI2.WinForms.Guna2Button btn = CreateShowTimeButton(text);
                    btn.Tag = showTime; // luu thong tin cua moi suat chieu
                    if (showTime.Status == false)
                    {
                        btn.Enabled = false;
                    }
                    this.FLP_ShowTimeFoerMovie.Controls.Add(btn);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("nono");
                }
            }
            //this.FLP_ShowTimeFoerMovie.MouseDown += ShowContextMenuOnRightClick;
        }

        // loc cac suat chieu cua phim theo phong
        private void LoadShowTimesForMovie(int idMovie,int idAuditorium)
        {
            this.FLP_ShowTimeFoerMovie.Controls.Clear();
            CreateContextMenu(); // Tạo menu chỉ 1 lần
            List<ShowTimeDTO> showTimelist = ShowTimeDA.Instance.filterShowTimeByAuditoriumAndMovie(idMovie,idAuditorium);
            foreach(ShowTimeDTO showTime in showTimelist)
            {
                string text = $"{showTime.StartTime:dd/MM/yyyy}\n{showTime.StartTime:HH:mm} - {showTime.EndTime:HH:mm}";
                Guna.UI2.WinForms.Guna2Button btn = CreateShowTimeButton(text);
                // luu thong tin cua moi suat chieu
                btn.Tag = showTime; 
                if (showTime.Status == false)
                {
                    btn.Enabled = false;
                }

                this.FLP_ShowTimeFoerMovie.Controls.Add(btn);
            }
            //this.FLP_ShowTimeFoerMovie.MouseDown += ShowContextMenuOnRightClick;
        }


        // tao cac button chua thoing tin cua bo phim
        private Guna.UI2.WinForms.Guna2Button CreateShowTimeButton(string text)
        {
            Guna.UI2.WinForms.Guna2Button btn = new Guna.UI2.WinForms.Guna2Button();
            btn.Text = text;
            btn.Size = new System.Drawing.Size(150, 60);
            btn.Font = new Font("Arial", 12);
            btn.Margin = new Padding(5);
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.FillColor = Color.White;
            btn.BorderRadius = 15;
            btn.BorderColor = Color.Black;
            btn.BorderThickness = 2;
            btn.Click += BtnShowTimeMovie_Click; // them su kien khi bam chuojt trai
            if (AboutAccount_Form.currentRole != "Nhân viên")
            {
                btn.MouseDown += ShowContextMenuOnRightClick;
            }
            return btn;
        }


        // tao menu khi click chuot phai
        private void CreateContextMenu()
        {
                showTimeContextMenu = new ContextMenuStrip();
                //Segoe UI Semibold, 9.75pt, style = Bold
                showTimeContextMenu.Font = new Font("Segoe UI Semibold", 9, FontStyle.Regular);
                //showTimeContextMenu.BackColor = Color.LightGray;
                showTimeContextMenu.RenderMode = ToolStripRenderMode.System;
                ToolStripMenuItem updateItem = new ToolStripMenuItem("🔧 Sửa");
                ToolStripMenuItem deleteItem = new ToolStripMenuItem("🗑️ Xóa");

                updateItem.Click += UpdateShowTime;
                deleteItem.Click += DeleteShowTime;

                showTimeContextMenu.Items.Add(updateItem);
                showTimeContextMenu.Items.Add(deleteItem);
            
        }

        // su kien hien thi MenuStrp khi click chuot phai
        private void ShowContextMenuOnRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && sender is Guna.UI2.WinForms.Guna2Button btn )
            {
                // Lưu button vào ContextMenu để biết đang xử lý button nào
                showTimeContextMenu.Tag = btn;
                showTimeContextMenu.Show(Cursor.Position);
            }
        }

        // xu ly su kien Item Strip Update
        private void DeleteShowTime(object sender, EventArgs e)
        {
            if (showTimeContextMenu.Tag is Guna.UI2.WinForms.Guna2Button btn)
            {
                ShowTimeDTO showTime = (ShowTimeDTO)btn.Tag;
                if (showTime.StartTime<=DateTime.Now && showTime.EndTime >= DateTime.Now)
                {
                    MessageBoxHelper.ShowError("Lỗi", "Không thể xóa suất chiếu đang diễn ra");
                }
                DialogResult result = MessageBoxHelper.ShowQuestion("Xác nhận", "Bạn có chắc muốn xóa suất chiếu này?");
                if (result == DialogResult.Yes)
                {
                    btn.Parent.Controls.Remove(btn);
                    btn.Dispose();
                    ShowTimeDA.Instance.DeleteShowTime(showTime);
                }
            }
        }

        private void UpdateShowTime(object sender, EventArgs e)
        {
            if (showTimeContextMenu.Tag is Guna.UI2.WinForms.Guna2Button btn)
            {
                ShowTimeDTO showTime = (ShowTimeDTO)btn.Tag;
                AddShowTimeForm addShowTimeForm = new AddShowTimeForm(showTime);
                addShowTimeForm.ShowDialog();
                if (_filterAuditorium>=-1)
                {
                    this.LoadShowTimesForMovie(_idMovie, _filterAuditorium);
                }
                else
                {
                    this.LoadShowTimesForMovie(_idMovie, _DateFilter);
                }
            }
        }


        // su kien khi chon suat chieu
        private void BtnShowTimeMovie_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = sender as Guna.UI2.WinForms.Guna2Button;
            ShowTimeDTO showTimeSlect = (ShowTimeDTO)btn.Tag;

            // khoi tao chuc nanng chon ghe khi truyen vao showtime
            billShowTimeForm = new BillShowTimeForm();
            this.billShowTimeForm.showTimSelect=showTimeSlect;
            this.billShowTimeForm.seatsShowTime = new List<SeatForShowTimesDTO>();

            this.panel_showTimes.Hide();
            this.seatForShowTineUC1.showTimeselect = showTimeSlect;
            this.seatForShowTineUC1.LoadSeatForSowTime(); // load thong tin ghe
            this.seatForShowTineUC1.SeatSelected += billShowTimeForm.AddSeatToBill;
            this.seatForShowTineUC1.Show();

            billShowTimeForm.OnBillCreated += (s, evt) =>
            {
                this.seatForShowTineUC1.LoadSeatForSowTime();
                this.seatForShowTineUC1.seatsSelect.Clear();
            };

            billShowTimeForm.Owner = this; // Đặt Form chính làm chủ form bill
            billShowTimeForm.StartPosition = FormStartPosition.Manual;
            billShowTimeForm.Location = new Point(this.Right + 10, this.Top); // Đặt cạnh bên phải form ghế
            this.billShowTimeForm.LoadinfoMovie(); // load thong tin movie
            billShowTimeForm.Show();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            if(this.billShowTimeForm != null)
            {
                this.billShowTimeForm.Close();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.seatForShowTineUC1.Hide();
            this.panel_showTimes.Show();
            if (billShowTimeForm != null)
            {
                billShowTimeForm.Close();
            }
        }



        private void btn_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
            if (this.billShowTimeForm != null)
            {
                this.billShowTimeForm.Close();
            }
        }
    }
}
