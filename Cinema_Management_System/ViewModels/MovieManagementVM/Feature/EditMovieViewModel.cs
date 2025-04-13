using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.MessageBox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Management_System.ViewModels.MovieManagementVM.Feature
{
    public partial class MovieManagementViewModel : MainBaseViewModel
    {
        //private MovieDA _movieDA = new MovieDA();

        public void loadMovieCurrent(DataGridView movie_data, int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < movie_data.Rows.Count)
            {
                try
                {
                    string movieTitle = movie_data.Rows[rowIndex].Cells["Title"].Value.ToString();

                    MovieDTO selectedMovie = _movieDA.GetAllMovies().FirstOrDefault(m => m.Title == movieTitle);

                    if (selectedMovie != null)
                    {
                        Title = selectedMovie.Title;
                        Description = selectedMovie.Description;
                        Director = selectedMovie.Director;
                        ReleaseYear = selectedMovie.ReleaseYear;
                        Language = selectedMovie.Language;
                        Country = selectedMovie.Country;
                        Length = selectedMovie.Length.ToString();
                        Trailer = selectedMovie.Trailer;
                        StartDate = DateTime.Parse(selectedMovie.StartDate);
                        Genre = selectedMovie.Genre;
                        Status = selectedMovie.Status;
                        ImageSource = selectedMovie.ImageSource;
                        ImportPrice = selectedMovie.ImportPrice.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin phim: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
