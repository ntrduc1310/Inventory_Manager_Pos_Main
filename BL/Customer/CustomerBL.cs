using DL.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Customer
{
    public class CustomerBL
    {
        // Phương thức tải danh sách tất cả khách hàng
        public async Task<List<DTO.Customer.TableCustomer>> LoadCustomers()
        {
            return await new CustomerDL().LoadCustomers();
        }

        // Phương thức thêm mới khách hàng
        public async Task<bool> AddCustomer(string name, string phone, string email)
        {
            return await new CustomerDL().AddCustomer(name, phone, email);
        }

        // Phương thức xóa khách hàng theo ID
        public async Task<bool> DeleteCustomer(int customerId)
        {
            return await new CustomerDL().DeleteCustomer(customerId);
        }

        // Phương thức cập nhật thông tin khách hàng
        public async Task<bool> UpdateCustomer(int id, string name, string phone, string email)
        {
            return await new CustomerDL().UpdateCustomer(id, name, phone, email);
        }
    }
}
