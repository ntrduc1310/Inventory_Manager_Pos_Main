using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.SqlClient;
namespace DL
{
    public class DataProvider
    {
        
            public SqlConnection conn; // Đối tượng kết nối SQL

            // Constructor nhận chuỗi kết nối và gán nó cho biến thành viên
            public DataProvider()
            {
                string cnStr = ConfigurationManager.ConnectionStrings["cnStr"].ConnectionString;
                conn = new SqlConnection(cnStr);
            }

            /// <summary>
            /// Hàm bất đồng bộ dùng để kết nối tới cơ sở dữ liệu.
            /// </summary>
            public async Task ConnectAsync()
            {
                try
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        // Mở kết nối cơ sở dữ liệu
                        await conn.OpenAsync();
                        Console.WriteLine("Kết nối thành công tới cơ sở dữ liệu.");
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi khi kết nối thất bại
                    Console.WriteLine($"Lỗi khi kết nối: {ex.Message}");
                }
            }

            /// <summary>
            /// Hàm ngắt kết nối cơ sở dữ liệu.
            /// </summary>
            public void Disconnect()
            {
                try
                {
                    // Kiểm tra nếu kết nối hiện tại không null và đang mở
                    if (conn != null && conn.State == System.Data.ConnectionState.Open)
                    {
                        // Đóng kết nối
                        conn.Close();
                        Console.WriteLine("Đã ngắt kết nối cơ sở dữ liệu.");
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi khi ngắt kết nối thất bại
                    Console.WriteLine($"Lỗi khi ngắt kết nối: {ex.Message}");
                }
            }
        

        public async Task<object> MyExecuteScalar(string sql)
        {
            var dp = new DataProvider();
            await dp.ConnectAsync();

            using (SqlCommand cmd = new SqlCommand(sql, dp.conn))
            {
                cmd.CommandType = System.Data.CommandType.Text;

                try
                {
                    var result = await cmd.ExecuteScalarAsync();
                    return result ?? throw new InvalidOperationException("Query returned null."); // Xử lý trường hợp null
                }
                catch (SqlException)
                {
                    throw; // Giữ lại stack trace của ngoại lệ gốc
                }
                finally
                {
                    dp.Disconnect();
                }
            }
        }

        

    }
}
