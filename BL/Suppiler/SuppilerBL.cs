using DL.Suppiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Suppiler
{
    public class SuppilerBL
    {
        public Task<List<DTO.Suppiler.TableSuppiler>> LoadSuppiler()
        {
            return new  SuppilerDL().LoadSuppiler();
        }

        public Task<bool> AddSuppiler(string name, string email,string phone,string adress)
        {
            return new SuppilerDL().AddSuppiler(name,email,phone,adress);
        }

        public Task<bool> DeleteSuppiler(int SuppilerId)
        {
            return new SuppilerDL().DeleteSuppiler(SuppilerId);
        }
    }
}
