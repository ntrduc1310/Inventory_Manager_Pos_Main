using System;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using DTO;
using DTO.Suppiler;

namespace DL
{
    public class DataProviderEntity : DbContext
    {
        // Cấu hình chuỗi kết nối
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Lấy chuỗi kết nối từ App.config
                string connectionString = ConfigurationManager.ConnectionStrings["cnStr"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        // Định nghĩa các DbSet cho bảng
        public DbSet<Employees> Employees { get; set; }
        public DbSet<tableAmin> Admin { get; set; } 

        public DbSet<TableSuppiler> Suppiler { get; set; }

        // Phương thức kiểm tra kết nối
        public bool CheckDatabaseConnection()
        {
            try
            {
                // Kiểm tra kết nối cơ sở dữ liệu
                return Database.CanConnect(); // Trả về true nếu có thể kết nối, false nếu không
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine($"Lỗi khi kiểm tra kết nối cơ sở dữ liệu: {ex.Message}");
                return false;
            }
        }

        // Phương thức kiểm tra ánh xạ
        public bool CheckMapping()
        {
            try
            {
                // Kiểm tra ánh xạ bảng Employees
                var model = Model;

                // Kiểm tra xem bảng Employees có tồn tại trong ánh xạ không
                var employeeEntity = model.FindEntityType(typeof(Employees));
                if (employeeEntity == null)
                {
                    Console.WriteLine("Bảng 'Employees' không tồn tại trong ánh xạ.");
                    return false;
                }

                // Kiểm tra ánh xạ của các thuộc tính trong bảng Employees
                var properties = employeeEntity.GetProperties();
                foreach (var property in properties)
                {
                    Console.WriteLine($"Thuộc tính: {property.Name}, Kiểu dữ liệu: {property.ClrType}");
                }

                // Nếu không có vấn đề, trả về true
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine($"Lỗi khi kiểm tra ánh xạ: {ex.Message}");
                return false;
            }
        }

        public bool check()
        {
            using (var context = new DataProviderEntity())
            {
                // Gọi phương thức GetEmployeeCount để lấy số lượng nhân viên
                int employeeCount = context.Employees.Count();
                Console.WriteLine($"Số lượng nhân viên trong cơ sở dữ liệu: {employeeCount}");
                var employees = context.Employees.ToList();

                foreach (var employee in employees)
                {
                    // Kiểm tra giá trị NULL và xử lý
                    string name = employee.Name ?? "Unknown";
                    string phone = employee.Phone ?? "No phone";
                    string userName = employee.UserName ?? "No username";
                    string password = employee.Password ?? "No password";

                    // Nếu Picture là null, không in gì, nếu không thì in thông tin
                    string picture = employee.Picture != null ? "Picture exists" : null;

                    // In ra thông tin nhân viên, chỉ in Picture nếu có giá trị
                    if (picture != null)
                    {
                        Console.WriteLine($"ID: {employee.Id}, Name: {name}, Phone: {phone}, Username: {userName}, Password: {password}, Picture: {picture}");
                    }
                    else
                    {
                        Console.WriteLine($"ID: {employee.Id}, Name: {name}, Phone: {phone}, Username: {userName}, Password: {password}");
                    }
                }


                return employeeCount > 0;
            }
        }
    }
}
