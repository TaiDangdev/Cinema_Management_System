using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Management_System.Views.ProductManagement
{
    public partial class PrintBillSale : Form
    {
        private int billId;
        private ConnectDataContext db = new ConnectDataContext();
        public PrintBillSale(int billId)
        {
            InitializeComponent();
            this.billId = billId;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            DataSet1 ds = new DataSet1();

            var billDetails = from detail in db.BillDetailProducts
                              join product in db.Products on detail.Product_Id equals product.ID  // Join với bảng Product
                              join bill in db.Bill_SellProducts on detail.Bill_Id equals bill.Id  // Join với bảng Bill_SellProducts
                              where detail.Bill_Id == billId
                              select new
                              {
                                  ProductName = product.Name,         // Tên sản phẩm từ bảng Product
                                  Quantity = detail.Quantity,        // Số lượng từ bảng BillDetailProduct
                                  UnitPrice = detail.UnitPrice,      // Đơn giá từ bảng BillDetailProduct
                                  TotalPrice = detail.TotalPrice,    // Tổng cộng từ bảng BillDetailProduct
                                  StaffName = bill.StaffName,        // Tên nhân viên thực hiện từ bảng Bill_SellProducts
                                  BillDate = bill.BillDate           // Ngày tạo đơn từ bảng Bill_SellProducts
                              };


            foreach (var row in billDetails)
            {
                ds.ProductBillSell.Rows.Add(row.ProductName, row.Quantity, row.UnitPrice, row.TotalPrice, row.StaffName, row.BillDate);
            }
            reportBillSale rpt = new reportBillSale();
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
    }
}
