using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Cinema_Management_System.Models.DAOs
{

    public class ShowTimeDA
    {
        ConnectDataContext Connect = new ConnectDataContext();

        private static ShowTimeDA instance;

        public static ShowTimeDA Instance
        {
            get { if (instance == null) ShowTimeDA.instance = new ShowTimeDA(); return ShowTimeDA.instance;}
            set { ShowTimeDA.instance = value; }
        }

        private ShowTimeDA() { }

        public List<ShowTimeDTO> getShowTimeList()
        {
            List<ShowTimeDTO> ShowTimeList= new List<ShowTimeDTO>();
            ShowTimeList = (from st in Connect.ShowTimes
                         join m in Connect.MOVIEs on st.Movie_Id equals m.id
                         join a in Connect.Auditoriums on st.Auditorium_Id equals a.Id
                            where st.StartTime.Date >= DateTime.Now.Date 
                            select new ShowTimeDTO
                         {
                             Movie_id = st.Movie_Id,
                             ShowTimeID = st.Id,
                             Auditorium_Id = st.Auditorium_Id,
                             MovieTitle = m.Title,
                             MovieImage = m.ImageSource.ToArray(),
                             AuditoriumName = a.Name,
                             StartTime = st.StartTime,
                             EndTime = st.EndTime,
                             SeatTicketPrice = st.PerSeatTicketPrice
                         }).ToList();
            return ShowTimeList;
        }



        public List<ShowTimeDTO>filterShowTimeByAuditorium(int id)
        {
            List<ShowTimeDTO> showTimelist= new List<ShowTimeDTO>();
            if (id<0) { // nut toan bo idAuditorium <0
                showTimelist = (from st in Connect.ShowTimes
                                join m in Connect.MOVIEs on st.Movie_Id equals m.id
                                join a in Connect.Auditoriums on st.Auditorium_Id equals a.Id
                                where st.StartTime.Date >= DateTime.Now.Date
                                select new ShowTimeDTO
                                {
                                    Movie_id = st.Movie_Id,
                                    ShowTimeID = st.Id,
                                    Auditorium_Id = st.Auditorium_Id,
                                    MovieTitle = m.Title,
                                    MovieImage = m.ImageSource.ToArray(),
                                    AuditoriumName = a.Name,
                                    StartTime = st.StartTime,
                                    EndTime = st.EndTime,
                                    SeatTicketPrice = st.PerSeatTicketPrice
                                }).ToList();
            }
            else // cac phong co ton tai 
            {
                showTimelist = (from st in Connect.ShowTimes
                                join m in Connect.MOVIEs on st.Movie_Id equals m.id
                                join a in Connect.Auditoriums on st.Auditorium_Id equals a.Id
                                where st.Auditorium_Id == id && st.StartTime.Date >= DateTime.Now.Date
                                select new ShowTimeDTO
                                {
                                    Movie_id = st.Movie_Id,
                                    ShowTimeID = st.Id,
                                    Auditorium_Id = st.Auditorium_Id,
                                    MovieTitle = m.Title,
                                    MovieImage = m.ImageSource.ToArray(),
                                    AuditoriumName = a.Name,
                                    StartTime = st.StartTime,
                                    EndTime = st.EndTime,
                                    SeatTicketPrice = st.PerSeatTicketPrice
                                }).ToList();
            }
            return showTimelist;
        }

        public  List<ShowTimeDTO> filterShowTimeByDate(DateTime dateFilter)
        {
            List<ShowTimeDTO> showTimelist = new List<ShowTimeDTO>();
            if (dateFilter == null)
            {
                showTimelist = (from st in Connect.ShowTimes
                                join m in Connect.MOVIEs on st.Movie_Id equals m.id
                                join a in Connect.Auditoriums on st.Auditorium_Id equals a.Id
                                where st.StartTime.Date >= DateTime.Now.Date
                                select new ShowTimeDTO
                                {
                                    Movie_id = st.Movie_Id,
                                    ShowTimeID = st.Id,
                                    Auditorium_Id = st.Auditorium_Id,
                                    MovieTitle = m.Title,
                                    MovieImage = m.ImageSource.ToArray(),
                                    AuditoriumName = a.Name,
                                    StartTime = st.StartTime,
                                    EndTime = st.EndTime,
                                    SeatTicketPrice = st.PerSeatTicketPrice
                                }).ToList();
            }
            else
            {
                showTimelist = (from st in Connect.ShowTimes
                                join m in Connect.MOVIEs on st.Movie_Id equals m.id
                                join a in Connect.Auditoriums on st.Auditorium_Id equals a.Id
                                where st.StartTime.Date==dateFilter.Date
                                && st.StartTime.Date >= DateTime.Now.Date
                                select new ShowTimeDTO
                                {
                                    Movie_id = st.Movie_Id,
                                    ShowTimeID = st.Id,
                                    Auditorium_Id = st.Auditorium_Id,
                                    MovieTitle = m.Title,
                                    MovieImage = m.ImageSource.ToArray(),
                                    AuditoriumName = a.Name,
                                    StartTime = st.StartTime,
                                    EndTime = st.EndTime,
                                    SeatTicketPrice = st.PerSeatTicketPrice
                                }).GroupBy(st => st.Movie_id) // Nhóm theo tên phim
                                    .Select(group => group.First()) // Lấy suất chiếu đầu tiên của mỗi nhóm
                                    .ToList();
            }
            return showTimelist;
        }

        // loc xuat chieu theo phim va theo ngay
        public List<ShowTimeDTO> filterShowTimeByDateAndMovie(int idMovie,DateTime dateFilter)
        {
            List<ShowTimeDTO> showTimelist=new List<ShowTimeDTO>();
            if (dateFilter == null)
            {
                showTimelist = (from st in Connect.ShowTimes
                                join m in Connect.MOVIEs on st.Movie_Id equals m.id
                                join a in Connect.Auditoriums on st.Auditorium_Id equals a.Id
                                where st.Movie_Id == idMovie && st.StartTime.Date >= DateTime.Now.Date
                                select new ShowTimeDTO
                                {
                                    Movie_id = st.Movie_Id,
                                    ShowTimeID = st.Id,
                                    Auditorium_Id = st.Auditorium_Id,
                                    MovieTitle = m.Title,
                                    MovieImage = m.ImageSource.ToArray(),
                                    AuditoriumName = a.Name,
                                    StartTime = st.StartTime,
                                    EndTime = st.EndTime,
                                    SeatTicketPrice = st.PerSeatTicketPrice
                                }).ToList();
            }
            else
            {
                // Lọc theo ngày
                showTimelist = (from st in Connect.ShowTimes
                                join m in Connect.MOVIEs on st.Movie_Id equals m.id
                                join a in Connect.Auditoriums on st.Auditorium_Id equals a.Id
                                where st.Movie_Id == idMovie && st.StartTime.Date == dateFilter.Date
                                && st.StartTime.Date >= DateTime.Now.Date
                                select new ShowTimeDTO
                                {
                                    Movie_id = st.Movie_Id,
                                    ShowTimeID = st.Id,
                                    Auditorium_Id = st.Auditorium_Id,
                                    MovieTitle = m.Title,
                                    MovieImage = m.ImageSource.ToArray(),
                                    AuditoriumName = a.Name,
                                    StartTime = st.StartTime,
                                    EndTime = st.EndTime,
                                    SeatTicketPrice = st.PerSeatTicketPrice
                                }).ToList();
            }
            return showTimelist;
        }

        // loc xuat chieu theo phong va theo phim
        public List<ShowTimeDTO> filterShowTimeByAuditoriumAndMovie(int idMovie,int idAuditorium)
        {
            List<ShowTimeDTO> showTimelist = new List<ShowTimeDTO>();
            if (idAuditorium<0)
            {
                showTimelist = (from st in Connect.ShowTimes
                                join m in Connect.MOVIEs on st.Movie_Id equals m.id
                                join a in Connect.Auditoriums on st.Auditorium_Id equals a.Id
                                where st.Movie_Id == idMovie && st.StartTime.Date >= DateTime.Now.Date
                                select new ShowTimeDTO
                                {
                                    Movie_id = st.Movie_Id,
                                    ShowTimeID = st.Id,
                                    Auditorium_Id = st.Auditorium_Id,
                                    MovieTitle = m.Title,
                                    MovieImage = m.ImageSource.ToArray(),
                                    AuditoriumName = a.Name,
                                    StartTime = st.StartTime,
                                    EndTime = st.EndTime,
                                    SeatTicketPrice = st.PerSeatTicketPrice
                                }).ToList();
            }
            else
            {
                showTimelist = (from st in Connect.ShowTimes
                                join m in Connect.MOVIEs on st.Movie_Id equals m.id
                                join a in Connect.Auditoriums on st.Auditorium_Id equals a.Id
                                where st.Movie_Id == idMovie && st.Auditorium_Id == idAuditorium
                                && st.StartTime.Date >= DateTime.Now.Date
                                select new ShowTimeDTO
                                {
                                    Movie_id = st.Movie_Id,
                                    ShowTimeID = st.Id,
                                    Auditorium_Id = st.Auditorium_Id,
                                    MovieTitle = m.Title,
                                    MovieImage = m.ImageSource.ToArray(),
                                    AuditoriumName = a.Name,
                                    StartTime = st.StartTime,
                                    EndTime = st.EndTime,
                                    SeatTicketPrice = st.PerSeatTicketPrice
                                }).ToList();
            }
            return showTimelist;
        }

        public List<ShowTimeDTO> FilterMovieByAuditorium(int auditoriumId)
        {
            List<ShowTimeDTO> showTimelist = new List<ShowTimeDTO>();

            if (auditoriumId < 0)
            {
                showTimelist = (from st in Connect.ShowTimes
                                join m in Connect.MOVIEs on st.Movie_Id equals m.id
                                join a in Connect.Auditoriums on st.Auditorium_Id equals a.Id
                                where st.StartTime.Date >= DateTime.Now.Date
                                select new ShowTimeDTO
                                {
                                    Movie_id = st.Movie_Id,
                                    ShowTimeID = st.Id,
                                    Auditorium_Id = st.Auditorium_Id,
                                    MovieTitle = m.Title,
                                    MovieImage = m.ImageSource.ToArray(),
                                    AuditoriumName = a.Name,
                                    StartTime = st.StartTime,
                                    EndTime = st.EndTime,
                                    SeatTicketPrice = st.PerSeatTicketPrice
                                }).GroupBy(st => st.Movie_id) // Nhóm theo tên phim
                                    .Select(group => group.First()) // Lấy suất chiếu đầu tiên của mỗi nhóm
                                    .ToList();
            }
            else
            {
                showTimelist = (from st in Connect.ShowTimes
                                join m in Connect.MOVIEs on st.Movie_Id equals m.id
                                join a in Connect.Auditoriums on st.Auditorium_Id equals a.Id
                                where st.Auditorium_Id == auditoriumId && st.StartTime.Date >= DateTime.Now.Date
                                select new ShowTimeDTO
                                {
                                    Movie_id = st.Movie_Id,
                                    ShowTimeID = st.Id,
                                    Auditorium_Id = st.Auditorium_Id,
                                    MovieTitle = m.Title,
                                    MovieImage = m.ImageSource.ToArray(),
                                    AuditoriumName = a.Name,
                                    StartTime = st.StartTime,
                                    EndTime = st.EndTime,
                                    SeatTicketPrice = st.PerSeatTicketPrice
                                }).GroupBy(st => st.Movie_id) // Nhóm theo tên phim
                                    .Select(group => group.First()) // Lấy suất chiếu đầu tiên của mỗi nhóm
                                    .ToList();
            }

            return showTimelist ?? new List<ShowTimeDTO>();
        }

        public bool InsertShowTime(ShowTime newshowtime)
        {
            try
            {
                if (newshowtime.StartTime < DateTime.Now)
                {
                    MessageBoxHelper.ShowError("Lỗi", "Thời gian bắt đầu không hợp lệ. Vui lòng chọn thời gian trong tương lai.");
                    return false;
                }
                // kiem tra xem phim moiw o phong nao va co bi trung thoi gian voi suat khasc khong
                bool isOverLap = Connect.ShowTimes.Any(s=>
                s.Auditorium_Id==newshowtime.Auditorium_Id &&
                ((newshowtime.StartTime>=s.StartTime && newshowtime.StartTime<=s.EndTime)||
                (newshowtime.EndTime>=s.StartTime && newshowtime.EndTime<=s.EndTime)||
                (newshowtime.StartTime<=s.StartTime && newshowtime.EndTime>=s.EndTime))
                );
                if (isOverLap)
                {
                    MessageBoxHelper.ShowError("Lỗi", "Lịch chiếu bị trùng thời gian hoặc phòng chiếu. Vui lòng chọn thời gian khác.");
                    return false;
                }
                Connect.ShowTimes.InsertOnSubmit(newshowtime);
                Connect.SubmitChanges();
                Connect.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, Connect.ShowTimes);

                //// lay du lieu ghe chieu cua suat phim
                //var seats=from seat in Connect.Seats
                //          where seat.Auditorium_Id==newshowtime.Auditorium_Id
                //          select seat;

                //foreach (var item in seats)
                //{
                //    var seatForShowTime = new SeatForShowtime
                //    {
                //        Seat_Id = item.Id,
                //        ShowTime_Id = newshowtime.Id,
                //        Condition = false
                //    };
                //    Connect.SeatForShowtimes.InsertOnSubmit(seatForShowTime);
                //}
                //Connect.SubmitChanges();

                return true;
            }
            catch
            {
                MessageBoxHelper.ShowError("Lỗi", "Lỗi thêm suất chiếu");
                return false;
            }
        }


        public bool UpdateShowTime(ShowTime showTimeUpdate)
        {
            try
            {
                if(showTimeUpdate.StartTime < DateTime.Now)
                {
                    MessageBoxHelper.ShowError("Lỗi", "Thời gian bắt đầu không hợp lệ. Vui lòng chọn thời gian trong tương lai.");
                    return false;
                }
                // tim xem co suat chieu cap nhat trong du lieu khong
                var existingShowTime = Connect.ShowTimes.FirstOrDefault(s => s.Id == showTimeUpdate.Id);
                if (existingShowTime == null)
                {
                    MessageBoxHelper.ShowError("Lỗi", "Không tìm thấy suất chiếu cần cập nhật.");
                    return false;
                }
                else
                {
                    // Kiểm tra xem thời gian mới có bị trùng với suất chiếu khác không
                    bool isOverLap = Connect.ShowTimes.Any(s =>
                        s.Id != showTimeUpdate.Id &&  // Bỏ qua chính suất chiếu đang cập nhật
                        s.Auditorium_Id == showTimeUpdate.Auditorium_Id &&
                        ((showTimeUpdate.StartTime >= s.StartTime && showTimeUpdate.StartTime <= s.EndTime) ||
                        (showTimeUpdate.EndTime >= s.StartTime && showTimeUpdate.EndTime <= s.EndTime) ||
                        (showTimeUpdate.StartTime <= s.StartTime && showTimeUpdate.EndTime >= s.EndTime))
                    );

                    if (isOverLap)
                    {
                        MessageBoxHelper.ShowError("Lỗi", "Lịch chiếu bị trùng thời gian hoặc phòng chiếu. Vui lòng chọn thời gian khác.");
                        return false;
                    }
                    // Cập nhật thông tin suất chiếu
                    existingShowTime.Movie_Id = showTimeUpdate.Movie_Id;
                    existingShowTime.Auditorium_Id = showTimeUpdate.Auditorium_Id;
                    existingShowTime.StartTime = showTimeUpdate.StartTime;
                    existingShowTime.EndTime = showTimeUpdate.EndTime;
                    existingShowTime.PerSeatTicketPrice = showTimeUpdate.PerSeatTicketPrice;

                    // Lưu thay đổi vào CSDL
                    Connect.SubmitChanges();
                    Connect.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, Connect.ShowTimes);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteShowTime(ShowTimeDTO ShowTimeId)
        {
            try
            {
                var showTime = Connect.ShowTimes.FirstOrDefault(st => st.Id == ShowTimeId.ShowTimeID);
                if (showTime != null)
                {
                    Connect.ShowTimes.DeleteOnSubmit(showTime);
                    Connect.SubmitChanges();
                    Connect.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, Connect.ShowTimes);
                    return true;
                }
                return false;
            }
            catch
            {
                MessageBoxHelper.ShowInfo("Thông báo", "Xóa không thành công"); 
                return false;
            }
        }

        // kiểm tra 1 movie có đang chiếu hay không (phục vụ cho việc xóa 1 movie)
        public bool checkShowTimeByMovie(int movieID)
        {
            DateTime currentTime = DateTime.Now;
            try
            {
                // Kiểm tra suất chiếu đang diễn ra (StartTime <= currentTime <= EndTime) hoặc trong tương lai (StartTime > currentTime)
                return Connect.ShowTimes.Any(st =>
                    (st.Movie_Id == movieID) &&
                    (
                        (st.StartTime <= currentTime && st.EndTime >= currentTime) || // Đang diễn ra
                        (st.StartTime > currentTime) // Trong tương lai
                    )
                );
            }
            catch
            {
                return false;
            }
            //DateTime currentTime = DateTime.Now;
            //try
            //{
            //    return Connect.ShowTimes.Any(st => st.Movie_Id == movieID && st.EndTime >= currentTime);
            //}
            //catch
            //{
            //    return false;
            //}
        }
    }
}
