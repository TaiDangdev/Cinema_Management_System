using Cinema_Management_System.ViewModels.MovieManagementVM.Feature;
using Cinema_Management_System.Views.MovieManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.ViewModels.MovieManagementVM
{
    public partial class MovieManagementViewModel : MainBaseViewModel
    {
        public MovieManagementViewModel()
        {
        }

        public void AddMovie()
        {
            AddMovieView addMovieView = new AddMovieView();
            addMovieView.ShowDialog();
        }


    }
}
