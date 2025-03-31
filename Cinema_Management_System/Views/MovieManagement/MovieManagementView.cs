using Cinema_Management_System.ViewModels.MovieManagementVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Management_System.Views.MovieManagement
{
    public partial class MovieManagementView : UserControl
    {
        private MovieManagementViewModel viewModel;

        public MovieManagementView()
        {
            // view model sẽ quản lý dữ liệu và logic xử lý
            viewModel = new MovieManagementViewModel();
            InitializeComponent();
        }

        private void addMovie_Btn_Click(object sender, EventArgs e)
        {
            viewModel.AddMovie();
        }
    }
}
