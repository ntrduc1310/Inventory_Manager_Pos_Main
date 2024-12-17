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
        public List<Users> loadUser()
        {
            return new LoadUserDL().LoadUsers();
        }
    }
}
