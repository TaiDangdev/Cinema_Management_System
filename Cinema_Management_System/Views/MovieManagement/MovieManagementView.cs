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
using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.MessageBox;
using Cinema_Management_System.ViewModels.MovieManagementVM.Feature;

namespace Cinema_Management_System.Views.MovieManagement
{
    public partial class MovieManagementView : UserControl
    {
        private MovieDA _movieDA;

        public MovieManagementView()
        {
            InitializeComponent();
            _movieDA = new MovieDA();
            loadData();
        }

        private void addMovie_Btn_Click(object sender, EventArgs e)
        {
            AddMovieView addMovieView = new AddMovieView();
            addMovieView.ShowDialog();
            loadData();
        }

        public void loadData()  
        {
            try
            {
                List<MovieDTO> movies = _movieDA.GetAllMovies();

                movie_data.DataSource = movies.Select(m => new
                {
                    m.Title,
                    m.Status,
                    m.Length
                }).ToList();
                update_col.Image = Properties.Resources.update_icon; 
                update_col.ImageLayout = DataGridViewImageCellLayout.Zoom;

                delete_col.Image = Properties.Resources.delete_icon; 
                delete_col.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }
            catch (Exception ex)
            {
                new YesMessage("Thông báo", "Lỗi khi tải dữ liệu: " + ex.Message).ShowDialog();
            }
        }

        private void movie_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (movie_data.Columns[e.ColumnIndex].Name == "update_col")
                {
                    string movieTitle = movie_data.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                    MovieDTO selectedMovie = _movieDA.GetAllMovies().FirstOrDefault(m => m.Title == movieTitle);

                    if (selectedMovie != null)
                    {
                        EditMovieView editMovieView = new EditMovieView(selectedMovie); // Truyền dữ liệu -> Chế độ Edit
                        editMovieView.ShowDialog();
                        loadData();
                    }
                }
            }
        }

        private void movie_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
