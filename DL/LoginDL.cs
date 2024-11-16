using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
using System.Configuration;
namespace DL
{
    public class LoginDL : DataProvider
    {
        public async Task<bool> LoginAsync(Account acc)
        {
            if (acc == null) throw new ArgumentNullException(nameof(acc));

            var dp = new DataProvider();
            string sql = "SELECT COUNT(Username) FROM Account WHERE Username = @Username AND Password = @Password";

            try
            {
                await dp.ConnectAsync(); // Chờ kết nối thành công

                if (dp.conn == null || dp.conn.State != System.Data.ConnectionState.Open)
                {
                    throw new InvalidOperationException("The database connection is not open.");
                }

                using (SqlCommand cmd = new SqlCommand(sql, dp.conn))
                {
                    cmd.Parameters.AddWithValue("@Username", acc.Username ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Password", acc.Password ?? (object)DBNull.Value);

                    object result = await cmd.ExecuteScalarAsync();
                    int intResult = result != null ? Convert.ToInt32(result) : 0;
                    return intResult > 0;
                }
            }
            catch (SqlException)
            {
                throw; // Giữ lại stack trace gốc của lỗi SQL
            }
            finally
            {
                dp.Disconnect();
            }
        }



    }
}
