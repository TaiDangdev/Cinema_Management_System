using Cinema_Management_System.Models.DTOs;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;
using Cinema_Management_System.Views.MessageBox;

namespace Cinema_Management_System.Views.MovieManagement
{
    public partial class MovieDetailView : Form
    {
        private Guna2ShadowForm shadowForm;

        public MovieDetailView(MovieDTO movie)
        {
            InitializeComponent();
            LoadMovieDetails(movie);
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

        private void LoadMovieDetails(MovieDTO movie)
        {
            titleMovie_Txt.Text = movie.Title;
            titleMovie_Txt.TextAlign = ContentAlignment.MiddleCenter;
            titleMovie_Txt.MaximumSize = new Size(poster_Pic.Width, 0);
            titleMovie_Txt.AutoSize = true;

            codeMovie_Txt.Text = movie.MovieCode;
            movieLength_Txt.Text = movie.Length.ToString();
            movieStatus_Txt.Text = movie.Status;
            genreMovie_Txt.Text = movie.Genre;
            descriptionMovie_Txt.Text = movie.Description;
            directorMovie_Txt.Text = movie.Director;
            yearMovie_Txt.Text = movie.ReleaseYear;
            languageMovie_Txt.Text = movie.Language;
            movieCountry_Txt.Text = movie.Country;
            totalShowTime_Txt.Text = movie.TotalShowtimes.ToString();
            currentShowTime_Txt.Text = movie.CurrentShowtimes.ToString();
            if (DateTime.TryParse(movie.StartDate, out DateTime parsedDate))
            {
                startDateMovie_Txt.Text = parsedDate.ToString("dd/MM/yyyy");
            }
            if (DateTime.TryParse(movie.EndDate, out DateTime endDate))
            {
                endDate_Txt.Text = endDate.ToString("dd/MM/yyyy");
            }
            trailerMovie_Txt.Text = movie.Trailer;
            priceMovie_Txt.Text = movie.ImportPrice.ToString("N0");

            if (movie.ImageSource != null)
            {
                poster_Pic.Image = movie.ImageSource;
            }

            titleMovie_Txt.Location = new Point(
                poster_Pic.Location.X + (poster_Pic.Width / 2) - (titleMovie_Txt.Width / 2),
                titleMovie_Txt.Location.Y
            );
        }

        private void trailer_btn_Click(object sender, EventArgs e)
        {
            string url = trailerMovie_Txt.Text.Trim();
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBoxHelper.ShowWarning("Cảnh báo", "Vui lòng nhập đường dẫn trailer!");
                return;
            }

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch
            {
                MessageBoxHelper.ShowError("Lỗi", "Không thể mở trình duyệt");
            }
        }
    }
}
