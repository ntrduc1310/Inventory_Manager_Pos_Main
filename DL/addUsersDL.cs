using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class addUsersDL
    {
        public bool AddUsers(string name, string username,string password,string phone,string filepathPicture) 
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    var newEmployee = new Employees();

                    // Gán từng giá trị
                    newEmployee.Name = name;
                    newEmployee.UserName = username;
                    newEmployee.Password = password;
                    newEmployee.Phone = phone;
                    newEmployee.Picture = filepathPicture;
                    bool exists = context.Employees.Any(a => a.UserName == name);
                    if (exists)
                    {
                        return false;
                    }
                    else
                    {
                        // Thêm vào DbSet
                        context.Employees.Add(newEmployee);
                        var rowAffect = context.SaveChanges();

                        return rowAffect > 0;
                    }

                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
