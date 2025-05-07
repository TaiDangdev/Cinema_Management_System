using Cinema_Management_System.Models.DTOs;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Cinema_Management_System.Views.MessageBox;
using Cinema_Management_System.Models.DAOs;
using System.Globalization;

namespace Cinema_Management_System.Views.MovieManagement
{
    public partial class EditMovieView : Form
    {
        private Guna2ShadowForm shadowForm;
        private Bitmap posterImage;
        private Dictionary<Control, Label> errorMap;

        private MovieDTO movie;

        public EditMovieView(MovieDTO movie = null)
        {
            InitializeComponent();
            this.movie = movie;
            loadMovieFilm(movie);
            SetupUI();
            InitValidation();
        }

        private void SetupUI()
        {
            startDateMovie_Txt.Value = DateTime.Today;
            DragHelper.EnableDrag(this, control_Panel);
            shadowForm = new Guna2ShadowForm
            {
                ShadowColor = Color.Black,
                BorderRadius = 20
            };
            shadowForm.SetShadowForm(this);
        }

        private void InitValidation()
        {
            errorMap = new Dictionary<Control, Label>
            {
                { titleMovie_Txt, titleError_Txt },
                { directorMovie_Txt, directorError_Txt },
                { lengthMovie_Txt, lengthError_Txt },
                { priceMovie_Txt, priceError_Txt },
                { countryMovie_Txt, countryError_Txt },
                { languageMovie_Txt, languageError_Txt },
                { releaseYearMovie_Txt, releaseYearError_Txt },
                { trailerMovie_Txt, trailerError_Txt },
                { genreMovie_Txt, genreError_Txt },
                { descriptionMovie_Txt, descriptionError_Txt },
                { codeMovie_Txt, codeError_Txt }
            };

            foreach (var entry in errorMap)
            {
                var textBox = entry.Key;
                textBox.TextChanged += (s, e) =>
                {
                    ValidateSingleField(textBox);
                    CheckAllFieldsValid();
                };

                textBox.Leave += (s, e) =>
                {
                    ValidateSingleField(textBox);
                    if (decimal.TryParse(priceMovie_Txt.Text, out var price) && price > 0)
                    {
                        priceMovie_Txt.Text = price.ToString("N0");
                    }
                };
            }

            HideAllErrorLabels();
        }

        private void HideAllErrorLabels()
        {
            foreach (var entry in errorMap)
            {
                entry.Value.Visible = false;
            }
        }

        private void ClearError(Control control)
        {
            if (errorMap.TryGetValue(control, out Label errorLabel))
            {
                errorLabel.Text = "";
                errorLabel.Visible = false;
            }
        }

        private void ValidateSingleField(Control control)
        {
            string error = GetErrorMessage(control);

            if (errorMap.TryGetValue(control, out Label label))
            {
                if (string.IsNullOrWhiteSpace(control.Text))
                {
                    error = "*Không được để trống!";
                }

                if (string.IsNullOrEmpty(error))
                {
                    ClearError(control);
                }
                else
                {
                    label.Text = error;
                    label.Visible = true;
                }
            }
        }

        private string GetErrorMessage(Control control)
        {
            string text = control.Text.Trim();

            if (string.IsNullOrWhiteSpace(text))
            {
                return "*Không được để trống!";
            }

            if (control == lengthMovie_Txt)
            {
                if (!int.TryParse(text, out int length) || length <= 0)
                {
                    return "*Giá trị không hợp lệ!";
                }
                if (length > 300)
                {
                    return "*Thời lượng quá 300 phút!";
                }
            }

            if (control == priceMovie_Txt && (!decimal.TryParse(text, out decimal price) || price <= 0))
            {
                return "*Giá trị không hợp lệ!";
            }

            if (control == releaseYearMovie_Txt)
            {
                if (!int.TryParse(text, out int year) || year < 1900 || year > DateTime.Now.Year)
                    return "*Năm phát hành không hợp lệ!";
            }

            if (control == trailerMovie_Txt)
            {
                if (!Uri.TryCreate(text, UriKind.Absolute, out Uri uriResult) ||
                    !(uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                    return "*Đường dẫn không hợp lệ!";
            }

            if (control == descriptionMovie_Txt && text.Length > 1000)
            {
                return "*Giới thiệu không quá 1000 ký tự!";
            }

            return string.Empty;
        }

        private bool ValidateMovieInput()
        {
            if (statusMovie_Txt.Text.Trim() != "Ngưng phát hành" && startDateMovie_Txt.Value.Date < DateTime.Now.Date)
            {
                MessageBoxHelper.ShowError("Lỗi", "Ngày khởi chiếu không được ở quá khứ!");
                return false;
            }

            foreach (string genre in genreMovie_Txt.Text.Split(','))
            {
                if (string.IsNullOrWhiteSpace(genre))
                {
                    MessageBoxHelper.ShowError("Lỗi", "Không được để trống thể loại phim giữa các dấu phẩy.");
                    return false;
                }
            }

            return true;
        }

        private void CheckAllFieldsValid()
        {
            bool allValid = errorMap.All(entry => string.IsNullOrEmpty(GetErrorMessage(entry.Key)));
            acceptMovie_Btn.Enabled = allValid;
        }

        private void loadMovieFilm(MovieDTO movie)
        {
            titleMovie_Txt.Text = movie.Title;
            codeMovie_Txt.Text = movie.MovieCode;
            lengthMovie_Txt.Text = movie.Length.ToString();
            genreMovie_Txt.Text = movie.Genre;
            descriptionMovie_Txt.Text = movie.Description;
            directorMovie_Txt.Text = movie.Director;
            releaseYearMovie_Txt.Text = movie.ReleaseYear;
            languageMovie_Txt.Text = movie.Language;
            countryMovie_Txt.Text = movie.Country;
            System.Windows.Forms.MessageBox.Show(movie.StartDate, "Start Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (DateTime.TryParseExact(movie.StartDate, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedStartDate))
            {
                startDateMovie_Txt.Value = parsedStartDate;
            }
            else
            {
                startDateMovie_Txt.Value = DateTime.Today;
            }
            //startDateMovie_Txt.Value = DateTime.TryParse(movie.StartDate, out DateTime parsedDate) ? parsedDate : DateTime.Now;
            trailerMovie_Txt.Text = movie.Trailer;
            priceMovie_Txt.Text = movie.ImportPrice.ToString("N0");

            if (movie.ImageSource != null)
            {
                poster_Pic.Image = movie.ImageSource;
            }
        }

        private void resetFilm_Btn_Click(object sender, EventArgs e)
        {
            loadMovieFilm(movie);
            MessageBoxHelper.ShowInfo("Thông báo", "Đã khôi phục dữ liệu thành công");
        }

        private void UpdateMovieFromInput()
        {
            movie.Title = titleMovie_Txt.Text.Trim();
            movie.MovieCode = codeMovie_Txt.Text.Trim();
            movie.Length = int.TryParse(lengthMovie_Txt.Text.Trim(), out int length) ? length : 0;
            movie.Genre = genreMovie_Txt.Text.Trim();
            movie.Description = descriptionMovie_Txt.Text.Trim();
            movie.Director = directorMovie_Txt.Text.Trim();
            movie.ReleaseYear = releaseYearMovie_Txt.Text.Trim();
            movie.Language = languageMovie_Txt.Text.Trim();
            movie.Country = countryMovie_Txt.Text.Trim();
            movie.StartDate = startDateMovie_Txt.Value.ToString("yyyy-MM-dd");
            movie.Trailer = trailerMovie_Txt.Text.Trim();
            movie.ImportPrice = int.TryParse(priceMovie_Txt.Text.Replace(",", ""), out int price) ? price : 0;

            if (poster_Pic.Image != null)
            {
                movie.ImageSource = new Bitmap(poster_Pic.Image);
            }
        }

        private void chooseImage_Btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog { Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    posterImage = new Bitmap(dialog.FileName);
                    poster_Pic.Image = posterImage;
                    CheckAllFieldsValid();
                }
            }
        }

        private void acceptMovie_Btn_Click(object sender, EventArgs e)
        {
            if (!ValidateMovieInput()) return;

            UpdateMovieFromInput();


            if (!MovieDA.Instance.IsMovieExist(movie))
            {
                MessageBoxHelper.ShowError("Lỗi", "Phim đã không tồn tại!");
                return;
            }

            DialogResult result = MessageBoxHelper.ShowQuestion("Thông báo", "Bạn có chắc chắn muốn cập nhật phim này không?");

            if (result != DialogResult.Yes) return;
            MovieDA.Instance.editMovie(movie);
            MessageBoxHelper.ShowInfo("Thông báo", "Cập nhật phim thành công!");
            this.Close();
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
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Lỗi", "Không thể mở trình duyệt: " + ex.Message);
            }
        }
    }
}
