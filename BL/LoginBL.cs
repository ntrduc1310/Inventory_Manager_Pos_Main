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
        public Task<bool> LoginAsync(Account acc)
        {
            try
            {

                return (new LoginDL().LoginAsync(acc));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
