using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Models.DTOs.ProductManagement
{
    public class BillImportProductDTO
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public DateTime BillDate { get; set; }
        public int Quantity { get; set; }
        public int UnitPurchasePrice { get; set; }
        public int? Total { get; set; }
        public BillImportProductDTO() { }
        //constructor phục vụ cho việc get hóa đơn
        public BillImportProductDTO(int id, int? productId, DateTime billDate, int quantity, int unitPurchasePrice, int? total)
        {
            this.Id = id;
            this.ProductId = productId;
            this.BillDate = billDate;
            this.Quantity = quantity;
            this.UnitPurchasePrice = unitPurchasePrice;
            this.Total = total;
        }
        //constructor phục vụ cho việc thêm hóa đơn
        public BillImportProductDTO(int? productId, DateTime billDate, int quantity, int unitPurchasePrice, int? total)
        {
            this.ProductId = productId;
            this.BillDate = billDate;
            this.Quantity = quantity;
            this.UnitPurchasePrice = unitPurchasePrice;
            this.Total = total;
        }
    }
}
