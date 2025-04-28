//using Cinema_Management_System.Models.DTOs.Bills;
//using System;
//using System.Globalization;
//using System.Linq;

//namespace Cinema_Management_System.Models.DAOs.Bills
//{
//    public class BillAddMovieDA
//    {
//        ConnectDataContext Connect = new ConnectDataContext();

//        private static BillAddMovieDA instance;

//        public static BillAddMovieDA Instance
//        {
//            get { if (instance == null) BillAddMovieDA.instance = new BillAddMovieDA(); return BillAddMovieDA.instance; }
//            set { BillAddMovieDA.instance = value; }
//        }

//        private BillAddMovieDA() { }

//        // add 1 bill
//        public void addBill(BillAddMovieDTO billAddMovieDTO)
//        {
//            var newBill = new Bill_AddMovie{
//                Movie_Id = billAddMovieDTO.Movie_Id,
//                BillDate = DateTime.ParseExact(
//                    billAddMovieDTO.BillDate,
//                    new[] { "d/M/yyyy", "dd/MM/yyyy", "M/d/yyyy", "MM/dd/yyyy", "yyyy-MM-dd" },
//                    CultureInfo.InvariantCulture,
//                    DateTimeStyles.None
//                ),
//                Total = billAddMovieDTO.Total
//            };
//            Connect.Bill_AddMovies.InsertOnSubmit(newBill);
//            Connect.SubmitChanges();
//        }

//        // hỗ trợ xóa 1 movie cập nhật movieId của bill liên quan bằng null
//        public void updateMovie_IdNull(int movieId)
//        {
//            var bills = Connect.Bill_AddMovies.Where(b => b.Movie_Id == movieId).ToList();

//            foreach (var bill in bills)
//            {
//                bill.Movie_Id = null;
//            }

//            Connect.SubmitChanges();
//        }

//    }
//}
