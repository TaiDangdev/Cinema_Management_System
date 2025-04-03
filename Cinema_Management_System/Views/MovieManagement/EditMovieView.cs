using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.ViewModels.MovieManagementVM.Feature;
using Guna.UI2.WinForms;
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
    public partial class EditMovieView : Form
    {
        private MovieManagementViewModel viewModel;

        public EditMovieView(MovieDTO movie = null)
        {
            InitializeComponent();


            viewModel = new MovieManagementViewModel(movie);


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
                { languageMovie_Txt, "Language" }
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

        }
    }
}
