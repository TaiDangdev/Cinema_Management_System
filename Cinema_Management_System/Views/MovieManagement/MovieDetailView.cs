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

namespace Cinema_Management_System.Views.MovieManagement
{
    public partial class MovieDetailView : Form
    {
        public MovieDetailView(MovieDTO movie)
        {
            InitializeComponent();
            LoadMovieDetails(movie);
        }

        private void LoadMovieDetails(MovieDTO movie)
        {
            titleMovie_Txt.Text = movie.Title;
            titleMovie_Txt.TextAlign = ContentAlignment.MiddleCenter; // Căn giữa nội dung
            titleMovie_Txt.MaximumSize = new Size(poster_Pic.Width, 0); // Giới hạn chiều rộng theo poster
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
            if (DateTime.TryParse(movie.StartDate, out DateTime parsedDate))
            {
                startDateMovie_Txt.Text = parsedDate.ToString("dd/MM/yyyy");
            }
            //startDateMovie_Txt.Text = movie.StartDate;
            trailerMovie_Txt.Text = movie.Trailer;
            priceMovie_Txt.Text = movie.ImportPrice.ToString("N0");

            if (movie.ImageSource != null)
            {
                poster_Pic.Image = movie.ImageSource;
            }

            // Căn giữa titleMovie_Txt giữa poster_Pic và phần còn lại
            titleMovie_Txt.Location = new Point(
                poster_Pic.Location.X + (poster_Pic.Width / 2) - (titleMovie_Txt.Width / 2),
                titleMovie_Txt.Location.Y
            );
        }

        private void trailerMovie_Txt_Click(object sender, EventArgs e)
        {
            string trailerUrl = trailerMovie_Txt.Text.Trim();

            // Kiểm tra nếu đường dẫn trailer hợp lệ
            if (!string.IsNullOrEmpty(trailerUrl) && trailerUrl.Contains("youtube.com"))
            {
                Trailer trailerForm = new Trailer(trailerUrl);
                trailerForm.ShowDialog(); // Mở form mới hiển thị video
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("URL trailer không hợp lệ hoặc không phải video YouTube.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
