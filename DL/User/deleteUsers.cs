using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DL.User
{
    public class deleteUsers
    {
        public async Task<bool> DeleteUsers(int employeeIdToDelete)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    // Sử dụng await để đợi kết quả trả về từ FirstOrDefaultAsync
                    var employeeToDelete = await context.Users.FirstOrDefaultAsync(e => e.Id == employeeIdToDelete);

                    if (employeeToDelete != null)
                    {
                        // Xóa đối tượng Employee
                        context.Users.Remove(employeeToDelete);

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
    }
}
