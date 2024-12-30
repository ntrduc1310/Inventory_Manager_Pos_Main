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
            return await new LoadUserDL().LoadUsers();
        }
        public async Task<List<Users>> searchUser(string searchText)
        {
            return await new LoadUserDL().SearchUsers(searchText);
        }

    }
}
