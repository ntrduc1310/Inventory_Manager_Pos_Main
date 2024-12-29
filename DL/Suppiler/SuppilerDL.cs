using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Suppiler
{
    public class SuppilerDL : DataProviderEntity
    {
        public async Task<List<DTO.Suppiler.TableSuppiler>> LoadSuppiler()
        {
            using (var context = new DataProviderEntity()) // DataProviderEntity là DbContext của bạn
            {
                return await context.Suppiler.ToListAsync();
            }
        }

        public async Task<bool> AddSuppiler(string name, string email, string phone, string adress)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    var newSuppiler = new DTO.Suppiler.TableSuppiler
                    {
                        Name = name,
                        Email = email,
                        Address = adress,
                        Phone = phone
                    };

                    // Kiểm tra nếu email đã tồn tại
                    bool exists = await context.Suppiler.AnyAsync(a => a.Email == email);
                    if (exists)
                    {
                        return false; // Trả về false nếu nhà cung cấp đã tồn tại
                    }

                    // Thêm nhà cung cấp vào DbSet
                    context.Suppiler.Add(newSuppiler);

                    // Lưu thay đổi bất đồng bộ và đợi kết quả
                    int rowAffect = await context.SaveChangesAsync(); // await kết quả của SaveChangesAsync()

                    return rowAffect > 0; // Kiểm tra xem có bản ghi nào bị thay đổi không
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và ném lại thông báo lỗi
                throw new Exception("Đã xảy ra lỗi khi thêm nhà cung cấp.", ex);
            }
        }


        public async Task<bool> DeleteSuppiler(int SuppilerId)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    // Sử dụng await để đợi kết quả trả về từ FirstOrDefaultAsync
                    var SuppilerToDelete = await context.Suppiler.FirstOrDefaultAsync(e => e.Id == SuppilerId);

                    if (SuppilerToDelete!= null)
                    {
                        // Xóa đối tượng Employee
                        context.Suppiler.Remove(SuppilerToDelete);

                        // Lưu thay đổi vào cơ sở dữ liệu
                        int affectedRows = await context.SaveChangesAsync(); // Cần await với SaveChangesAsync để làm việc với bất đồng bộ
                        return affectedRows > 0;
                    }

                    return false; // Nếu không tìm thấy employee để xóa
                }
            }
            catch (Exception ex)
            {
                // Có thể thêm log hoặc xử lý lỗi theo cách khác
                throw ex;
            }
        }


        public async Task<bool> UpdateSupplier(int id, string name, string email, string phone, string address)
        {
            try
            {
                // Sử dụng DataProviderEntity để kết nối với cơ sở dữ liệu
                using (var context = new DataProviderEntity())
                {
                    // Tìm nhà cung cấp có ID = id
                    var supplier = await context.Suppiler.FindAsync(id);

                    // Kiểm tra nếu nhà cung cấp tồn tại
                    if (supplier != null)
                    {
                        // Cập nhật các trường nếu giá trị mới không rỗng hoặc null
                        supplier.Name = !string.IsNullOrEmpty(name) ? name : supplier.Name;
                        supplier.Email = !string.IsNullOrEmpty(email) ? email : supplier.Email;
                        supplier.Phone = !string.IsNullOrEmpty(phone) ? phone : supplier.Phone;
                        supplier.Address = !string.IsNullOrEmpty(address) ? address : supplier.Address;

                        // Lưu thay đổi vào cơ sở dữ liệu
                        int rowsAffected = await context.SaveChangesAsync();

                        return rowsAffected > 0; // Trả về true nếu có thay đổi
                    }
                    else
                    {
                        // Ghi log hoặc hiển thị thông báo khi không tìm thấy
                        Console.WriteLine($"Không tìm thấy nhà cung cấp với ID: {id}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log lỗi
                Console.WriteLine($"Lỗi khi cập nhật nhà cung cấp: {ex.Message}");
                throw ex;
            }
        }



    }
}