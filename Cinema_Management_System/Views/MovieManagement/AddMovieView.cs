using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DAOs.Bills;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Models.DTOs.Bills;
using Cinema_Management_System.Views.MessageBox;
using ClosedXML.Excel;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Cinema_Management_System.Views.MovieManagement
{
    public partial class AddMovieView : Form
    {
        private Bitmap posterImage;
        private bool isImageSelected = false;
        private Dictionary<Control, Label> errorMap;
        private Guna2ShadowForm shadowForm;
        public AddMovieView()
        {
            InitializeComponent();
            SetupUI();
            InitValidation();
        }

        private void SetupUI()
        {
            startDateMovie_Txt.Value = DateTime.Today;
            endMovie_Txt.Value = DateTime.Today.AddDays(14);
            acceptMovie_Btn.Enabled = false;
            DragHelper.EnableDrag(this, control_Panel);
            shadowForm = new Guna2ShadowForm
            {
                ShadowColor = Color.Black,
                BorderRadius = 20
            };
            shadowForm.SetShadowForm(this);

            startDateMovie_Txt.ValueChanged += (s, e) => UpdateMovieStatus();
            UpdateMovieStatus();
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
                { codeMovie_Txt, codeError_Txt },
                { showTime_Txt, showTimeError_Txt },
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

            if (control == showTime_Txt && (!decimal.TryParse(text, out decimal total) || total <= 0))
            {
                return "*Giá trị không hợp lệ!";
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

            if (endMovie_Txt.Value.Date < startDateMovie_Txt.Value.Date)
            {
                MessageBoxHelper.ShowError("Lỗi", "Ngày kết thúc không được trước ngày khởi chiếu!");
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

        private void UpdateMovieStatus()
        {
            DateTime startDate = startDateMovie_Txt.Value.Date;
            DateTime endDate = endMovie_Txt.Value.Date;
            DateTime today = DateTime.Today;

            if (endDate < today)
                statusMovie_Txt.Text = "Ngưng phát hành";
            else if (startDate <= today && today <= endDate)
                statusMovie_Txt.Text = "Đang phát hành";
            else
                statusMovie_Txt.Text = "Sắp phát hành";
        }

        private void CheckAllFieldsValid()
        {
            bool allValid = errorMap.All(entry => string.IsNullOrEmpty(GetErrorMessage(entry.Key))) && isImageSelected;
            acceptMovie_Btn.Enabled = allValid;
        }

        private void chooseImage_Btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog { Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    posterImage = new Bitmap(dialog.FileName);
                    poster_Pic.Image = posterImage;
                    isImageSelected = true;
                    CheckAllFieldsValid();
                }
            }
        }

        private void acceptMovie_Btn_Click(object sender, EventArgs e)
        {
            if (!ValidateMovieInput()) return;

            var movieDTO = GetMovieDTOFromForm();

            if (MovieDA.Instance.IsMovieExist(movieDTO))
            {
                MessageBoxHelper.ShowError("Lỗi", "Phim đã tồn tại. Vui lòng kiểm tra lại mã phim.");
                return;
            }

            int newMovieId = MovieDA.Instance.addMovie(movieDTO);
            BillAddMovieDA.Instance.addBill(new BillAddMovieDTO
            (
                newMovieId,
                DateTime.Now.ToString("yyyy-MM-dd"),
                movieDTO.ImportPrice
            ));

            MessageBoxHelper.ShowSuccess("Thông báo", "Thêm phim thành công!");
            this.Close();
        }

        private MovieDTO GetMovieDTOFromForm()
        {
            return new MovieDTO
            {
                MovieCode = codeMovie_Txt.Text.Trim(),
                Title = titleMovie_Txt.Text.Trim(),
                Director = directorMovie_Txt.Text.Trim(),
                Length = int.Parse(lengthMovie_Txt.Text.Trim()),
                Country = countryMovie_Txt.Text.Trim(),
                Language = languageMovie_Txt.Text.Trim(),
                ReleaseYear = releaseYearMovie_Txt.Text.Trim(),
                Trailer = trailerMovie_Txt.Text.Trim(),
                Genre = genreMovie_Txt.Text.Trim(),
                Description = descriptionMovie_Txt.Text.Trim(),
                Status = statusMovie_Txt.Text.Trim(),
                ImportPrice = int.Parse(priceMovie_Txt.Text.Replace(",", "").Trim()),
                StartDate = startDateMovie_Txt.Value.ToString(),
                EndDate = endMovie_Txt.Value.ToString(),
                TotalShowtimes = int.Parse(showTime_Txt.Text.Replace(",", "").Trim()),
                ImageSource = posterImage
            }; 
        }

        private void ReadCSV(string filePath)
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    Delimiter = ",",
                    TrimOptions = TrimOptions.Trim,
                    IgnoreBlankLines = true
                };

                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<MovieData>().ToList();
                    if (records.Any())
                        BindMovieToForm(records.First());
                    else
                        MessageBoxHelper.ShowError("Lỗi", "Dữ liệu trong file không hợp lệ!");
                }
            }
            catch
            {
               MessageBoxHelper.ShowError("Lỗi","Lỗi khi đọc file CSV");
            }
        }

        private void BindMovieToForm(MovieData movie)
        {
            codeMovie_Txt.Text = movie.MovieCode;
            titleMovie_Txt.Text = movie.Title;
            directorMovie_Txt.Text = movie.Director;
            lengthMovie_Txt.Text = movie.Length;
            countryMovie_Txt.Text = movie.Country;
            languageMovie_Txt.Text = movie.Language;
            releaseYearMovie_Txt.Text = movie.ReleaseYear;
            trailerMovie_Txt.Text = movie.Trailer;
            genreMovie_Txt.Text = movie.Genre;
            descriptionMovie_Txt.Text = movie.Description;
            priceMovie_Txt.Text = movie.Price.ToString("N0");
            showTime_Txt.Text = movie.TotalShowtimes.ToString("N0");

            string[] formats = { "d/M/yyyy", "dd/MM/yyyy", "M/d/yyyy", "MM/dd/yyyy", "yyyy-MM-dd", };

            if (DateTime.TryParseExact(movie.ReleaseDate, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var startDate))
            {
                startDateMovie_Txt.Value = startDate;
            }

            if (DateTime.TryParseExact(movie.EndDate, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var endDate))
            {
                endMovie_Txt.Value = endDate;
            }

            UpdateMovieStatus();
        }

        private void ReadExcel(string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rowCount = worksheet.LastRowUsed().RowNumber();

                    string[] formats = { "d/M/yyyy", "dd/MM/yyyy", "M/d/yyyy", "MM/dd/yyyy", "yyyy-MM-dd"};

                    for (int row = 2; row <= rowCount; row++)
                    {
                        var movie = ExtractMovieFromExcel(worksheet, row);
                        BindMovieToForm(movie);
                        if (!DateTime.TryParseExact(movie.ReleaseDate,
                            formats, 
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out var releaseDate))
                        {
                            MessageBoxHelper.ShowWarning("Cảnh báo", $"Dòng {row}: Ngày không hợp lệ: {movie.ReleaseDate}");
                        }
                        else
                        {
                            startDateMovie_Txt.Value = releaseDate;
                        }
                       
                        movie.EndDate = movie.EndDate.Split(' ')[0];
                        if (!DateTime.TryParseExact(movie.EndDate,
                            formats,
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out var endDate))
                        {
                            MessageBoxHelper.ShowWarning("Cảnh báo", $"Dòng {row}: Ngày kết thúc không hợp lệ: {movie.EndDate}");
                        }
                        else
                        {
                            endMovie_Txt.Value = endDate;
                        }
                    }
                }
            }
            catch
            {
                MessageBoxHelper.ShowError("Lỗi","Lỗi khi đọc file Excel");
            }
        }

        private MovieData ExtractMovieFromExcel(IXLWorksheet worksheet, int row)
        {
            return new MovieData
            {
                MovieCode = worksheet.Cell(row, 1).GetString(),
                Title = worksheet.Cell(row, 2).GetString(),
                Director = worksheet.Cell(row, 3).GetString(),
                Length = worksheet.Cell(row, 4).GetString(),
                Country = worksheet.Cell(row, 5).GetString(),
                Language = worksheet.Cell(row, 6).GetString(),
                ReleaseYear = worksheet.Cell(row, 7).GetString(),
                Trailer = worksheet.Cell(row, 8).GetString(),
                Genre = worksheet.Cell(row, 9).GetString(),
                Description = worksheet.Cell(row, 10).GetString(),
                ReleaseDate = worksheet.Cell(row, 11).GetString(),
                EndDate = worksheet.Cell(row, 12).GetString(),
                TotalShowtimes = int.TryParse(worksheet.Cell(row, 13).GetString(), out var showTimes) ? showTimes : 0,
                Price = decimal.TryParse(worksheet.Cell(row, 14).GetString(), out var price) ? price : 0
            };
        }

        private void importFilm_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Chọn file dữ liệu",
                Filter = "CSV Files & Excel Files|*.csv;*.xlsx",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                if (filePath.EndsWith(".csv"))
                    ReadCSV(filePath);
                else if (filePath.EndsWith(".xlsx"))
                    ReadExcel(filePath);
                MessageBoxHelper.ShowSuccess("Thông báo", "Dữ liệu đã được thêm thành công!");
            }
        }

        public class MovieData
        {
            [Name("Mã film")] public string MovieCode { get; set; }
            [Name("Tên phim")] public string Title { get; set; }
            [Name("Đạo diễn")] public string Director { get; set; }
            [Name("Thời lượng")] public string Length { get; set; }
            [Name("Quốc gia")] public string Country { get; set; }
            [Name("Ngôn ngữ")] public string Language { get; set; }
            [Name("Năm phát hành")] public string ReleaseYear { get; set; }
            [Name("Trailer")] public string Trailer { get; set; }
            [Name("Thể loại")] public string Genre { get; set; }
            [Name("Giới thiệu")] public string Description { get; set; }
            [Name("Ngày khởi chiếu")] public string ReleaseDate { get; set; }
            [Name("Ngày kết thúc chiếu")] public string EndDate { get; set; }
            [Name("Số suất chiếu")] public decimal TotalShowtimes { get; set; }
            [Name("Giá nhập")] public decimal Price { get; set; }
        }

        private void AddMovieView_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => codeMovie_Txt.Focus()));
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            foreach (var control in errorMap.Keys) control.Text = string.Empty;
            startDateMovie_Txt.Value = DateTime.Today;
            poster_Pic.Image = null;
            posterImage = null;
            isImageSelected = false;
            HideAllErrorLabels();
            acceptMovie_Btn.Enabled = false;
            codeMovie_Txt.Focus();
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
