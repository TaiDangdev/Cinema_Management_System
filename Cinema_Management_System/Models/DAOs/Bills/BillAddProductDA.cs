using Cinema_Management_System.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Models.DAOs
{
    public class BillAddProductDA
    {
        public List<BillAddProductDTO> GetAllBillAddProducts()
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    return db.Bill_AddProducts.Select(bap => new BillAddProductDTO(
                        bap.Id,
                        bap.Product_Id,
                        bap.BillDate,
                        bap.Quantity,
                        bap.UnitPurchasePrice,
                        bap.Total
                    )).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public void AddBillAddProduct(BillAddProductDTO billAddProductDTO)
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    Bill_AddProduct billAddProduct = new Bill_AddProduct
                    {
                        Product_Id = billAddProductDTO.ProductId,
                        BillDate = billAddProductDTO.BillDate,
                        Quantity = billAddProductDTO.Quantity,
                        UnitPurchasePrice = billAddProductDTO.UnitPurchasePrice
                        // Total sẽ được tính tự động bởi cột computed
                    };

                    db.Bill_AddProducts.InsertOnSubmit(billAddProduct);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void EditBillAddProduct(BillAddProductDTO billAddProductDTO)
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    var billAddProduct = db.Bill_AddProducts.FirstOrDefault(bap => bap.Id == billAddProductDTO.Id);
                    if (billAddProduct == null)
                    {
                        throw new Exception("Không tìm thấy bill add product để cập nhật.");
                    }

                    billAddProduct.Product_Id = billAddProductDTO.ProductId;
                    billAddProduct.BillDate = billAddProductDTO.BillDate;
                    billAddProduct.Quantity = billAddProductDTO.Quantity;
                    billAddProduct.UnitPurchasePrice = billAddProductDTO.UnitPurchasePrice;
                    // Total sẽ được cập nhật tự động bởi cột computed

                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật bill add product: " + ex.Message);
            }
        }
        public void DeleteBillAddProduct(int id)
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    var billAddProduct = db.Bill_AddProducts.FirstOrDefault(bap => bap.Id == id);
                    if (billAddProduct == null)
                    {
                        throw new Exception("Không tìm thấy bill add product để xóa.");
                    }

                    db.Bill_AddProducts.DeleteOnSubmit(billAddProduct);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa bill add product: " + ex.Message);
            }
        }
    }
}
