using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Threading.Tasks;
using DTO.Customer;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace DL.Customer
{
    public class CustomerDL : DataProviderEntity
    {
        // Tải danh sách khách hàng
        public async Task<List<TableCustomer>> LoadCustomers()
           
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    // Lấy tất cả khách hàng từ cơ sở dữ liệu
                    return await context.Customer.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading customers from database: {ex.Message}");
                throw;
            }
        }

        // Thêm khách hàng mới
        public async Task<bool> AddCustomer(string name, string phone, string email)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    var newCustomer = new TableCustomer
                    {
                        Name = name,
                        Phone = phone,
                       
                        Email = email
                    };

                    // Kiểm tra nếu email đã tồn tại
                    bool exists = await context.Customer.AnyAsync(c => c.Email == email);
                    if (exists)
                    {
                        return false; // Trả về false nếu email đã tồn tại
                    }

                    // Thêm khách hàng vào DbSet
                    context.Customer.Add(newCustomer);

                    // Lưu thay đổi bất đồng bộ
                    int rowsAffected = await context.SaveChangesAsync();

                    return rowsAffected > 0; // Kiểm tra có bản ghi nào bị thay đổi không
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Đã xảy ra lỗi khi thêm khách hàng.", ex);
            }
        }

        // Xóa khách hàng
        public async Task<bool> DeleteCustomer(int customerId)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    var customerToDelete = await context.Customer.FirstOrDefaultAsync(c => c.CustomerID == customerId);

                    if (customerToDelete != null)
                    {
                        // Xóa khách hàng
                        context.Customer.Remove(customerToDelete);

                        // Lưu thay đổi vào cơ sở dữ liệu
                        int rowsAffected = await context.SaveChangesAsync();
                        return rowsAffected > 0;
                    }

                    return false; // Không tìm thấy khách hàng để xóa
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Đã xảy ra lỗi khi xóa khách hàng.", ex);
            }
        }

        // Cập nhật thông tin khách hàng
        public async Task<bool> UpdateCustomer(int customerId, string name, string phone, string email)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    var customer = await context.Customer.FirstOrDefaultAsync(c => c.CustomerID == customerId);

                    if (customer != null)
                    {
                        // Cập nhật thông tin khách hàng
                        customer.Name = string.IsNullOrEmpty(name) ? customer.Name : name;
                        customer.Phone = string.IsNullOrEmpty(phone) ? customer.Phone : phone;
                        customer.Email = string.IsNullOrEmpty(email) ? customer.Email : email;

                        // Lưu thay đổi vào cơ sở dữ liệu
                        int rowsAffected = await context.SaveChangesAsync();
                        return rowsAffected > 0; // Trả về true nếu có thay đổi
                    }

                    return false; // Không tìm thấy khách hàng để cập nhật
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Đã xảy ra lỗi khi cập nhật khách hàng.", ex);
            }
        }

    }
}
