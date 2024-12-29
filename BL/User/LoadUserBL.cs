using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DL;
using System.Runtime.Serialization;
using DTO;
using DL.User;
namespace BL.User
{
    public class LoadUserBL
    {
        public async Task<List<Users>> loadUser()
        {
            return new LoadUserDL().LoadUsers();
        }
        //public async Task<List<DTO.Users>> SearchUsers(string searchText)
        //{
        //    try
        //    {
        //        // If no search text is provided, load all users
        //        if (string.IsNullOrWhiteSpace(searchText))
        //            return await loadUser();  // Assuming LoadUsers() fetches all the user data

        //        // Load all users
        //        var Users = await loadUser();
        //        searchText = searchText.ToLower().Trim();  // Normalize search text

        //        // Filter the users based on the search text
        //        return Users.Where(c =>
        //            c.Id.ToString().Contains(searchText) ||
        //            (c.Name?.ToLower().Contains(searchText) ?? false) ||
        //            (c.UserName?.ToLower().Contains(searchText) ?? false) ||
        //            c.Phone.ToString().Contains(searchText) ||
        //            (c.Password?.ToLower().Contains(searchText) ?? false) ||
        //            (c.Picture?.ToString().Contains(searchText) ?? false)  // Adjust if ProfilePicture is a string or use a different property
        //        ).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error in SearchUsers: {ex.Message}");
        //        return new List<DTO.Users>();  // Return an empty list in case of an error
        //    }
        //}

    }
}
