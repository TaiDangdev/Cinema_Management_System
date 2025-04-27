using Cinema_Management_System.ViewModels.MovieManagementVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.MessageBox;
using Cinema_Management_System.ViewModels.MovieManagementVM.Feature;
using Cinema_Management_System.ViewModels;

namespace Cinema_Management_System.Views.MovieManagement
{
    public partial class MovieManagementView : UserControl
    {
        private MovieDA _movieDA;

        public MovieManagementView()
        {
            InitializeComponent();
            _movieDA = new MovieDA();
            LoadMovies();
        }

        /// <summary>
        /// Load dữ liệu film
        /// </summary>
        private void LoadMovies()
        {
            moviePanel.Controls.Clear();

            string searchText = searchMovie_Txt.Text.Trim().ToLower();

            string selectedFilter = filterMovie_Cbx.SelectedItem.ToString();

            List<MovieDTO> movies = _movieDA.GetAllMovies();

            // Áp dụng bộ lọc theo trạng thái (Đang phát hành / Ngưng phát hành)
            if (selectedFilter == "Ngưng phát hành")
            {
                movies = movies.Where(m => m.Status == "Ngưng phát hành").ToList();
            }
            else if (selectedFilter == "Đang phát hành")
            {
                movies = movies.Where(m => m.Status == "Đang phát hành").ToList();
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                //var fuzzySearch = new FuzzyStringComparer();
                //movies = movies.Where(m => fuzzySearch.Equals(m.Title, searchText, StringComparison.OrdinalIgnoreCase)).ToList();

                //movies = movies.Where(m => m.Title.ToLower().Contains(searchText)).ToList();
                movies = movies.Where(m => m.Title.ToLower().StartsWith(searchText.ToLower())).ToList();
            }

            foreach (var movie in movies)
            {
                Panel movieItem = CreateMoviePanel(movie);
                Label title = CreateMovieTitleLabel(movie.Title);
                Button movieButton = CreateMovieButton(movie);
                Button btnMoreOptions = CreateMoreOptionsButton(movie, movieItem);

                SetupHoverEffect(movieButton,title, btnMoreOptions); 

                btnMoreOptions.Top = 0;
                btnMoreOptions.Left = movieButton.Width - btnMoreOptions.Width - 10;
                movieButton.Top = btnMoreOptions.Bottom + 10; 
                title.Top = movieButton.Bottom + 5; 
                btnMoreOptions.Visible = false;


                movieItem.Controls.Add(title);
                movieItem.Controls.Add(movieButton);
                movieItem.Controls.Add(btnMoreOptions); 

                moviePanel.Controls.Add(movieItem);
            }
        }

        /// <summary>
        /// Tạo Panel chứa phim
        /// </summary>
        private Panel CreateMoviePanel(MovieDTO movie)
        {
            return new Panel
            {
                Width = 220,
                Height = 360,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.None
            };

        }

        /// <summary>
        /// Tạo nút More Options với menu chuột phải
        /// </summary>
        private Button CreateMoreOptionsButton(MovieDTO movie, Panel parentPanel)
        {
            Button btnMoreOptions = new Button
            {
                Width = 20,
                Height = 20,
                BackgroundImage = Properties.Resources.icons8_more_24, // Icon dấu ba chấm
                BackgroundImageLayout = ImageLayout.Zoom,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnMoreOptions.FlatAppearance.BorderSize = 0;

            ContextMenuStrip menu = new ContextMenuStrip
            {
                Renderer = new CustomMenuRenderer(), // Áp dụng Renderer để thay đổi UI
                ShowImageMargin = false, // Ẩn lề hình ảnh mặc định
                BackColor = Color.White, // Màu nền
            };

            menu.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            menu.Items.Add("✏ Chỉnh sửa", null, (s, e) => EditMovie(movie));
            menu.Items.Add("🗑 Xóa", null, (s, e) => DeleteMovie(movie));

            //ToolStripMenuItem editItem = new ToolStripMenuItem("✏ Chỉnh sửa", Properties.Resources.icons8_edit_24, (s, e) => EditMovie(movie));
            //ToolStripMenuItem deleteItem = new ToolStripMenuItem("🗑 Xóa", Properties.Resources.icons8_delete_24, (s, e) => DeleteMovie(movie));

            //menu.Items.Add(editItem);
            //menu.Items.Add(deleteItem);

            btnMoreOptions.Click += (s, e) => menu.Show(Cursor.Position);


            //ContextMenuStrip menu = new ContextMenuStrip();
            //menu.Items.Add("✏ Chỉnh sửa", null, (s, e) => EditMovie(movie));
            //menu.Items.Add("🗑 Xóa", null, (s, e) => DeleteMovie(movie));

            //btnMoreOptions.Click += (s, e) => menu.Show(Cursor.Position);

            return btnMoreOptions;
        }

        public class CustomMenuRenderer : ToolStripProfessionalRenderer
        {
            public CustomMenuRenderer() : base(new CustomColorTable()) { }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                if (e.Item.Selected)
                {
                    e.TextColor = Color.White; // Màu chữ khi hover
                }
                else
                {
                    e.TextColor = Color.Black; // Màu chữ mặc định
                }
                base.OnRenderItemText(e);
            }
        }

        public class CustomColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(203, 45, 62); // Màu khi hover
            public override Color MenuItemBorder => Color.FromArgb(239, 71, 58); // Viền khi hover
            public override Color ToolStripDropDownBackground => Color.White; // Màu nền chính
            public override Color MenuBorder => Color.LightGray; // Viền ngoài của menu
        }

        /// <summary>
        /// Tạo Label tiêu đề phim
        /// </summary>
        private Label CreateMovieTitleLabel(string titleText)
        {
            return new Label
            {
                Text = titleText,
                AutoSize = false,
                Width = 220,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Padding = new Padding(5),
                AutoEllipsis = true // Tự động thu gọn khi quá dài
            };
        }

        /// <summary>
        /// Tạo Button chứa ảnh poster
        /// </summary>
        private Button CreateMovieButton(MovieDTO movie)
        {
            Button movieButton = new Button
            {
                Width = 220,
                Height = 260,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                BackgroundImage = movie.ImageSource,
                BackgroundImageLayout = ImageLayout.Zoom,
                Cursor = Cursors.Hand
            };
            movieButton.FlatAppearance.BorderSize = 0;

            movieButton.Click += (s, e) => OpenMovieDetail(movie);

            return movieButton;
        }

        /// <summary>
        /// Thêm hiệu ứng phóng to ảnh khi hover
        /// </summary>
        private void SetupHoverEffect(Button movieButton, Label titleLabel, Button btnMoreOptions)
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
                btnMoreOptions.Visible = true;
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
                btnMoreOptions.Visible = false;
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

        /// <summary>
        /// Mở giao diện hiển thị thông tin chi tiết
        /// </summary>
        private void OpenMovieDetail(MovieDTO movie)
        {
            MovieDetailView movieDetailView = new MovieDetailView(movie);
            movieDetailView.ShowDialog();
        }

   

        /// <summary>
        /// Mở giao diện chỉnh sửa phim
        /// </summary>
        private void EditMovie(MovieDTO movie)
        {
            EditMovieView editMovieView = new EditMovieView(movie);
            editMovieView.ShowDialog();
            LoadMovies();
        }

        /// <summary>
        /// Xóa phim khỏi danh sách
        /// </summary>
        private void DeleteMovie(MovieDTO movie)
        {
            // Hiển thị hộp thoại xác nhận xóa phim
            DialogResult result = System.Windows.Forms.MessageBox.Show($"Bạn có chắc chắn muốn xóa phim '{movie.Title}' không?",
                                                  "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Gọi phương thức xóa phim từ MovieDA
                    _movieDA.DeleteMovie(movie.MovieCode);

                    // Hiển thị thông báo thành công
                    //YesMessage msgBox = new YesMessage("Thông báo", "Xóa phim thành công!");
                    //msgBox.ShowDialog();

                    // Tải lại danh sách phim sau khi xóa
                    LoadMovies();
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                    System.Windows.Forms.MessageBox.Show("Lỗi khi xóa phim: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addMovie_Btn_Click(object sender, EventArgs e)
        {
            //AddMovieView addMovieView = new AddMovieView();
            //addMovieView.ShowDialog();
            ////loadData();
            //LoadMovies();

            if (Application.OpenForms["AddMovieView"] == null)
            {
                AddMovieView addMovieView = new AddMovieView();

                addMovieView.Opacity = 0; // Bắt đầu từ mờ
                addMovieView.Show();

                Timer fadeTimer = new Timer { Interval = 10 };
                fadeTimer.Tick += (s, args) =>
                {
                    if (addMovieView.Opacity < 1)
                    {
                        addMovieView.Opacity += 0.05;
                    }
                    else
                    {
                        fadeTimer.Stop();
                    }
                };
                fadeTimer.Start();

                // Nếu bạn vẫn muốn load lại danh sách sau khi form đóng:
                addMovieView.FormClosed += (s, args) => LoadMovies();
            }
            else
            {
                // Nếu form đã mở, chỉ cần kích hoạt lại form
                Application.OpenForms["AddMovieView"].Activate();
            }
        }

        private void filterMovie_Cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMovies();
        }

        private void searchMovie_Txt_TextChanged(object sender, EventArgs e)
        {
            LoadMovies();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MovieManagementView_Load(object sender, EventArgs e)
        {

        }

        private void moviePanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
