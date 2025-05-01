using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Models.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Bitmap ImageSource { get; set; }
        public int Quantity { get; set; }
        public int PurchasePrice { get; set; }
        public int? Price { get; set; }
        public int Type { get; set; }

        public ProductDTO() { }

        //constructor phục vụ cho việc get sản phẩm
        public ProductDTO(int id, string name, Bitmap imageSource, int quantity, int purchasePrice, int? price, int type)
        {
            this.Id = id;
            this.Name = name;
            this.ImageSource = imageSource;
            this.Quantity = quantity;
            this.PurchasePrice = purchasePrice;
            this.Price = price;
            this.Type = type;
        }

        //constructor phụ vụ cho việc thêm sản phẩm
        public ProductDTO(string name, Bitmap imageSource, int quantity, int purchasePrice, int? price, int type)
        {
            this.Name = name;
            this.ImageSource = imageSource;
            this.Quantity = quantity;
            this.PurchasePrice = purchasePrice;
            this.Price = price;
            this.Type = type;
        }
    }

}
