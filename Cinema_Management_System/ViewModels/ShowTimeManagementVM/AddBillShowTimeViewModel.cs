using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.ViewModels.ShowTimeManagementVM
{
    public class AddBillShowTimeViewModel
    {
        public bool AddBillShowTime(ShowTimeDTO showTimeSelect, int Quantity,string note)
        {
            try
            {
                Bill newBill = new Bill() {
                    ShowTime_Id=showTimeSelect.ShowTimeID, 
                    BillDate= DateTime.Now,
                    QuantityTicket=Quantity, 
                    PerSeatTicketPrice=showTimeSelect.SeatTicketPrice, 
                    Note= note, 
                    Total=Quantity * showTimeSelect.SeatTicketPrice
                };
                return BillForShowTimeDA.Instance.AddBillShowTime(newBill);
            }
            catch
            {
                return false;
            }
        }
    }
}
