using DL;
using DL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.User
{
    public class UpdateUsersBL
    {

        public bool UpdateUser(int id, string name, string userName, string password, string phone, string picture)
        {
            try
            {
                // Tạo đối tượng updateUser
                var updater = new updateUser();

                // Gọi phương thức UpdateUser của lớp updateUser
                bool result = updater.UpdateUser(id, name, userName, password, phone, picture);

                return result;
            }
            catch (Exception ex)
            {
                // Xử lý và ghi lại lỗi
                Console.WriteLine($"Lỗi khi gọi phương thức UpdateUser trong BL: {ex.Message}");
                throw ex;
            }
        }

    }
}
