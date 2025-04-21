using Cinema_Management_System.Models.DTOs.ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Models.DAOs.Bills
{
    public class BillImportProductDA
    {
        public List<BillImportProductDTO> GetAllBillImportProducts()
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    return db.Bill_ImportProducts.Select(bip => new BillImportProductDTO(
                        bip.Id,
                        bip.Product_Id,
                        bip.BillDate,
                        bip.Quantity,
                        bip.UnitPurchasePrice,
                        bip.Total
                    )).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void AddBillImportProduct(BillImportProductDTO billImportProductDTO)
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    Bill_ImportProduct billImportProduct = new Bill_ImportProduct
                    {
                        Product_Id = billImportProductDTO.ProductId,
                        BillDate = billImportProductDTO.BillDate,
                        Quantity = billImportProductDTO.Quantity,
                        UnitPurchasePrice = billImportProductDTO.UnitPurchasePrice
                        // Total sẽ được tính tự động bởi cột computed
                    };

                    db.Bill_ImportProducts.InsertOnSubmit(billImportProduct);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void EditBillImportProduct(BillImportProductDTO billImportProductDTO)
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    var billImportProduct = db.Bill_ImportProducts.FirstOrDefault(bip => bip.Id == billImportProductDTO.Id);
                    if (billImportProduct == null)
                    {
                        throw new Exception("Không tìm thấy bill import product để cập nhật.");
                    }

                    billImportProduct.Product_Id = billImportProductDTO.ProductId;
                    billImportProduct.BillDate = billImportProductDTO.BillDate;
                    billImportProduct.Quantity = billImportProductDTO.Quantity;
                    billImportProduct.UnitPurchasePrice = billImportProductDTO.UnitPurchasePrice;
                    // Total sẽ được cập nhật tự động bởi cột computed

                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật bill import product: " + ex.Message);
            }
        }
        public void DeleteBillImportProduct(int id)
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    var billImportProduct = db.Bill_ImportProducts.FirstOrDefault(bip => bip.Id == id);
                    if (billImportProduct == null)
                    {
                        throw new Exception("Không tìm thấy bill import product để xóa.");
                    }

                    db.Bill_ImportProducts.DeleteOnSubmit(billImportProduct);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa bill import product: " + ex.Message);
            }
        }
    }
}
