using Cinema_Management_System.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema_Management_System.ViewModels;

namespace Cinema_Management_System.Models.DAOs
{
    public class MovieDA
    {
        private ConnectDataContext db = new ConnectDataContext();

        // lấy danh sách tất cả các phim
        public List<MovieDTO> GetAllMovies()
        {
            try
            {
                return db.MOVIEs.Select(movie => new MovieDTO(
                    movie.id,
                    movie.Title,
                    movie.Description,
                    movie.Director,
                    movie.ReleaseYear.ToString(),
                    movie.Language,
                    movie.Country,
                    movie.Length,
                    movie.Trailer,
                    movie.StartDate.ToString(),
                    movie.Genre,
                    movie.Status,
                    ImageVsSQL.ByteArrayToBitmap(movie.ImageSource.ToArray()),
                    movie.ImportPrice
                )).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        // thêm một phim mới
        public void addMovie(MovieDTO movieDTO)
        {
            try
            {
                MOVIE movie = new MOVIE
                {
                    Title = movieDTO.Title,
                    Description = movieDTO.Description,
                    Director = movieDTO.Director,
                    ReleaseYear = int.Parse(movieDTO.ReleaseYear),
                    Language = movieDTO.Language,
                    Country = movieDTO.Country,
                    Length = movieDTO.Length,
                    Trailer = movieDTO.Trailer,
                    StartDate = DateTime.Parse(movieDTO.StartDate),
                    Genre = movieDTO.Genre,
                    Status = movieDTO.Status,
                    ImageSource = ImageVsSQL.BitmapToByteArray(movieDTO.ImageSource),
                    ImportPrice = movieDTO.ImportPrice
                };

                db.MOVIEs.InsertOnSubmit(movie);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
