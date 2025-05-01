using System;
using System.Collections.Generic;
using System.Linq;
using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.Views.MessageBox;

namespace Cinema_Management_System.Models.DAOs
{
    public class CustomerDA
    {
        private static CustomerDA instance;

        public static CustomerDA Instance
        {
            get { if (instance == null) instance = new CustomerDA(); return instance; }
            set { instance = value; }
        }

        private CustomerDA() { }

        // lấy dữ liệu 10 khách hàng chưa bị xóa (Isdelete = False) 
        public List<CustomerDTO> GetAllCustomer()
        {
            try
            {
                using (var db = new ConnectDataContext())
                {
                    return db.CUSTOMERs
                        .Where(c => c.IsDeleted == false)
                        .Take(15)
                        .Select(customer => new CustomerDTO(
                        customer.Id,
                        customer.IdFormat,
                        customer.FullName,
                        customer.Gender,
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
            catch
            {
                MessageBoxHelper.ShowError("Lỗi", "Số điện thoại đã tồn tại trong hệ thống!");
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
                        existingCustomer.FullName = customer.FullName;
                        existingCustomer.PhoneNumber = customer.PhoneNumber;
                        existingCustomer.Email = customer.Email;
                        existingCustomer.Birth = customer.Birth;
                        existingCustomer.Gender = customer.Gender;

                        db.SubmitChanges();
                        return true;
                    }

                    return false;
                }
            }
            catch
            { 
                return false;
            }

        }

        public int GetIdFromIdFormat(string idFormat)
        {
            if (!string.IsNullOrWhiteSpace(idFormat) && idFormat.StartsWith("KH"))
            {
                string numberPart = idFormat.Substring(2);
                if (int.TryParse(numberPart, out int id))
                {
                    return id;
                }
            }
            MessageBoxHelper.ShowError("Lỗi","IdFormat không hợp lệ: " + idFormat);
            return -1;
        }

        public void UpdateDiem(CustomerDTO kh)
        {
            using (var db = new ConnectDataContext())
            {
                var result = db.CUSTOMERs.SingleOrDefault(c => c.Id == kh.Id);
                if (result != null)
                {
                    result.Point = kh.Point;
                    db.SubmitChanges();
                }
            }
        }

        //Xoá mềm khách hàng
        public bool DeleteCustomer(int id)
        {
            try
            {
                using (var db = new ConnectDataContext())
                {
                    var customer = db.CUSTOMERs.SingleOrDefault(c => c.Id == id);
                    if (customer != null)
                    {
                        customer.IsDeleted = true;
                        db.SubmitChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                MessageBoxHelper.ShowError("Lỗi","Không thể xóa khách hàng");
                return false;
            }
        }

        public CustomerDTO GetCustomerByPhoneNumber(string phoneNumber)
        {
            try
            {
                using (var db = new ConnectDataContext())
                {
                    var customer = db.CUSTOMERs
                                     .FirstOrDefault(c => c.PhoneNumber == phoneNumber && c.IsDeleted == false);

                    if (customer != null)
                    {
                        return new CustomerDTO(
                            customer.Id,
                            customer.IdFormat,
                            customer.FullName,
                            customer.Gender,
                            customer.PhoneNumber,
                            customer.Email,
                            customer.Birth,
                            customer.RegDate,
                            customer.Point
                        );
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool UpdatePoint(string PhoneNumberUpdate, int addPoint)
        {
            try
            {
                using (var db = new ConnectDataContext())
                {
                    var customer = db.CUSTOMERs.SingleOrDefault(c => c.PhoneNumber == PhoneNumberUpdate && c.IsDeleted==false);
                    if (customer != null)
                    {
                        customer.Point += addPoint;
                        db.SubmitChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                MessageBoxHelper.ShowError("Lỗi", "Không thể cập nhật điểm khách hàng");
                return false;
            }
        }

        // tìm kiếm
        // Hàm tìm kiếm khách hàng theo tên hoặc số điện thoại, giới hạn số lượng kết quả
        public List<CustomerDTO> SearchCustomers(string keyword, string searchType, int limit = 15)
        {
            using (var context = new ConnectDataContext())
            {
                keyword = keyword.ToLower();
                if (searchType == "FullName")
                {
                    return context.CUSTOMERs
                        .Where(c => c.FullName.ToLower().Contains(keyword))
                        .OrderBy(c => c.FullName)
                        .Take(limit)
                        .Select(c => new CustomerDTO
                        {
                            IdFormat = c.IdFormat,
                            FullName = c.FullName,
                            PhoneNumber = c.PhoneNumber,
                            Email = c.Email,
                            Birth = c.Birth,
                            Gender = c.Gender
                        })
                        .ToList();
                }
                else if (searchType == "PhoneNumber")
                {
                    return context.CUSTOMERs
                        .Where(c => c.PhoneNumber.Contains(keyword))
                        .OrderBy(c => c.PhoneNumber)
                        .Take(limit)
                        .Select(c => new CustomerDTO
                        {
                            IdFormat = c.IdFormat,
                            FullName = c.FullName,
                            PhoneNumber = c.PhoneNumber,
                            Email = c.Email,
                            Birth = c.Birth,
                            Gender = c.Gender
                        })
                        .ToList();
                }
                return new List<CustomerDTO>();
            }
        }
    }
}
