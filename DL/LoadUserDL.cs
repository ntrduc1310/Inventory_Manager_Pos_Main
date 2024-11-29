using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class LoadUserDL: DataProvider
    {
        public DataTable loadUser()
        {
            string query = "SELECT * FROM Employees";
            return LoadUserData(query);
        }
    }
}
