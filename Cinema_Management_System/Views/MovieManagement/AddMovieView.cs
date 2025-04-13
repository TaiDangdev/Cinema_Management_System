using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinema_Management_System.ViewModels.MovieManagementVM;
using Cinema_Management_System.ViewModels.MovieManagementVM.Feature;
using Guna.UI2.WinForms;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using CsvHelper.Configuration.Attributes;

namespace Cinema_Management_System.Views.MovieManagement
{
    public partial class AddMovieView : Form
    {
        private MovieManagementViewModel viewModel;

        public AddMovieView()
        {
            InitializeComponent();
            startDateMovie_Txt.Value = DateTime.Today;

            viewModel = new MovieManagementViewModel();


            acceptMovie_Btn.DataBindings.Add("Enabled", viewModel, "CanAccept", true, DataSourceUpdateMode.OnPropertyChanged);

            titleError_Txt.DataBindings.Add("Text", viewModel, "TitleError", true, DataSourceUpdateMode.OnPropertyChanged);
            titleMovie_Txt.DataBindings.Add("Text", viewModel, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
           
            directorError_Txt.DataBindings.Add("Text", viewModel, "DirectorError", true, DataSourceUpdateMode.OnPropertyChanged);
            directorMovie_Txt.DataBindings.Add("Text", viewModel, "Director", true, DataSourceUpdateMode.OnPropertyChanged);

            lengthError_Txt.DataBindings.Add("Text", viewModel, "LengthError", true, DataSourceUpdateMode.OnPropertyChanged);
            lengthMovie_Txt.DataBindings.Add("Text", viewModel, "Length", true, DataSourceUpdateMode.OnPropertyChanged);

            priceError_Txt.DataBindings.Add("Text", viewModel, "ImportPriceError", true, DataSourceUpdateMode.OnPropertyChanged);
            priceMovie_Txt.DataBindings.Add("Text", viewModel, "ImportPrice", true, DataSourceUpdateMode.OnPropertyChanged);

            countryError_Txt.DataBindings.Add("Text", viewModel, "CountryError", true, DataSourceUpdateMode.OnPropertyChanged);
            countryMovie_Txt.DataBindings.Add("Text", viewModel, "Country", true, DataSourceUpdateMode.OnPropertyChanged);

            languageError_Txt.DataBindings.Add("Text", viewModel, "LanguageError", true, DataSourceUpdateMode.OnPropertyChanged);
            languageMovie_Txt.DataBindings.Add("Text", viewModel, "Language", true, DataSourceUpdateMode.OnPropertyChanged);

            trailerError_Txt.DataBindings.Add("Text", viewModel, "TrailerError", true, DataSourceUpdateMode.OnPropertyChanged);
            trailerMovie_Txt.DataBindings.Add("Text", viewModel, "Trailer", true, DataSourceUpdateMode.OnPropertyChanged);

            genreError_Txt.DataBindings.Add("Text", viewModel, "GenreError", true, DataSourceUpdateMode.OnPropertyChanged);
            genreMovie_Txt.DataBindings.Add("Text", viewModel, "Genre", true, DataSourceUpdateMode.OnPropertyChanged);

            descriptionError_Txt.DataBindings.Add("Text", viewModel, "DescriptionError", true, DataSourceUpdateMode.OnPropertyChanged);
            descriptionMovie_Txt.DataBindings.Add("Text", viewModel, "Description", true, DataSourceUpdateMode.OnPropertyChanged);

            releaseYearError_Txt.DataBindings.Add("Text", viewModel, "ReleaseYearError", true, DataSourceUpdateMode.OnPropertyChanged);
            releaseYearMovie_Txt.DataBindings.Add("Text", viewModel, "ReleaseYear", true, DataSourceUpdateMode.OnPropertyChanged);

            startDateMovie_Txt.DataBindings.Add("Value", viewModel, nameof(viewModel.StartDate), true, DataSourceUpdateMode.OnPropertyChanged);

            codeMovie_Txt.DataBindings.Add("Text", viewModel, "MovieCode", true, DataSourceUpdateMode.OnPropertyChanged);
            codeError_Txt.DataBindings.Add("Text", viewModel, "MovieCodeError", true, DataSourceUpdateMode.OnPropertyChanged);

            statusMovie_Txt.DataBindings.Add("SelectedItem", viewModel, "Status", true, DataSourceUpdateMode.OnPropertyChanged);

            var validationMap = new Dictionary<Guna2TextBox, string>
            {
                { titleMovie_Txt, "Title" },
                { descriptionMovie_Txt, "Description" },
                { directorMovie_Txt, "Director" },
                { lengthMovie_Txt, "Length" },
                { releaseYearMovie_Txt, "ReleaseYear" },
                { priceMovie_Txt, "ImportPrice" },
                { countryMovie_Txt, "Country" },
                { trailerMovie_Txt, "Trailer" },
                { genreMovie_Txt, "Genre" },
                { languageMovie_Txt, "Language" },
                { codeMovie_Txt, "MovieCode" }
            };

            foreach (var entry in validationMap)
            {
                entry.Key.Enter += (s, e) => { viewModel.SetIsFocused(entry.Value, true); };
                entry.Key.Leave += (s, e) => { viewModel.SetIsFocused(entry.Value, false); };
            }
        }

        private void chooseImage_Btn_Click(object sender, EventArgs e)
        {
            var image = viewModel.AddImage();
            if (image != null)
            {
                poster_Pic.Image = image;
                viewModel.ImageSource = image;
            }
        }

        private void acceptMovie_Btn_Click(object sender, EventArgs e)
        {
            viewModel.Accept();
            this.Close();
        }

        private void ReadCSV(string filePath)
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,  // Có dòng tiêu đề
                    Delimiter = ",",         // Dấu phân cách là dấu phẩy
                    TrimOptions = TrimOptions.Trim, // Xóa khoảng trắng dư thừa
                    IgnoreBlankLines = true  // Bỏ qua dòng trống
                };

                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<MovieData>().ToList();

                    if (records.Any())
                    {
                        var movie = records.First();
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
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Dữ liệu trong file không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importFilm_Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Chọn file dữ liệu",
                Filter = "CSV Files (*.csv)|*.csv",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ReadCSV(filePath);
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
        }

    }
}
