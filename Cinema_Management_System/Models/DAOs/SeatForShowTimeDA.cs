using Cinema_Management_System.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Models.DAOs
{
    public class SeatForShowTimeDA
    {
        ConnectDataContext Connect = new ConnectDataContext();

        private static SeatForShowTimeDA instance;

        public static SeatForShowTimeDA Instance
        {
            get { if (instance == null) SeatForShowTimeDA.instance = new SeatForShowTimeDA(); return SeatForShowTimeDA.instance; }
            set { SeatForShowTimeDA.instance = value; }
        }

        private SeatForShowTimeDA() { }


        public List<SeatForShowTimesDTO> GetSeatByShowTimes(ShowTimeDTO showTimeSelect)
        {
            if (showTimeSelect == null) return new List<SeatForShowTimesDTO>();
            List<SeatForShowTimesDTO> seat = new List<SeatForShowTimesDTO>();

            seat = (from sfs in Connect.SeatForShowtimes
                    join s in Connect.Seats on sfs.Seat_Id equals s.Id
                    where sfs.ShowTime_Id == showTimeSelect.ShowTimeID
                    select new SeatForShowTimesDTO
                    {
                        IdSeatForShowTimes = sfs.Id,
                        Seat_Id = sfs.Seat_Id,
                        showTimeId = sfs.ShowTime_Id,
                        condition = sfs.Condition,
                        location = s.Location,
                        Auditorium_Id = s.Auditorium_Id
                    }).ToList();
            return seat;
        }

        public void UpdateSeatCondition(List<SeatForShowTimesDTO> seatsToUpdate)
        {
            if (seatsToUpdate == null || !seatsToUpdate.Any()) return;
            Connect.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, Connect.SeatForShowtimes);
            try
            {
                foreach (var seat in seatsToUpdate)
                {
                    // kiem tra ghe trong data 
                    var seatInDb = Connect.SeatForShowtimes.FirstOrDefault(sfs => sfs.Id == seat.IdSeatForShowTimes);
                    if (seatInDb != null)
                    {
                        seatInDb.Condition = seat.condition;
                    }
                }
                Connect.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái ghế: " + ex.Message);
            }
        }

        public void ResetSeatsCodition(int idSeat)
        {
            Connect.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, Connect.SeatForShowtimes);
            var seatInDb = Connect.SeatForShowtimes.FirstOrDefault(sfs => sfs.Id == idSeat);
            if (seatInDb != null)
            {
                seatInDb.Condition = null;
                Connect.SubmitChanges();
            }
        }
    }
}
