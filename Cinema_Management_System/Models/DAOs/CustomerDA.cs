using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.ViewModels;

namespace Cinema_Management_System.Models.DAOs
{
    public class CustomerDA
    {
        // lấy dữ liệu các khách hàng chưa bị xóa (Isdelete = False)
        public List<CustomerDTO> GetAllCustomer()
        {
            try
            {
                using (var db = new ConnectDataContext())
                {
                    return db.CUSTOMERs
                        .Where(c => c.IsDeleted == false)
                        .Select(customer => new CustomerDTO(
                        customer.Id,
                        customer.IdFormat,
                        customer.FullName,
                        customer.Gender ,
                        customer.PhoneNumber,
                        customer.Email,
                        customer.Birth,
                        customer.RegDate,
                        customer.Point
                    )).ToList();

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
       

        public bool AddCustomer(CustomerDTO customer)
        {
            try
            {
                using (var db = new ConnectDataContext())
                {
                    CUSTOMER newCustomer = new CUSTOMER()
                    {
                        FullName = customer.FullName,
                        PhoneNumber = customer.PhoneNumber,
                        Email = customer.Email,
                        Point = customer.Point,
                        Birth = customer.Birth,
                        Gender = customer.Gender,
                        RegDate = customer.RegDate,
                        IsDeleted = false,

                    };
                    db.CUSTOMERs.InsertOnSubmit(newCustomer);
                    db.SubmitChanges();
                    customer.Id = newCustomer.Id;
                    customer.IdFormat = newCustomer.IdFormat;
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Số điện thoại đã tồn tại trong hệ thống!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

        }

        public bool UpdateCustomer(CustomerDTO customer)
        {
            try
            {
                using (var db = new ConnectDataContext())
                {
                    var existingCustomer = db.CUSTOMERs.SingleOrDefault(c => c.Id == customer.Id);

                    if (existingCustomer != null)
                    {
                        //MessageBox.Show("đã tìm thấy" + existingCustomer.FullName);
                        existingCustomer.FullName = customer.FullName;
                        existingCustomer.PhoneNumber = customer.PhoneNumber;
                        existingCustomer.Email = customer.Email;
                        existingCustomer.Birth = customer.Birth;
                        //existingCustomer.RegDate = customer.RegDate;
                        existingCustomer.Gender = customer.Gender;
                        //existingCustomer.Point = customer.Point;

                        db.SubmitChanges();
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message);
                return false;
            }

        }
        public int GetIdFromIdFormat(string idFormat)
        {
            if (!string.IsNullOrWhiteSpace(idFormat) && idFormat.StartsWith("KH"))
            {
                string numberPart = idFormat.Substring(2); // Bỏ "KH"
                if (int.TryParse(numberPart, out int id))
                {
                    return id;
                }
            }
            throw new FormatException("IdFormat không hợp lệ: " + idFormat);
        }


    }
}
