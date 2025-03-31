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

namespace Cinema_Management_System.Views.MovieManagement
{
    public partial class AddMovieView : Form
    {
        private AddMovieViewModel viewModel;


        // Image: thuộc tính của pictureBox
        // viewModel đối tượng chứa dữ liệu liên kết
        // ImageSource thuộc tính viewModel để liên kết với Image
        // true cho phép cập nhật ngay khi dữ liệu thay đổi
        // DataSourceUpdateMode.OnPropertyChanged khi ImageSoure thay đổi ,UI sẽ tự động cập nhật
        public AddMovieView()
        {
            InitializeComponent();
            viewModel = new AddMovieViewModel(this);            
            poster_Pic.DataBindings.Add("Image", viewModel, "ImageSource", true, DataSourceUpdateMode.OnPropertyChanged);
            acceptMovie_Btn.DataBindings.Add("Enabled", viewModel, "CanAccept", true, DataSourceUpdateMode.OnPropertyChanged);
            label14.DataBindings.Add("Text", viewModel, "TitleError", true, DataSourceUpdateMode.OnPropertyChanged);
            titleMovie_txt.DataBindings.Add("Text", viewModel, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
            //titleMovie_txt.TextChanged += (s, e) => viewModel.ValidateTitle();
            var validationMap = new Dictionary<Control, Action>
            {
                { titleMovie_txt, () => viewModel.ValidateTitle() },
             };
            foreach (var entry in validationMap)
            {
                entry.Key.Enter += (s, e) => { viewModel.IsFocused = true; entry.Value(); };
                entry.Key.Leave += (s, e) => { viewModel.IsFocused = false; entry.Value(); };
            }
        }

        private void chooseImage_Btn_Click(object sender, EventArgs e)
        {
            viewModel.addImage();
        }

        private void acceptMovie_Btn_Click(object sender, EventArgs e)
        {

        }

    }
}
