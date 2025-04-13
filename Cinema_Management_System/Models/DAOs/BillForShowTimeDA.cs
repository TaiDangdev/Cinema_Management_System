using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool AddBillShowTime(Bill newBill)
        {
            try
            {
                Connect.Bills.InsertOnSubmit(newBill);
                Connect.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
