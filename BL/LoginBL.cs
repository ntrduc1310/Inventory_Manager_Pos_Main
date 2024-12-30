using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using DTO;
using Microsoft.Data.SqlClient;


namespace BL
{
    public class LoginBL
    {
        public Task<bool> LoginAsync(string username, string password)
        {
            try
            {

                return (new LoginDL().LoginAsync(username, password));
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public async Task<string> GetImagePathByUsernamePasssword(string username, string password)
        {
            return await new LoginDL().GetImagePathByUsernamePasssword(username, password);
        }

        public async Task<string> GetRoleByUsernamePassword(string username, string password)
        {
            return await new LoginDL().GetRoleByUsernamePassword(username, password);
        }

    }
}
