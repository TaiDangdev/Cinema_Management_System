using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.ShowTimeManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cinema_Management_System.ViewModels.CustomerManagement.CustomerManagementVm;
using System.Windows.Input;
using System.Windows;

namespace Cinema_Management_System.Models.DAOs
{
    public class BillForShowTimeDA
    {
        ConnectDataContext Connect = new ConnectDataContext();

        private static BillForShowTimeDA instance;

        public static BillForShowTimeDA Instance
        {
            get { if (instance == null) BillForShowTimeDA.instance = new BillForShowTimeDA(); return BillForShowTimeDA.instance; }
            set { BillForShowTimeDA.instance = value; }
        }

        private BillForShowTimeDA() { }

        public int AddBillShowTime(Bill newBill)
        {
            
            try
            {
                Connect.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, Connect.Bills);
                Connect.Bills.InsertOnSubmit(newBill);
                Connect.SubmitChanges();
                return newBill.Id;
            }
            catch
            {
                return -1;
            }
        }

        // lấy thông tin bill để in hóa đơn

        public bool DeleleteBill(int id)
        {
            try
            {
                var bill = Connect.Bills.SingleOrDefault(b => b.Id == id);
                if (bill != null)
                {
                    Connect.Bills.DeleteOnSubmit(bill);
                    Connect.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // lấy danh sách tất cả Bill
        public List<BillSeatsForShowTimesDTO> GetListBillSeatsForShowTimes()
        {
            try
            {
              List<BillSeatsForShowTimesDTO> ListBill = new List<BillSeatsForShowTimesDTO>();
              ListBill = (from bill in Connect.Bills
                                join
                              st in Connect.ShowTimes on bill.ShowTime_Id equals st.Id
                                join movie in Connect.MOVIEs on st.Movie_Id equals movie.id
                                join staff in Connect.STAFFs on bill.Staff_Id equals staff.Id into staffJoin
                                 from staff in staffJoin.DefaultIfEmpty()
                                join customer in Connect.CUSTOMERs on bill.Customer_Id equals customer.Id into customerJoin
                                 from customer in customerJoin.DefaultIfEmpty()
                          select new BillSeatsForShowTimesDTO
                                {
                                    Id = bill.Id,
                              MovieId = movie.id,
                              quantity = bill.QuantityTicket,
                                    PhoneNumber = customer.PhoneNumber,
                                    DateTimeShowTime = bill.BillDate,
                                    MovieName = movie.Title,
                                    AuditoriumName = st.Auditorium_Id.ToString(),
                                    NameStaff = staff.FullName,
                                    Discount = bill.Discount,
                                    TotalPrice = bill.Total,
                                    ticketPrice = bill.PerSeatTicketPrice
                                }).ToList();
                return ListBill;
            }
            catch
            {
                return new List<BillSeatsForShowTimesDTO>();
            }
        }

        public List<BillSeatsForShowTimesDTO> GetListBillSeatsForShowTimes(int idMovie)
        {
            try
            {
                List<BillSeatsForShowTimesDTO> ListBill = new List<BillSeatsForShowTimesDTO>();
                ListBill = (from bill in Connect.Bills
                            join
                          st in Connect.ShowTimes on bill.ShowTime_Id equals st.Id
                            join movie in Connect.MOVIEs on st.Movie_Id equals movie.id
                            join staff in Connect.STAFFs on bill.Staff_Id equals staff.Id
                            join customer in Connect.CUSTOMERs on bill.Customer_Id equals customer.Id
                            where movie.id == idMovie
                            select new BillSeatsForShowTimesDTO
                            {
                                Id = bill.Id,
                                MovieId = movie.id,
                                quantity = bill.QuantityTicket,
                                PhoneNumber = customer.PhoneNumber,
                                DateTimeShowTime = bill.BillDate,
                                MovieName = movie.Title,
                                AuditoriumName = st.Auditorium_Id.ToString(),
                                NameStaff = staff.FullName,
                                Discount = bill.Discount,
                                TotalPrice = bill.Total,
                                ticketPrice = bill.PerSeatTicketPrice
                            }).ToList();
                return ListBill;
            }
            catch
            {
                return new List<BillSeatsForShowTimesDTO>();
            }
        }

        public BillSeatsForShowTimesDTO GetBillById(int idBill)
        {
            try
            {
                BillSeatsForShowTimesDTO billselect;
                billselect = (from bill in Connect.Bills
                              join
                              st in Connect.ShowTimes on bill.ShowTime_Id equals st.Id
                              join movie in Connect.MOVIEs on st.Movie_Id equals movie.id
                              join staff in Connect.STAFFs on bill.Staff_Id equals staff.Id
                              join customer in Connect.CUSTOMERs on bill.Customer_Id equals customer.Id
                              where bill.Id == idBill
                              select new BillSeatsForShowTimesDTO
                              {
                                  Id = bill.Id,
                                  MovieId = movie.id,
                                  quantity = bill.QuantityTicket,
                                  PhoneNumber = customer.PhoneNumber,
                                  DateTimeShowTime = bill.BillDate,
                                  MovieName = movie.Title,
                                  AuditoriumName = st.Auditorium_Id.ToString(),
                                  NameStaff = staff.FullName,
                                  Discount = bill.Discount,
                                  TotalPrice = bill.Total,
                                  ticketPrice = bill.PerSeatTicketPrice
                              }).FirstOrDefault();
                return billselect;
            }
            catch
            {
                return null;
            }
        }


        public List<int> GetYearInBills()
        {
            try
            {
                List<int> years = (from bill in Connect.Bills
                                   select bill.BillDate.Year)
                                  .Distinct()
                                  .OrderByDescending(y => y)
                                  .ToList();

                return years;
            }
            catch
            {
                return new List<int>();
            }
        }

    }
}
