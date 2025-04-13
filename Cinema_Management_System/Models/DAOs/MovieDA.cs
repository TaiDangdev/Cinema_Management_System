using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Models.DAOs
{
    public class MovieDA
    {
        ConnectDataContext Connect = new ConnectDataContext();

        private static MovieDA instance;

        public static MovieDA Instance {
            get { if (MovieDA.instance == null) MovieDA.instance = new MovieDA(); return MovieDA.instance; }
            set { MovieDA.instance = value; }
        }

        private MovieDA() { }

        //lay danh sach phim
        public List<MOVIE> GetMovieList()
        {
            List<MOVIE> MovieList=Connect.MOVIEs.ToList();
            return MovieList;
        }

        public MOVIE GetMovieById(int id)
        {
            return Connect.MOVIEs.FirstOrDefault(m => m.id == id);
        }

    }
}
