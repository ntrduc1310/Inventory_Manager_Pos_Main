using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.User
{
    public class addUsersDL
    {
        public async Task<bool> AddUsers(string name, string username, string password, string phone, string filepathPicture, string role)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    // Check if the username already exists
                    bool exists = context.Users.Any(a => a.UserName == username);
                    if (exists)
                    {
                        // If username already exists, return false
                        return false;
                    }

                    // Create a new employee
                    var newEmployee = new Users
                    {
                        Name = name,
                        UserName = username,
                        Password = password,
                        Phone = phone,
                        Picture = filepathPicture,
                        Role = role
                    };

                    // Add and save the new employee
                    context.Users.Add(newEmployee);
                    int rowsAffected = await context.SaveChangesAsync();

                    return rowsAffected > 0; // Return true if save was successful
                }
            }
            catch (Exception ex)
            {
                throw ex; // Re-throw exception for debugging
            }
        }

    }
}
