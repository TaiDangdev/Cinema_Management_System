using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Models
{
    public class ProductDA
    {
        /*
         * ConnectDataContext là một class đại diện cho database được tạo tự động bằng LINQ to SQL 
         * từ khóa Using để đảm bảo khi xử lý xong thì tài nguyên db sẽ được giải phóng
         * Trong SQL serve hình ảnh không lưu trực tiếp bằng JPEG hay PNG mà được mã hóa dưới dạng byte[] binary large object
         * 
         */
        // Phương thức lấy toàn bộ sản phẩm
        public List<ProductDTO> GetAllProducts()
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    /* 
                    * Truy vấn tất cả các sản phẩm trong Products và dùng LINQ select() để chuyển từng sản phẩm (P) thành đối tượng ProductDTO
                    * 
                    */
                    return db.Products.Select(p => new ProductDTO( 
                        p.ID,
                        p.Name,
                        ImageVsSQL.ByteArrayToBitmap(p.ImageSource.ToArray()),
                        p.Quantity,
                        p.PurchasePrice,
                        p.Price,
                        p.Type
                    )).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        // Phương thức lọc sản phẩm theo loại (Type)
        public List<ProductDTO> FilterProductsByType(int type)
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    return db.Products.Where(p => p.Type == type).Select(p => new ProductDTO(
                            p.ID,
                            p.Name,
                            ImageVsSQL.ByteArrayToBitmap(p.ImageSource.ToArray()),
                            p.Quantity,
                            p.PurchasePrice,
                            p.Price,
                            p.Type
                        )).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lọc sản phẩm theo loại {type}: " + ex.Message);
            }
        }

        // Phương thức tìm kiếm sản phẩm theo tên (Name)
        public List<ProductDTO> FilterProductsByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Tên sản phẩm không được để trống.", nameof(name));

                using (ConnectDataContext db = new ConnectDataContext())
                {
                    return db.Products.Where(p => p.Name.Contains(name)).Select(p => new ProductDTO(
                            p.ID,
                            p.Name,
                            ImageVsSQL.ByteArrayToBitmap(p.ImageSource.ToArray()),
                            p.Quantity,
                            p.PurchasePrice,
                            p.Price,
                            p.Type
                        )).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm sản phẩm theo tên '{name}': " + ex.Message);
            }
        }

        // Phương thức thêm 1 sản phẩm
        public void AddProduct(ProductDTO productDTO)
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    Product product = new Product
                    {
                        Name = productDTO.Name,
                        ImageSource = ((productDTO.ImageSource != null) ? ImageVsSQL.BitmapToByteArray(productDTO.ImageSource) : null),
                        Quantity = productDTO.Quantity,
                        PurchasePrice = productDTO.PurchasePrice,
                        Type = productDTO.Type
                    };
                    db.Products.InsertOnSubmit(product);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        // Phương thức sửa 1 sản phẩm
        public void EditProduct(ProductDTO productDTO)
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    var product = db.Products.FirstOrDefault(p => p.ID == productDTO.Id);
                    if (product == null)
                    {
                        throw new Exception("Không tìm thấy sản phẩm để cập nhật.");
                    }
                    product.Name = productDTO.Name;
                    product.ImageSource = productDTO.ImageSource != null ? ImageVsSQL.BitmapToByteArray(productDTO.ImageSource) : product.ImageSource;
                    product.Quantity = productDTO.Quantity;
                    product.PurchasePrice = productDTO.PurchasePrice;
                    product.Type = productDTO.Type;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật sản phẩm: " + ex.Message);
            }
        }

        // Phương thức xóa 1 sản phẩm    
        public void DeleteProduct(ProductDTO productDTO)
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    var product = db.Products.FirstOrDefault(p => p.ID == productDTO.Id);
                    if (product == null)
                    {
                        throw new Exception("Không tìm thấy sản phẩm để xóa.");
                    }
                    db.Products.DeleteOnSubmit(product);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa sản phẩm: " + ex.Message);
            }
        }
        // Phương thức lấy 1 sản phẩm bằng ID
        public ProductDTO GetProductById(int productId)
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    var product = db.Products
                        .Where(p => p.ID == productId)
                        .Select(p => new ProductDTO(
                            p.ID,
                            p.Name,
                            p.ImageSource != null ? ImageVsSQL.ByteArrayToBitmap(p.ImageSource.ToArray()) : null,
                            p.Quantity,
                            p.PurchasePrice,
                            p.Price,
                            p.Type
                        ))
                        .FirstOrDefault();

                    return product;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin sản phẩm có ID {productId}: " + ex.Message);
            }
        }

        /// <summary>
        /// Kiểm tra xem sản phẩm có tồn tại trong database không
        /// </summary>
        /// <param name="productId">ID của sản phẩm cần kiểm tra</param>
        /// <returns>True nếu sản phẩm tồn tại, False nếu không</returns>
        public bool IsProductExist(int productId)
        {
            try
            {
                using (ConnectDataContext db = new ConnectDataContext())
                {
                    return db.Products.Any(p => p.ID == productId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra sự tồn tại của sản phẩm: " + ex.Message);
            }
        }
    }
}
