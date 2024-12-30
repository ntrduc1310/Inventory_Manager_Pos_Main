using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
namespace DL
{
    public class LoginDL : DataProviderEntity
    {
        public async Task<bool> LoginAsync(string username, string password)
        {
            if (username == null || password == null) throw new ArgumentNullException(nameof(username));

            using (var context = new DataProviderEntity())
            {
                // Kiểm tra tồn tại tài khoản
                bool exists = await context.Users.AnyAsync(a => a.UserName == username && a.Password == password);

                return exists;
            }
        }

        public async Task<string> GetImagePathByUsernamePasssword(string username, string password)
        {
            using (var context = new DataProviderEntity())
            {
                // Lấy tên danh mục từ cơ sở dữ liệu theo ID
                var user = await context.Users
                                                .Where(c => c.UserName == username && c.Password == password)
                                                .Select(c => c.Picture)
                                                .FirstOrDefaultAsync();

                return user ?? "Unknown"; // Trả về tên nếu tìm thấy, nếu không trả về "Unknown"
            }
        }
        public async Task<string> GetRoleByUsernamePassword(string username, string password)
        {
            using (var context = new DataProviderEntity())
            {
                // Lấy vai trò từ cơ sở dữ liệu theo tên đăng nhập và mật khẩu
                var role = await context.Users
                                        .Where(c => c.UserName == username && c.Password == password)
                                        .Select(c => c.Role)
                                        .FirstOrDefaultAsync();

                return role ?? "Unknown"; // Trả về vai trò nếu tìm thấy, nếu không trả về "Unknown"
            }
        }



    }
}
