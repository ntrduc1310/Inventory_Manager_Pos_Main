using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.User;

namespace BL.User
{
    public class addUsersBL
    {
        public bool AddUser(string name,string username, string password,string phone,string filepathPicture )
        {
            return new addUsersDL().AddUsers(name,username,password,phone,filepathPicture);
        }
    }
}
