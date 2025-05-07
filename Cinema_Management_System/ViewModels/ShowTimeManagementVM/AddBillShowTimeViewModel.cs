using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cinema_Management_System.ViewModels.ShowTimeManagementVM
{
    public class AddBillShowTimeViewModel
    {
        ConnectDataContext Connect = new ConnectDataContext();
        public int AddBillShowTime(ShowTimeDTO showTimeSelect, int Quantity,string note, int discount,int idStaff)
        {
            try
            {
                Bill newBill = new Bill() {
                    Staff_Id = idStaff,
                    ShowTime_Id =showTimeSelect.ShowTimeID, 
                    BillDate= DateTime.Now,
                    QuantityTicket=Quantity, 
                    PerSeatTicketPrice=showTimeSelect.SeatTicketPrice, 
                    Note= note, 
                    Discount = discount,
                    Total=Quantity * showTimeSelect.SeatTicketPrice - discount
                };
                return BillForShowTimeDA.Instance.AddBillShowTime(newBill);
            }
            catch
            {
                 
                 return -1;
            }
        }

        public int AddBillShowTime(ShowTimeDTO showTimeSelect, int Quantity, string note, int discount, int idStaff, string PhoneNumber)
        {
            try
            {
                CUSTOMER customer = new CUSTOMER();

                customer = (from cs in Connect.CUSTOMERs
                            where cs.PhoneNumber == PhoneNumber
                            select cs).FirstOrDefault();

                Bill newBill = new Bill()
                {
                    Staff_Id = idStaff,
                    ShowTime_Id = showTimeSelect.ShowTimeID,
                    BillDate = DateTime.Now,
                    QuantityTicket = Quantity,
                    PerSeatTicketPrice = showTimeSelect.SeatTicketPrice,
                    Note = note,
                    Discount = discount,
                    Total = Quantity * showTimeSelect.SeatTicketPrice - discount
                };
                if (customer != null)
                {
                    newBill.Customer_Id = customer.Id;
                }
                return BillForShowTimeDA.Instance.AddBillShowTime(newBill);

            }
            catch
            {
                return -1;
            }
        }

    }
}
