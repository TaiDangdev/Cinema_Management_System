using Cinema_Management_System.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using Cinema_Management_System.ViewModels;
using Cinema_Management_System.Views.MessageBox;
using Cinema_Management_System.ViewModels.MovieManagementVM.Feature;

namespace Cinema_Management_System.Models.DAOs
{
    public class MovieDA
    {
        ConnectDataContext connect = new ConnectDataContext();

        private static MovieDA instance;

        public static MovieDA Instance
        {
            get { if (MovieDA.instance == null) MovieDA.instance = new MovieDA(); return MovieDA.instance; }
            set { MovieDA.instance = value; }
        }

        private MovieDA() { }

        public List<MOVIE> GetMovieList()
        {
            List<MOVIE> MovieList = (from movie in connect.MOVIEs where movie.Status == "Đang phát hành"
                                     select movie).ToList();
            return MovieList;
        }


        public MOVIE GetMovieById(int id)
        {
            return connect.MOVIEs.FirstOrDefault(m => m.id == id);
        }

        // lấy DS tất cả movie
        public List<MovieDTO> GetAllMovies()
        {
            return connect.MOVIEs.Select(movie => new MovieDTO(
                movie.id,
                movie.MovieCode,
                movie.Title,
                movie.Description,
                movie.Director,
                movie.ReleaseYear.ToString(),
                movie.Language,
                movie.Country,
                movie.Length,
                movie.Trailer,
                movie.StartDate.ToString(),
                movie.EndDate.ToString(),
                movie.TotalShowtimes,
                movie.CurrentShowtimes,
                movie.Genre,    
                movie.Status,
                ImageVsSQL.ByteArrayToBitmap(movie.ImageSource.ToArray()),
                movie.ImportPrice
            )).ToList();
        }

        // add 1 movie
        public int addMovie(MovieDTO movieDTO)
        {
            MOVIE movie = new MOVIE
            {
                MovieCode = movieDTO.MovieCode,
                Title = movieDTO.Title,
                Description = movieDTO.Description,
                Director = movieDTO.Director,
                ReleaseYear = string.IsNullOrWhiteSpace(movieDTO.ReleaseYear) ? 0 : int.Parse(movieDTO.ReleaseYear),
                Language = movieDTO.Language,
                Country = movieDTO.Country,
                Length = movieDTO.Length,
                Trailer = movieDTO.Trailer,
                StartDate = string.IsNullOrWhiteSpace(movieDTO.StartDate) ? DateTime.MinValue : DateTime.Parse(movieDTO.StartDate),
                EndDate = string.IsNullOrWhiteSpace(movieDTO.EndDate) ? DateTime.MinValue : DateTime.Parse(movieDTO.EndDate),
                TotalShowtimes = movieDTO.TotalShowtimes,
                CurrentShowtimes = 0,
                Genre = movieDTO.Genre,
                Status = movieDTO.Status,
                ImageSource = movieDTO.ImageSource != null ? ImageVsSQL.BitmapToByteArray(movieDTO.ImageSource) : null,
                ImportPrice = movieDTO.ImportPrice
            };

            connect.MOVIEs.InsertOnSubmit(movie);
            connect.SubmitChanges();

            return movie.id;
        }

        // update(edit) movie
        public void editMovie(MovieDTO movieDTO)
        {
            try
            {
                var movie = connect.MOVIEs.FirstOrDefault(m => m.MovieCode == movieDTO.MovieCode);
                if (movie == null)
                {
                    throw new Exception("Không tìm thấy phim để cập nhật.");
                }

                movie.Title = movieDTO.Title;
                movie.Description = movieDTO.Description;
                movie.Director = movieDTO.Director;
                movie.ReleaseYear = string.IsNullOrWhiteSpace(movieDTO.ReleaseYear) ? 0 : int.Parse(movieDTO.ReleaseYear);
                movie.Language = movieDTO.Language;
                movie.Country = movieDTO.Country;
                movie.Length = movieDTO.Length;
                movie.Trailer = movieDTO.Trailer;
                movie.StartDate = string.IsNullOrWhiteSpace(movieDTO.StartDate) ? DateTime.MinValue : DateTime.Parse(movieDTO.StartDate);
                //movie.EndDate = string.IsNullOrWhiteSpace(movieDTO.EndDate) ? DateTime.MinValue : DateTime.Parse(movieDTO.EndDate);
                //movie.TotalShowtimes = movieDTO.TotalShowtimes;
                movie.Genre = movieDTO.Genre;
                movie.Status = movieDTO.Status;
                movie.ImageSource = movieDTO.ImageSource != null ? ImageVsSQL.BitmapToByteArray(movieDTO.ImageSource) : movie.ImageSource;
                movie.ImportPrice = movieDTO.ImportPrice;

                connect.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật phim: " + ex.Message);
            }
        }

        public bool UpdateMovie(MovieDTO movieDTO)
        {
            try
            {
                var movie = connect.MOVIEs.FirstOrDefault(m => m.id == movieDTO.Id);
                if (movie == null)
                {
                    MessageBoxHelper.ShowError("Lỗi", "Không tìm thấy phim để cập nhật.");
                    return false;
                }
                movie.EndDate = string.IsNullOrWhiteSpace(movieDTO.EndDate) ? DateTime.MinValue : DateTime.Parse(movieDTO.EndDate);
                movie.TotalShowtimes = movieDTO.TotalShowtimes;
                movie.ImportPrice = movieDTO.ImportPrice;

                connect.SubmitChanges();

                ExecuteUpdateMovieStatus();

                return true;
            }
            catch 
            {
                MessageBoxHelper.ShowError("Lỗi", "Lỗi khi cập nhật phim");
                return false;
            }
        }

        public void ExecuteUpdateMovieStatus()
        {
            try
            {
                connect.ExecuteCommand("EXEC sp_UpdateMovieStatus");
            }
            catch
            {
                MessageBoxHelper.ShowError("Lỗi", "Lỗi khi thực thi sp_UpdateMovieStatus");
            }
        }

        // delete 1 movie theo movieCode
        public void DeleteMovie(string movieCode)
        {
            var movie = connect.MOVIEs.FirstOrDefault(m => m.MovieCode == movieCode);
            if (movie == null)
            {
                MessageBoxHelper.ShowError("Lỗi","Không tìm thấy phim để xóa.");
            }
            connect.MOVIEs.DeleteOnSubmit(movie);
            connect.SubmitChanges();
        }

        // kiểm tra xem 1 movie có tồn tại hay chưa
        public bool IsMovieExist(MovieDTO movieDTO)
        {
            return connect.MOVIEs.Any(m => m.MovieCode == movieDTO.MovieCode);
        }

        // lọc phim theo trạng thái và từ người dùng tìm kiếm
        public List<MovieDTO> GetMovies(string statusFilter, string searchKeyword)
        {
            var movies = GetAllMovies();

            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "Tất cả")
            {
                movies = movies.Where(m => m.Status.Equals(statusFilter, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                searchKeyword = searchKeyword.RemoveVietnameseSigns();

                movies = movies.Where(m =>
                {
                    string normalizedTitle = m.Title.RemoveVietnameseSigns();
                    return normalizedTitle.Contains(searchKeyword) ||
                        SearchMovieHelper.LevenshteinDistance(normalizedTitle, searchKeyword) <= 3; // giới hạn khoảng cách tối đa là 3
                }).ToList();
            }

            return movies;
        }


        // lấy danh sách để phục vụ cho việc hiển thị thông báo
        public List<MovieNotificationDTO> GetNotificationMovies()
        {
            try
            {
                DateTime currentTime = DateTime.Now;
                DateTime sevenDaysFromNow = currentTime.AddDays(7);

                var movies = connect.MOVIEs
                    .Where(m =>
                        (m.Status == "Sắp phát hành" && m.StartDate >= currentTime && m.StartDate <= sevenDaysFromNow) ||
                        (m.Status == "Đang phát hành" &&
                            ((m.EndDate >= currentTime && m.EndDate <= sevenDaysFromNow) ||
                             ((m.TotalShowtimes - m.CurrentShowtimes) <= 10 && (m.TotalShowtimes - m.CurrentShowtimes) > 0))
                        ))
                    .Select(m => new MovieNotificationDTO
                    {
                        Title = m.Title,
                        Status = m.Status,
                        StartDate = m.StartDate,
                        EndDate = m.EndDate,
                        RemainingShowtimes = m.TotalShowtimes - m.CurrentShowtimes,
                        WarningMessage = ""
                    })
                    .ToList();

                foreach (var movie in movies)
                {
                    if (movie.Status == "Sắp phát hành")
                    {
                        int daysUntilStart = (movie.StartDate.Value - currentTime).Days;
                        if ((movie.StartDate.Value - currentTime).Hours > 0) daysUntilStart++;
                        movie.WarningMessage = $"Còn {daysUntilStart} ngày nữa sẽ phát hành";
                    }
                    else if (movie.Status == "Đang phát hành")
                    {
                        if (movie.RemainingShowtimes <= 10 && movie.RemainingShowtimes > 0)
                        {
                            movie.WarningMessage = $"Còn {movie.RemainingShowtimes} suất chiếu nữa sẽ ngưng chiếu";
                        }
                        else
                        {
                            int daysUntilEnd = (movie.EndDate.Value - currentTime).Days;
                            if ((movie.EndDate.Value - currentTime).Hours > 0) daysUntilEnd++;
                            movie.WarningMessage = $"Còn {daysUntilEnd} ngày nữa sẽ ngưng phát hành";
                        }
                    }
                }
                return movies;
            }
            catch
            {
                MessageBoxHelper.ShowError("Lỗi", "Lỗi khi lấy danh sách thông báo");
                return new List<MovieNotificationDTO>();
            }
        }

    }
}
