using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class deleteUsersBL
    {
        public Task<bool> DeleteUser(int id)
        {
            return new deleteUsers().DeleteUsers(id);
        }
    }
}
