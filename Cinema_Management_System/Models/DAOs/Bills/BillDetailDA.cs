using Cinema_Management_System.Models.DTOs;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Models.DAOs
{
    public class BillDetailDA
    {
        //Phương lấy toàn bộ các chi tiết hóa đơn
        public List<BillDetailDTO> GetAllBillDetails()
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    return db.BillDetails.Select(bd => new BillDetailDTO(
                        bd.Id,
                        bd.Bill_Id,
                        bd.Product_Id,
                        bd.Quantity,
                        bd.UnitPrice,
                        bd.Total
                    )).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        //Phương thức thêm 1 chi tiết hóa đơn
        public void AddBillDetail(BillDetailDTO billDetailDTO)
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    BillDetail billDetail = new BillDetail
                    {
                        Bill_Id = billDetailDTO.BillId,
                        Product_Id = billDetailDTO.ProductId,
                        Quantity = billDetailDTO.Quantity,
                        UnitPrice = billDetailDTO.UnitPrice,
                        //Total = billDetailDTO.Total
                        //Total sẽ được set bởi trigger trg_setTotal_BillDetail
                    };
                    db.BillDetails.InsertOnSubmit(billDetail);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        //phương thức cập nhập chi tiết hóa đơn
        public void UpdateBillDetail(BillDetailDTO billDetailDTO)
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    var billDetail = db.BillDetails.FirstOrDefault(bd => bd.Id == billDetailDTO.Id);
                    if (billDetail == null)
                    {
                        throw new Exception("Không tìm thấy chi tiết hóa đơn để cập nhật.");
                    }
                    billDetail.Bill_Id = billDetailDTO.BillId;
                    billDetail.Product_Id = billDetailDTO.ProductId;
                    billDetail.Quantity = billDetailDTO.Quantity;
                    billDetail.UnitPrice = billDetailDTO.UnitPrice;
                    //billDetail.Total = billDetailDTO.Total;
                    //Total sẽ được cập nhật tự động bởi cột computed
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        // Xóa một chi tiết hóa đơn theo ID
        public void DeleteBillDetail(int id)
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    var billDetail = db.BillDetails.FirstOrDefault(bd => bd.Id == id);
                    if (billDetail == null)
                    {
                        throw new Exception("Không tìm thấy chi tiết hóa đơn để xóa.");
                    }

                    db.BillDetails.DeleteOnSubmit(billDetail);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa chi tiết hóa đơn: " + ex.Message);
            }
        }
    }
}
