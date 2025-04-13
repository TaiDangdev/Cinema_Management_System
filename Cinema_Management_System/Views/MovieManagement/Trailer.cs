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
    public partial class Trailer : Form
    {
        public Trailer(string youtubeUrl)
        {
            InitializeComponent();
            LoadTrailer(youtubeUrl);
        }

        private void LoadTrailer(string youtubeUrl)
        {
            webView21.Source = new Uri(youtubeUrl);
        }

        private void Trailer_FormClosing(object sender, FormClosingEventArgs e)
        {
            webView21.Dispose(); // Giải phóng tài nguyên WebView2
        }
    }
}
