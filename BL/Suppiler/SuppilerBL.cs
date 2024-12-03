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
        public async Task<List<DTO.Suppiler.TableSuppiler>> LoadSuppiler()
        {
            return await new  SuppilerDL().LoadSuppiler();
        }

        public async Task<bool> AddSuppiler(string name, string email,string phone,string adress)
        {
            return await new SuppilerDL().AddSuppiler(name,email,phone,adress);
        }

        public async Task<bool> DeleteSuppiler(int SuppilerId)
        {
            return await new SuppilerDL().DeleteSuppiler(SuppilerId);
        }
    }
}
