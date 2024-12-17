using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.User
{
    public class LoadUserDL : DataProviderEntity
    {
        // Sử dụng Entity Framework để lấy danh sách người dùng
        public List<Users> LoadUsers()
        {
            using (var context = new DataProviderEntity()) // DataProviderEntity là DbContext của bạn
            {
                // Truy vấn tất cả nhân viên
                return context.Users.ToList();
            }
        }
    }
}
