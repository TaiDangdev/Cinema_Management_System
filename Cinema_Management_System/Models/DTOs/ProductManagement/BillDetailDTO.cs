using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Models.DTOs
{
    public class BillDetailDTO
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int? Total { get; set; }

        public BillDetailDTO() { }
        //phục vụ cho việc get hóa đơn
        public BillDetailDTO(int id, int billId, int? productId, int quantity, int unitPrice, int? total)
        {
            this.Id = id;
            this.BillId = billId;
            this.ProductId = productId;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.Total = total;
        }

        //phục vụ cho việc thêm hóa đơn
        public BillDetailDTO(int billId, int? productId, int quantity, int unitPrice, int? total)
        {
            this.BillId = billId;
            this.ProductId = productId;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.Total = total;
        }
    }
}
