using DL;
using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SignUp
    {
        public Task<bool> SignUpAsync(string username, string password, string email)
        {
            try
            {

                return (new DL.SignUp().AddUserAsync(username,password,email));
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
