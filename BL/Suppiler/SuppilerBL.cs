using DL.Suppiler;
using DTO.Suppiler;
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
        public async Task<List<DTO.Suppiler.TableSuppiler>> SearchSuppliers(string searchText)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchText))
                    return await LoadSuppiler(); // Tải toàn bộ dữ liệu nếu không nhập gì

                var suppliers = await LoadSuppiler();
                searchText = searchText.ToLower().Trim();

                return suppliers.Where(s =>
                    (s.Name?.ToLower().Contains(searchText) ?? false) ||
                    (s.Email?.ToLower().Contains(searchText) ?? false) ||
                    s.Phone.ToString().Contains(searchText) ||
                    s.Id.ToString().Contains(searchText) ||
                    (s.Address?.ToLower().Contains(searchText) ?? false)
                ).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchSuppliers: {ex.Message}");
                return new List<DTO.Suppiler.TableSuppiler>();
            }
        }

       

        public async Task<bool> AddSuppiler(string name, string email,string phone,string adress)
        {
            return await new SuppilerDL().AddSuppiler(name,email,phone,adress);
        }

        public async Task<bool> DeleteSuppiler(int SuppilerId)
        {
            return await new SuppilerDL().DeleteSuppiler(SuppilerId);
        }

        public async Task<bool> UpdateSupplier(int id, string name, string email, string phone, string adress)
        {
            return await new SuppilerDL().UpdateSupplier(id,name,email,phone,adress);
        }

      public async Task<List<DTO.Suppiler.TableSuppiler>> searchSupplier(string txt)
        {
            return await new DL.Suppiler.SuppilerDL().searchSupplier(txt);
        }
    }
}
