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
        public async Task<bool> LoginAsync(Account acc)
        {
            if (acc == null) throw new ArgumentNullException(nameof(acc));

            using (var context = new DataProviderEntity())
            {
                // Kiểm tra tồn tại tài khoản
                bool exists = await context.Admin.AnyAsync(a => a.Username == acc.Username && a.Password == acc.Password);

                return exists;
            }
        }



    }
}
