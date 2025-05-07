using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.MessageBox;
using Cinema_Management_System.Models.DAOs.Bills;
using Guna.UI2.WinForms;

namespace Cinema_Management_System.Views.MovieManagement
{
    public partial class MovieManagementView : UserControl
    {
        private List<MovieNotificationDTO> notifications;
        private bool isNotificationVisible = false;
        public MovieManagementView()
        {
            InitializeComponent();
            LoadMovies();
            notification_Panel.Visible = false;
        }

        public void LoadMovies()
        {
            moviePanel.Controls.Clear();
            notifications = MovieDA.Instance.GetNotificationMovies();

            notificationPainter.Text = notifications.Count.ToString();
            notificationPainter.Visible = notifications.Count > 0;

            string searchText = searchMovie_Txt.Text.Trim().ToLower();
            string selectedFilter = filterMovie_Cbx.SelectedItem.ToString();

            List<MovieDTO> movies = MovieDA.Instance.GetMovies(selectedFilter, searchText);

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

        private Button CreateMoreOptionsButton(MovieDTO movie, Panel parentPanel)
        {
            Button btnMoreOptions = new Button
            {
                Width = 20,
                Height = 20,
                BackgroundImage = Properties.Resources.icons8_more_24,
                BackgroundImageLayout = ImageLayout.Zoom,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnMoreOptions.FlatAppearance.BorderSize = 0;

            ContextMenuStrip menu = new ContextMenuStrip
            {
                Renderer = new CustomMenuRenderer(),
                ShowImageMargin = false, 
                BackColor = Color.White, 
            };

            menu.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            //menu.Items.Add("✏ Chỉnh sửa", null, (s, e) => EditMovie(movie));
            menu.Items.Add("🗑 Xóa", null, (s, e) => DeleteMovie(movie));
            menu.Items.Add("⏳ Gia hạn", null, (s, e) => ExtendMovie(movie));
            btnMoreOptions.Click += (s, e) => menu.Show(Cursor.Position);

            return btnMoreOptions;
        }

        public class CustomMenuRenderer : ToolStripProfessionalRenderer
        {
            public CustomMenuRenderer() : base(new CustomColorTable()) { }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                if (e.Item.Selected)
                {
                    e.TextColor = Color.White; 
                }
                else
                {
                    e.TextColor = Color.Black;
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
                AutoEllipsis = true
            };
        }

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

        private void OpenMovieDetail(MovieDTO movie)
        {
            if (Application.OpenForms["MovieDetailView"] == null)
            {
                MovieDetailView movieDetailView = new MovieDetailView(movie)
                {
                    Opacity = 0
                };
                movieDetailView.Show();

                Timer fadeTimer = new Timer { Interval = 10 };
                fadeTimer.Tick += (s, args) =>
                {
                    if (movieDetailView.Opacity < 1)
                    {
                        movieDetailView.Opacity += 0.05;
                    }
                    else
                    {
                        fadeTimer.Stop();
                    }
                };
                fadeTimer.Start();
            }
            else
            {
                Application.OpenForms["MovieDetailView"].Activate();
            }
        }

        //private void EditMovie(MovieDTO movie)
        //{
        //    if (Application.OpenForms["EditMovieView"] == null)
        //    {
        //        EditMovieView editMovieView = new EditMovieView(movie)
        //        {
        //            Opacity = 0
        //        };
        //        editMovieView.Show();

        //        Timer fadeTimer = new Timer { Interval = 10 };
        //        fadeTimer.Tick += (s, args) =>
        //        {
        //            if (editMovieView.Opacity < 1)
        //            {
        //                editMovieView.Opacity += 0.05;
        //            }
        //            else
        //            {
        //                fadeTimer.Stop();
        //            }
        //        };
        //        fadeTimer.Start();
        //        editMovieView.FormClosed += (s, args) => LoadMovies();
        //    }
        //    else
        //    {
        //        Application.OpenForms["EditMovieView"].Activate();
        //    }
        //}

        private void ExtendMovie(MovieDTO movie)
        {
            if (Application.OpenForms["ExtendMovieView"] == null)
            {
                ExtendMovieView extendMovieView = new ExtendMovieView(movie)
                {
                    Opacity = 0
                };
                extendMovieView.Show();

                Timer fadeTimer = new Timer { Interval = 10 };
                fadeTimer.Tick += (s, args) =>
                {
                    if (extendMovieView.Opacity < 1)
                    {
                        extendMovieView.Opacity += 0.05;
                    }
                    else
                    {
                        fadeTimer.Stop();
                    }
                };
                fadeTimer.Start();
                extendMovieView.FormClosed += (s, args) => LoadMovies();
            }
            else
            {
                Application.OpenForms["ExtendMovieView"].Activate();
            }
        }

        private void DeleteMovie(MovieDTO movie)
        {
            if(ShowTimeDA.Instance.checkShowTimeByMovie(movie.Id))
            {
                MessageBoxHelper.ShowError("Lỗi", "Phim đang có trong ít nhất 1 suất chiếu,bạn không được phép xóa!");
                return;
            }

            BillAddMovieDA.Instance.updateMovie_IdNull(movie.Id);

            DialogResult result = MessageBoxHelper.ShowQuestion("Xóa phim", "Bạn có chắc chắn muốn xóa phim này không?");
            if (result == DialogResult.Yes)
            {
                MovieDA.Instance.DeleteMovie(movie.MovieCode);
                MessageBoxHelper.ShowSuccess("Thành công", "Xóa phim thành công!");
                LoadMovies();
            }
            else
            {
                return;
            }
        }

        private void addMovie_Btn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AddMovieView"] == null)
            {
                AddMovieView addMovieView = new AddMovieView();

                addMovieView.Opacity = 0;
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
                addMovieView.FormClosed += (s, args) => LoadMovies();
            }
            else
            {
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

        private void notification_Btn_Click(object sender, EventArgs e)
        {
            if (notifications == null || notifications.Count == 0)
            {
                MessageBoxHelper.ShowInfo("Thông báo", "Không có phim nào cần cảnh báo!");
                if (isNotificationVisible)
                {
                    isNotificationVisible = false;
                }
                return;
            }

            isNotificationVisible = !isNotificationVisible;
            notification_Panel.Visible = isNotificationVisible;

            if (isNotificationVisible)
            {
                notification_Panel.Controls.Clear();

                foreach (var notification in notifications)
                {
                    Guna2Panel notificationItem = CreateNotificationPanel(notification);
                    notification_Panel.Controls.Add(notificationItem);
                }

                int notificationHeight = notifications.Count * 70;
                int maxHeight = 263; 
                int newHeight = Math.Min(notificationHeight, maxHeight);

                notification_Panel.Height = newHeight;
            }
        }

        private Guna2Panel CreateNotificationPanel(MovieNotificationDTO notification)
        {
            Guna2Panel notificationItem = new Guna2Panel
            {
                Width = 243,
                Height = 60,
                Margin = new Padding(5),
                BorderRadius = 8,
                FillColor = Color.FromArgb(255, 255, 240),
                BorderColor = Color.FromArgb(200, 200, 200),
                BorderThickness = 1,
                ShadowDecoration = { Enabled = true, Depth = 5 }
            };

            Image iconImage;
            Color hoverColor;
            if (notification.Status == "Sắp phát hành")
            {
                iconImage = Properties.Resources.icon_Info;
                hoverColor = Color.FromArgb(200, 230, 255); 
            }
            else
            {
                iconImage = Properties.Resources.icon_Warning;
                hoverColor = Color.FromArgb(255, 220, 200); 
            }

            Guna2PictureBox icon = new Guna2PictureBox
            {
                Size = new Size(20, 20),
                Location = new Point(10, 10),
                Image = iconImage,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            Label titleLabel = new Label
            {
                Text = notification.Title,
                AutoSize = false,
                Width = 150,
                Height = 20,
                Location = new Point(35, 10),
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.FromArgb(50, 50, 50),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoEllipsis = true
            };

            Label messageLabel = new Label
            {
                Text = notification.WarningMessage,
                AutoSize = false,
                Width = 205,
                Height = 20,
                Location = new Point(35, 30),
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.FromArgb(80, 80, 80),
                Font = new Font("Segoe UI", 8, FontStyle.Regular),
                AutoEllipsis = true
            };

            notificationItem.MouseEnter += (s, e) =>
            {
                notificationItem.FillColor = hoverColor;
            };
            notificationItem.MouseLeave += (s, e) =>
            {
                notificationItem.FillColor = Color.FromArgb(255, 255, 240);
            };

            notificationItem.Controls.Add(icon);
            notificationItem.Controls.Add(titleLabel);
            notificationItem.Controls.Add(messageLabel);

            return notificationItem;
        }
    }
}
