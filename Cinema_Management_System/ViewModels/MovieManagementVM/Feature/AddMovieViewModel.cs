using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO; // dùng để xử lý ảnh từ file
using Cinema_Management_System.Views.MovieManagement;
using System.Windows.Forms;
using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.MessageBox;
using System.ComponentModel;

namespace Cinema_Management_System.ViewModels.MovieManagementVM.Feature
{
    public partial class MovieManagementViewModel
    {
        private void AddMovie()
        {
            AddMovieView addMovieView = new AddMovieView();
            addMovieView.ShowDialog();
        }
    }

    public class AddMovieViewModel : MainBaseViewModel
    {
        private ConnectDataContext db = new ConnectDataContext();
        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                ValidateTitle();

            }
        }

        private bool isFocused = false;
        public bool IsFocused
        {
            get => isFocused;
            set
            {
                isFocused = value;
                OnPropertyChanged(nameof(IsFocused));
            }
        }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string ReleaseYear { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Length { get; set; }
        public string Trailer { get; set; }
        public DateTime? StartDate { get; set; }
        public string Status { get; set; }
        public string ImportPrice { get; set; }
        public string DescriptionError { get; set; }
        public string DirectorError { get; set; }
        public string ReleaseYearError { get; set; }
        public string LanguageError { get; set; }
        public string CountryError { get; set; }
        public string LengthError { get; set; }
        public string TrailerError { get; set; }
        public string ImportPriceError { get; set; }

        private AddMovieView addMovieView;

        public AddMovieViewModel(AddMovieView addMovieView)
        {
            this.addMovieView = addMovieView;
            StartDate = DateTime.Now;
            Status = "Đang phát hành";
        }

        private bool checkImage = false;

        public void accept()
        {
            if (!checkImage)
            {
                MessageBox.Show("Bạn chưa thêm poster!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MovieDA movieDA = new MovieDA();
            movieDA.addMovie(new MovieDTO(Title, Description, Director, ReleaseYear, Language, Country, int.Parse(Length), Trailer, StartDate.Value.ToString("yyyy-MM-dd"), Genre, Status, ImageSource, int.Parse(ImportPrice)));

            YesMessage mb = new YesMessage("Thông báo", "Thêm phim thành công");
            mb.ShowDialog();
            addMovieView.Close();
        }

        private Bitmap _imageSource;
        public Bitmap ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged(nameof(ImageSource)); // thông báo rằng ImageSource đã thay đổi
            }
        }

        public void addImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] imageData = File.ReadAllBytes(openFileDialog.FileName);
                ImageSource = ImageVsSQL.ByteArrayToBitmap(imageData); // khi ImageSource thay đổi, UI sẽ tự cập nhật
            }
        }

        private string titleError;
        public string TitleError
        {
            get => titleError;
            set
            {
                titleError = value;
                OnPropertyChanged(nameof(TitleError));
            }
        }


        // phần các hàm validate _ báo lỗi
        private bool[] _canAccept = new bool[9];//phục vụ việc có cho nhấn button accept ko
        public bool CanAccept
        {
            get => _canAccept.All(x => x); // Kiểm tra tất cả điều kiện hợp lệ
        }
        public void ValidateTitle()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                TitleError = "Không để trống!";
                _canAccept[0] = false;
            }
            else
            {
                TitleError = "";
                _canAccept[0] = true;
            }
            OnPropertyChanged(nameof(CanAccept));
            OnPropertyChanged(nameof(TitleError));
        }

        public void ValidateDescription()
        {
            if (string.IsNullOrWhiteSpace(Description))
            {
                DescriptionError = "Không để trống!";
                _canAccept[1] = false;
            }
            else
            {
                DescriptionError = "";
                _canAccept[1] = true;
            }
            OnPropertyChanged(nameof(CanAccept));
        }

        public void ValidateDirector()
        {
            if (string.IsNullOrWhiteSpace(Director))
            {
                DirectorError = "Không để trống!";
                _canAccept[2] = false;
            }
            else
            {
                DirectorError = "";
                _canAccept[2] = true;
            }
            OnPropertyChanged(nameof(CanAccept));
        }

        public void ValidateLength()
        {
            if (string.IsNullOrWhiteSpace(Length))
            {
                LengthError = "Không để trống!";
                _canAccept[3] = false;
            }
            else if (!Length.All(char.IsDigit))
            {
                LengthError = "Không hợp lệ!";
                _canAccept[3] = false;
            }
            else if (!int.TryParse(Length, out int lengthvalue))
            {
                LengthError = "Không hợp lệ!";
                _canAccept[3] = false;
            }
            else
            {
                LengthError = "";
                _canAccept[3] = true;
            }
            OnPropertyChanged(nameof(CanAccept));
        }

        public void ValidateLanguage()
        {
            if (string.IsNullOrWhiteSpace(Language))
            {
                LanguageError = "Không để trống!";
                _canAccept[4] = false;
            }
            else if (Language.Length > 20)
            {
                LanguageError = "Không được dài quá";
                _canAccept[4] = false;
            }
            else
            {
                LanguageError = "";
                _canAccept[4] = true;
            }
            OnPropertyChanged(nameof(CanAccept));
        }

        public void ValidateCountry()
        {
            if (string.IsNullOrWhiteSpace(Country))
            {
                CountryError = "Không để trống!";
                _canAccept[5] = false;
            }
            else
            {
                CountryError = "";
                _canAccept[5] = true;
            }
            OnPropertyChanged(nameof(CanAccept));
        }

        public void ValidateTrailer()
        {
            if (string.IsNullOrWhiteSpace(Trailer))
            {
                TrailerError = "Không để trống!";
                _canAccept[6] = false;
            }
            else
            {
                TrailerError = "";
                _canAccept[6] = true;
            }
            OnPropertyChanged(nameof(CanAccept));
        }
        public void ValidateReleaseYear()
        {
            if (string.IsNullOrWhiteSpace(ReleaseYear))
            {
                ReleaseYearError = "Không để trống!";
                _canAccept[7] = false;
            }
            else if (!ReleaseYear.All(char.IsDigit))
            {
                ReleaseYearError = "Không hợp lệ!";
                _canAccept[7] = false;
            }
            else if (int.Parse(ReleaseYear) < 0)
            {
                ReleaseYearError = "Không hợp lệ!";
                _canAccept[7] = false;
            }
            else
            {
                ReleaseYearError = "";
                _canAccept[7] = true;
            }
            OnPropertyChanged(nameof(CanAccept));
        }
        public void ValidateImportPrice()
        {
            if (string.IsNullOrWhiteSpace(ImportPrice))
            {
                ImportPriceError = "Không để trống!";
                _canAccept[8] = false;
            }
            else if (!ImportPrice.All(char.IsDigit))
            {
                ImportPriceError = "Không hợp lệ!";
                _canAccept[8] = false;
            }
            else if (!int.TryParse(ImportPrice, out int importPriceValue))
            {
                ImportPriceError = "Không hợp lệ!";
                _canAccept[8] = false;
            }
            else
            {
                ImportPriceError = "";
                _canAccept[8] = true;
            }
            OnPropertyChanged(nameof(CanAccept));
        }

    }
}
