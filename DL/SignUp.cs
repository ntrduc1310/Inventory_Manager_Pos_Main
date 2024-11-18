using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
namespace DL
{
    public class SignUp : DataProvider
    {
        public async Task<bool> AddUserAsync(string Username, string Password, string Email)
        {
            Account account = new Account(Username,Password);
            if ( account== null) throw new ArgumentNullException(nameof(account));

            string sql = @"
            INSERT INTO Users (Username, Password, Email) 
            VALUES (@Username, @Password, @Email);
            SELECT SCOPE_IDENTITY();";

            try
            {
                await ConnectAsync(); // Kết nối đến cơ sở dữ liệu

                if (conn == null || conn.State != System.Data.ConnectionState.Open)
                {
                    throw new InvalidOperationException("The database connection is not open.");
                }

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Thêm tham số vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@Username", Username ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Password", Password ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", Email ?? (object)DBNull.Value);

                    // Thực thi và lấy kết quả
                    object result = await cmd.ExecuteScalarAsync();

                    // Kiểm tra xem kết quả có trả về ID hay không
                    return result != null && int.TryParse(result.ToString(), out _);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Đăng ký tài khoản không thành công: {ex.Message}");
                throw;
            }
            finally
            {
                Disconnect(); // Ngắt kết nối sau khi thực hiện
            }
        }
    }
}
