using DTO;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Users>> LoadUsers()
        {
            using (var context = new DataProviderEntity()) // DataProviderEntity là DbContext của bạn
            {
                // Truy vấn tất cả nhân viên
                return await context.Users.ToListAsync();
            }
        }

        public async Task<List<DTO.Users>> SearchUsers(string searchText)
        {
            try
            {
                // If no search text is provided, load all users
                if (string.IsNullOrWhiteSpace(searchText))
                    return await LoadUsers();  // Corrected method name

                // Load all users
                var Users = await LoadUsers();  // Corrected method name
                searchText = searchText.ToLower().Trim();  // Normalize search text

                // Filter the users based on the search text
                return Users.Where(c =>
                    c.Id.ToString().Contains(searchText) ||
                    (c.Name?.ToLower().Contains(searchText) ?? false) ||
                    (c.UserName?.ToLower().Contains(searchText) ?? false) ||
                    c.Phone.ToString().Contains(searchText) ||
                    (c.Password?.ToLower().Contains(searchText) ?? false) ||
                    (c.Picture?.ToString().Contains(searchText) ?? false)  // Adjust if ProfilePicture is a string or use a different property
                ).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchUsers: {ex.Message}");
                return new List<DTO.Users>();  // Return an empty list in case of an error
            }
        }
    }
}
