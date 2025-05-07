using Cinema_Management_System.Views.MessageBox;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cinema_Management_System.Models.DAOs
{
    public class StatisticDA
    {
        ConnectDataContext Connect = new ConnectDataContext();

        private static StatisticDA instance;

        public static StatisticDA Instance
        {
            get { if (instance == null) StatisticDA.instance = new StatisticDA(); return StatisticDA.instance; }
            set { StatisticDA.instance = value; }
        }


        public Dictionary<string, int> GetTopMovie(int year)
        {
            var result = (from bill in Connect.Bills
                          join st in Connect.ShowTimes on bill.ShowTime_Id equals st.Id
                          join movie in Connect.MOVIEs on st.Movie_Id equals movie.id
                          where st.StartTime.Year == year || year == 0
                          group bill by movie.Title into g
                          select new
                          {
                              MovieTile = g.Key,
                              TotalRevenue = g.Sum(b => b.Total)
                          }
                          ).OrderByDescending(x => x.TotalRevenue)
                          .ToList();
            var Top5 = result.Take(5).ToDictionary(x => x.MovieTile, x => x.TotalRevenue);
            var otherRevernue = result.Skip(5).Sum(x => x.TotalRevenue);
            if (otherRevernue > 0)
            {
                Top5.Add("Khac", otherRevernue);
            }
            return Top5;
        }


        public Dictionary<string, int> GetTopMovie(int month, int year)
        {
            var result = (from bill in Connect.Bills
                          join st in Connect.ShowTimes on bill.ShowTime_Id equals st.Id
                          join movie in Connect.MOVIEs on st.Movie_Id equals movie.id
                          where (bill.BillDate.Year == year || year == 0) && (bill.BillDate.Month == month || month == 0)
                          group bill by movie.Title into g
                          select new
                          {
                              MovieTile = g.Key,
                              TotalRevenue = g.Sum(b => b.Total)
                          }
                          ).OrderByDescending(x => x.TotalRevenue)
                          .ToList();
            var Top5 = result.Take(5).ToDictionary(x => x.MovieTile, x => x.TotalRevenue);
            var otherRevernue = result.Skip(5).Sum(x => x.TotalRevenue);
            if (otherRevernue > 0)
            {
                Top5.Add("Khac", otherRevernue);
            }
            return Top5;
        }


        public Dictionary<string, int> GetTopMovieByDateRange(DateTime fromDate, DateTime toDate)
        {
            var result = (from bill in Connect.Bills
                          join st in Connect.ShowTimes on bill.ShowTime_Id equals st.Id
                          join movie in Connect.MOVIEs on st.Movie_Id equals movie.id
                          where bill.BillDate >= fromDate && bill.BillDate <= toDate
                          group bill by movie.Title into g
                          select new
                          {
                              MovieTitle = g.Key,
                              TotalRevenue = g.Sum(b => b.Total)
                          })
                          .OrderByDescending(x => x.TotalRevenue)
                          .ToList();

            var Top5 = result.Take(5).ToDictionary(x => x.MovieTitle, x => x.TotalRevenue);
            var otherRevenue = result.Skip(5).Sum(x => x.TotalRevenue);

            if (otherRevenue > 0)
            {
                Top5.Add("Khác", otherRevenue);
            }

            return Top5;
        }


        // 
        public Dictionary<string, int> GetTopGenre(int year)
        {
            var result = (from bill in Connect.Bills
                          join st in Connect.ShowTimes on bill.ShowTime_Id equals st.Id
                          join movie in Connect.MOVIEs on st.Movie_Id equals movie.id
                          where st.StartTime.Year == year || year == 0
                          group bill by movie.Genre into g
                          select new
                          {
                              MovieTile = g.Key,
                              TotalRevenue = g.Sum(b => b.QuantityTicket)
                          }
                          ).OrderByDescending(x => x.TotalRevenue)
                          .ToList();
            var Top5 = result.Take(5).ToDictionary(x => x.MovieTile, x => x.TotalRevenue);
            var otherRevernue = result.Skip(5).Sum(x => x.TotalRevenue);
            if (otherRevernue > 0)
            {
                Top5.Add("Khac", otherRevernue);
            }

            return Top5;
        }

        public Dictionary<string, int> GetTopGenreByDateRange(DateTime fromDate, DateTime toDate)
        {
            var result = (from bill in Connect.Bills
                          join st in Connect.ShowTimes on bill.ShowTime_Id equals st.Id
                          join movie in Connect.MOVIEs on st.Movie_Id equals movie.id
                          where bill.BillDate >= fromDate && bill.BillDate <= toDate
                          group bill by movie.Genre into g
                          select new
                          {
                              MovieTile = g.Key,
                              TotalRevenue = g.Sum(b => b.QuantityTicket)
                          }
                          ).OrderByDescending(x => x.TotalRevenue)
                          .ToList();
            var Top5 = result.Take(5).ToDictionary(x => x.MovieTile, x => x.TotalRevenue);
            var otherRevernue = result.Skip(5).Sum(x => x.TotalRevenue);
            if (otherRevernue > 0)
            {
                Top5.Add("Khac", otherRevernue);
            }

            return Top5;
        }

        public Dictionary<string, int> GetTopGenre(int month, int year)
        {
            var result = (from bill in Connect.Bills
                          join st in Connect.ShowTimes on bill.ShowTime_Id equals st.Id
                          join movie in Connect.MOVIEs on st.Movie_Id equals movie.id
                          where (bill.BillDate.Year == year || year == 0) && (bill.BillDate.Month == month || month == 0)
                          group bill by movie.Genre into g
                          select new
                          {
                              MovieTile = g.Key,
                              TotalRevenue = g.Sum(b => b.QuantityTicket)
                          }
                          ).OrderByDescending(x => x.TotalRevenue)
                          .ToList();
            var Top5 = result.Take(5).ToDictionary(x => x.MovieTile, x => x.TotalRevenue);
            var otherRevernue = result.Skip(5).Sum(x => x.TotalRevenue);
            if (otherRevernue > 0)
            {
                Top5.Add("Khac", otherRevernue);
            }

            return Top5;
        }


        // 3. Thống kê doanh thu và chi phí theo từng tháng trong năm
        public List<(int Month, decimal Revenue)> GetRevenueByMonth(int year)
        {
            var result = (from bill in Connect.Bills
                          join st in Connect.ShowTimes on bill.ShowTime_Id equals st.Id
                          join movie in Connect.MOVIEs on st.Movie_Id equals movie.id
                          where st.StartTime.Year == year || year == 0
                          group bill by bill.BillDate.Month into g
                          select new
                          {
                              Month = g.Key,
                              Revenue = g.Sum(b => b.QuantityTicket)
                          }).ToList();

            var monthlyData = new List<(int, decimal)>();
            for (int i = 1; i <= 12; i++)
            {
                var data = result.FirstOrDefault(r => r.Month == i);
                monthlyData.Add((i, data?.Revenue ?? 0));
            }

            return monthlyData;

        }


        public long GetExpenseByTime (int month,int year)
        {
            var result = (from billAddMovie in Connect.Bill_AddMovies
                          where (billAddMovie.BillDate.Year == year || year == 0) && (billAddMovie.BillDate.Month == month || month == 0)
                          select (long?)billAddMovie.Total
                         ).Sum() ?? 0;
            //MessageBoxHelper.ShowInfo("Thong bao", result.ToString());
            return result;
        }

        public long GetExpenseByTime(DateTime fromDate, DateTime toDate)
        {
            var result = (from billAddMovie in Connect.Bill_AddMovies
                          where (billAddMovie.BillDate > fromDate) && (billAddMovie.BillDate < toDate)
                          select (long?)billAddMovie.Total
                         ).Sum() ?? 0;
            //MessageBoxHelper.ShowInfo("Thong bao", result.ToString());
            return result;
        }

        public Dictionary<string,long> GetTicketCountBySlot(int month, int year)
        {
            // Định nghĩa các khung giờ
            var timeSlots = new List<(TimeSpan Start, TimeSpan End, string Label)>
                {
                        (TimeSpan.FromHours(0),  TimeSpan.FromHours(4), "00:00 - 04:00"),
                        (TimeSpan.FromHours(7),  TimeSpan.FromHours(10), "07:00 - 10:00"),
                        (TimeSpan.FromHours(10), TimeSpan.FromHours(13), "10:00 - 13:00"),
                        (TimeSpan.FromHours(13), TimeSpan.FromHours(16), "13:00 - 16:00"),
                        (TimeSpan.FromHours(16), TimeSpan.FromHours(19), "16:00 - 19:00"),
                        (TimeSpan.FromHours(19), TimeSpan.FromHours(22), "19:00 - 22:00"),
                        // Khung 22:00 - 00:00 cần xử lý riêng
                        (TimeSpan.FromHours(22), TimeSpan.FromHours(23.9999), "22:00 - 00:00")
                };

            var query = from bill in Connect.Bills
                        join st in Connect.ShowTimes on bill.ShowTime_Id equals st.Id
                        where (st.StartTime.Year == year || year == 0)
                           && (st.StartTime.Month == month || month == 0)
                        select new
                        {
                            Time = st.StartTime, // kiểu DateTime
                            Quantity = bill.QuantityTicket
                        };
            var result = new Dictionary<string, long>();
            foreach (var slot in timeSlots)
            {
                result[slot.Label] = 0;
            }
            // Phân loại vé theo khung giờ
            foreach (var item in query)
            {
                var timeOfDay = item.Time.TimeOfDay;

                bool matched = false;
                foreach (var slot in timeSlots)
                {
                    if (timeOfDay >= slot.Start && timeOfDay < slot.End)
                    {
                        result[slot.Label] += item.Quantity;
                        matched = true;
                        break;
                    }
                }

                // Nếu là sau 22:00 hoặc trước 04:00 (trường hợp chéo ngày)
                if (!matched && (timeOfDay >= TimeSpan.FromHours(22) || timeOfDay < TimeSpan.FromHours(4)))
                {
                    result["22:00 - 00:00"] += item.Quantity;
                }
            }
            return result;
        }

        public Dictionary<string, long> GetTicketCountBySlot(DateTime fromDate, DateTime toDate)
        {
            // Định nghĩa các khung giờ
            var timeSlots = new List<(TimeSpan Start, TimeSpan End, string Label)>
                    {
                        (TimeSpan.FromHours(0),  TimeSpan.FromHours(4), "00:00 - 04:00"),
                        (TimeSpan.FromHours(7),  TimeSpan.FromHours(10), "07:00 - 10:00"),
                        (TimeSpan.FromHours(10), TimeSpan.FromHours(13), "10:00 - 13:00"),
                        (TimeSpan.FromHours(13), TimeSpan.FromHours(16), "13:00 - 16:00"),
                        (TimeSpan.FromHours(16), TimeSpan.FromHours(19), "16:00 - 19:00"),
                        (TimeSpan.FromHours(19), TimeSpan.FromHours(22), "19:00 - 22:00"),
                        // Khung 22:00 - 00:00 cần xử lý riêng
                        (TimeSpan.FromHours(22), TimeSpan.FromHours(23.9999), "22:00 - 00:00")
                    };

            var query = from bill in Connect.Bills
                        join st in Connect.ShowTimes on bill.ShowTime_Id equals st.Id
                        where st.StartTime >= fromDate && st.StartTime <= toDate
                        select new
                        {
                            Time = st.StartTime,
                            Quantity = bill.QuantityTicket
                        };

            var result = new Dictionary<string, long>();
            foreach (var slot in timeSlots)
            {
                result[slot.Label] = 0;
            }

            // Phân loại vé theo khung giờ
            foreach (var item in query)
            {
                var timeOfDay = item.Time.TimeOfDay;

                bool matched = false;
                foreach (var slot in timeSlots)
                {
                    if (timeOfDay >= slot.Start && timeOfDay < slot.End)
                    {
                        result[slot.Label] += item.Quantity;
                        matched = true;
                        break;
                    }
                }

                // Nếu là sau 22:00 hoặc trước 04:00 (trường hợp chéo ngày)
                if (!matched && (timeOfDay >= TimeSpan.FromHours(22) || timeOfDay < TimeSpan.FromHours(4)))
                {
                    result["22:00 - 00:00"] += item.Quantity;
                }
            }

            return result;
        }

        public List<dynamic> GetRevenueTableByMonthYear(int month, int year)
        {
            var query = from bill in Connect.Bills
                        join st in Connect.ShowTimes on bill.ShowTime_Id equals st.Id
                        join movie in Connect.MOVIEs on st.Movie_Id equals movie.id
                        where (bill.BillDate.Year == year || year == 0)
                           && (bill.BillDate.Month == month || month == 0)
                        group new { bill, st, movie } by new { bill.BillDate.Date, movie.Title } into g
                        select new
                        {
                            Ngay = g.Key.Date,
                            TenPhim = g.Key.Title,
                            TongSoVe = g.Sum(x => x.bill.QuantityTicket),
                            TongDoanhThu = g.Sum(x => x.bill.Total),
                            SoSuatChieu = g.Select(x => x.st.Id).Distinct().Count()
                        };

            return query.OrderBy(x => x.Ngay).ToList<dynamic>();
        }

        public List<dynamic> GetRevenueTableByDateRange(DateTime startDate, DateTime endDate)
        {
            var query = from bill in Connect.Bills
                        join st in Connect.ShowTimes on bill.ShowTime_Id equals st.Id
                        join movie in Connect.MOVIEs on st.Movie_Id equals movie.id
                        where bill.BillDate.Date >= startDate.Date && bill.BillDate.Date <= endDate.Date
                        group new { bill, st, movie } by new { bill.BillDate.Date, movie.Title } into g
                        select new
                        {
                            Ngay = g.Key.Date,
                            TenPhim = g.Key.Title,
                            TongSoVe = g.Sum(x => x.bill.QuantityTicket),
                            TongDoanhThu = g.Sum(x => x.bill.Total),
                            SoSuatChieu = g.Select(x => x.st.Id).Distinct().Count()
                        };

            return query.OrderBy(x => x.Ngay).ToList<dynamic>();
        }



    }


}
