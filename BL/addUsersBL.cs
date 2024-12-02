using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class addUsersBL
    {
        public bool AddUser(string name,string username, string password,string phone,string filepathPicture )
        {
            return new addUsersDL().AddUsers(name,username,password,phone,filepathPicture);
        }
    }
}
