using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Cinema_Management_System.Views.MovieManagement;
using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.MessageBox;
using System.Diagnostics;

namespace Cinema_Management_System.ViewModels.MovieManagementVM.Feature
{
    public partial class MovieManagementViewModel : MainBaseViewModel
    {
        private Dictionary<string, bool> _isFocusedMap = new Dictionary<string, bool>();
        private Dictionary<string, string> _errors = new Dictionary<string, string>();
        private bool checkImage = false;
        private MovieDA _movieDA = new MovieDA();

        public bool IsEditing { get; set; }

        // mã film
        private string movieCode;
        public string MovieCode
        {
            get => movieCode;
            set
            {
                movieCode = value;
                ValidateField(nameof(MovieCode));
            }
        }

        public string MovieCodeError => _errors.TryGetValue(nameof(MovieCode), out var error) ? error : "";

        //tiêu đề
        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                ValidateField(nameof(Title));

            }
        }
        public string TitleError => _errors.TryGetValue(nameof(Title), out var error) ? error : "";

        //chi tiết
        private string description;
        public string Description
        {
            get => description;
            set
            {
                description = value;
                ValidateField(nameof(Description));
            }
        }
        public string DescriptionError => _errors.TryGetValue(nameof(Description), out var error) ? error : "";

        private string genre;
        public string Genre
        {
            get => genre;
            set
            {
                genre = value;
                ValidateField(nameof(Genre));
            }
        }
        public string GenreError => _errors.TryGetValue(nameof(Genre), out var error) ? error : "";

        private string director;
        public string Director
        {
            get => director;
            set
            {
                director = value;
                ValidateField(nameof(Director));
            }
        }
        public string DirectorError => _errors.TryGetValue(nameof(Director), out var error) ? error : "";

        //năm phát hành
        private string releaseYear;
        public string ReleaseYear
        {
            get => releaseYear;
            set
            {
                releaseYear = value;
                ValidateField(nameof(ReleaseYear));
            }
        }
        public string ReleaseYearError => _errors.TryGetValue(nameof(ReleaseYear), out var error) ? error : "";

        //thời lượng
        //dùng string để nao xử lý lỗi người dùng
        private string length;
        public string Length
        {
            get => length;
            set
            {
                length = value;
                ValidateField(nameof(Length));
            }
        }
        public string LengthError => _errors.TryGetValue(nameof(Length), out var error) ? error : "";

        // giá nhập
        private string importPrice;
        public string ImportPrice
        {
            get => importPrice;
            set
            {
                importPrice = value;
                ValidateField(nameof(ImportPrice));
            }
        }
        public string ImportPriceError => _errors.TryGetValue(nameof(ImportPrice), out var error) ? error : "";

        //quốc gia
        private string country;
        public string Country
        {
            get => country;
            set
            {
                country = value;
                ValidateField(nameof(Country));
            }
        }
        public string CountryError => _errors.TryGetValue(nameof(Country), out var error) ? error : "";

        //ngôn ngữ
        private string language;
        public string Language
        {
            get => language;
            set
            {
                language = value;
                ValidateField(nameof(Language));
            }
        }
        public string LanguageError => _errors.TryGetValue(nameof(Language), out var error) ? error : "";

        //trailer
        private string trailer;
        public string Trailer
        {
            get => trailer;
            set
            {
                trailer = value;
                ValidateField(nameof(Trailer));
            }
        }
        public string TrailerError => _errors.TryGetValue(nameof(Trailer), out var error) ? error : "";

        //ngày bắt đầu
        private DateTime startDate = DateTime.Now;
        public DateTime StartDate
        {
            get => startDate;
            set
            {   
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        //trạng thái
        private string status ="Đang phát hành";
        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        //poster
        private Bitmap imageSource;
        public Bitmap ImageSource
        {
            get => imageSource;
            set
            {
                if (imageSource != value)
                {
                    imageSource = value;
                    OnPropertyChanged(nameof(ImageSource));
                    OnPropertyChanged(nameof(CanAccept));
                }
            }
        }

        public bool CanAccept => _errors.Values.All(e => string.IsNullOrWhiteSpace(e)) && checkImage;

        public void SetIsFocused(string field, bool isFocused)
        {
            _isFocusedMap[field] = isFocused;
            if (!isFocused)
            {
                _errors[field] = "";
            }
            else
            {
                ValidateField(field);
            }
            OnPropertyChanged($"{field}Error");
            OnPropertyChanged(nameof(CanAccept));
        }

        private void ValidateField(string field)
        {
            string value = GetPropertyValue(field);
            if (string.IsNullOrWhiteSpace(value))
            {
                _errors[field] = "*Không để trống!";
            }
            else if (IsNumberField(field) && (!int.TryParse(value, out int number) || number <= 0))
            {
                _errors[field] = "*Không hợp lệ!";
            }
            else
            {
                _errors[field] = "";
            }
            OnPropertyChanged($"{field}Error");
            OnPropertyChanged(nameof(CanAccept));
        }

        private string GetPropertyValue(string field)
        {
            var property = GetType().GetProperty(field);
            return property?.GetValue(this)?.ToString() ?? "";
        }

        private static readonly HashSet<string> NumberFields = new HashSet<string>
        {
            "ReleaseYear", "Length", "ImportPrice"
        };

        private bool IsNumberField(string field) => NumberFields.Contains(field);

        public MovieManagementViewModel(MovieDTO movie = null)
        {
            if (movie != null)
            {
                // Nếu có dữ liệu -> Chế độ Edit
                IsEditing = true;
                LoadMovieData(movie);
            }
            else
            {
                // Không có dữ liệu -> Chế độ Add
                IsEditing = false;
                StartDate = DateTime.Today; // Mặc định ngày hiện tại
            }
        }

        private void LoadMovieData(MovieDTO movie)
        {
            MovieCode = movie.MovieCode;
            Title = movie.Title;
            Description = movie.Description;
            Director = movie.Director;
            ReleaseYear = movie.ReleaseYear;
            Language = movie.Language;
            Country = movie.Country;
            Length = movie.Length.ToString();
            Trailer = movie.Trailer;
            Genre = movie.Genre;
            Status = movie.Status;
            ImageSource = movie.ImageSource;
            ImportPrice = movie.ImportPrice.ToString();
            StartDate = DateTime.Parse(movie.StartDate);
        }

        public void SaveMovie()
        {
            if (IsEditing)
            {
                // Chế độ Edit -> Cập nhật phim
                _movieDA.editMovie(new MovieDTO
                {
                    MovieCode = MovieCode,
                    Title = Title,
                    Description = Description,
                    Director = Director,
                    ReleaseYear = ReleaseYear,
                    Language = Language,
                    Country = Country,
                    Length = int.TryParse(Length, out int length) ? length : 0,
                    Trailer = Trailer,
                    Genre = Genre,
                    Status = Status,
                    ImageSource = ImageSource,
                    ImportPrice = int.TryParse(ImportPrice, out int importPrice) ? importPrice : 0,
                    StartDate = StartDate.ToString()
                });
            }
            else
            {
                // Chế độ Add -> Thêm phim mới
                _movieDA.addMovie(new MovieDTO
                {
                    MovieCode = MovieCode,
                    Title = Title,
                    Description = Description,
                    Director = Director,
                    ReleaseYear = ReleaseYear,
                    Language = Language,
                    Country = Country,
                    Length = int.TryParse(Length, out int length) ? length : 0,
                    Trailer = Trailer,
                    Genre = Genre,
                    Status = Status,
                    ImageSource = ImageSource,
                    ImportPrice = int.TryParse(ImportPrice, out int importPrice) ? importPrice : 0,
                    StartDate = StartDate.ToString()
                });
            }
        }

        public Bitmap AddImage()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*"
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    byte[] imageData = File.ReadAllBytes(openFileDialog.FileName);
                    checkImage = true;
                    OnPropertyChanged(nameof(CanAccept));
                    return ImageVsSQL.ByteArrayToBitmap(imageData);
                }
            }
            return null;
        }

        public void Accept()
        {
            if (!checkImage)
            {
                MessageBox.Show("Bạn chưa thêm poster!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string startDateStr = StartDate.ToString("yyyy-MM-dd");

            int movieLength, movieImportPrice;

            if (!int.TryParse(Length, out movieLength) || movieLength <= 0)
            {
                MessageBox.Show("Thời lượng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(ImportPrice, out movieImportPrice) || movieImportPrice < 0)
            {
                MessageBox.Show("Giá nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var movie = new MovieDTO(MovieCode,Title, Description, Director, ReleaseYear, Language, Country,
                movieLength, Trailer, startDateStr, Genre, Status, ImageSource, movieImportPrice);

            new MovieDA().addMovie(movie);

            //new YesMessage("Thông báo", "Thêm phim thành công").ShowDialog();
        }
    }
}
