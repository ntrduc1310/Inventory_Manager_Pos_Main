using DL.Sale;
using DTO.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Sale
{
    public class SaleBL
    {
        // Load danh sách Sale
        public async Task<List<SaleClass>> LoadSales()
        {
            return await new SaleDL().LoadSales();
        }

        public async Task<List<SaleClass>> LoadSalesInvoice()
        {
            return await new SaleDL().LoadSalesInvoice();
        }

        // Thêm mới Sale
        public async Task<bool> AddSale(int customerId, decimal totalAmount, string status, string createdBy, string notes, decimal totalCostPrice, string listNameProduct, string listQuantityProduct, string listPriceProduct)
        {
            return await new SaleDL().AddSale(customerId, totalAmount, status, createdBy, notes, totalCostPrice, listNameProduct,listQuantityProduct,listPriceProduct);
        }

        // Load danh sách khách hàng cho ComboBox
        public async Task<object> LoadCustomersToComboBox()
        {
            return await new SaleDL().LoadCustomerToComboBox();
        }

        // Load chi tiết đơn Sale bằng ID
        public async Task<string> LoadSaleDetailsByIdAsString(int saleId)
        {
            return await new SaleDL().LoadSaleDetailsByIdAsString(saleId);
        }


        public Task<int> AddSalegetID(int customerId, decimal totalAmount, string status, string createdBy, string notes, decimal totalCostPrice, string listNameProduct, string listQuantityProduct, string listPriceProduct)
        {
            return new SaleDL().AddSalegetID(customerId, totalAmount, status, createdBy, notes, totalCostPrice, listNameProduct, listQuantityProduct, listPriceProduct);
        }
        // Lưu thông tin Sale
        //public async Task<bool> SaveSale(int customerId, decimal totalAmount, List<SaleDetail> saleDetails, string notes)
        //{
        //    try
        //    {
        //        // Gọi tới lớp Data Layer để xử lý lưu thông tin
        //        return await new SaleDL().SaveSale(customerId, totalAmount, saleDetails, notes);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Ghi log lỗi nếu cần thiết
        //        Console.WriteLine($"Error saving sale: {ex.Message}");
        //        return false;
        //    }
        //}

        // Cập nhật trạng thái Sale
        public async Task<bool> UpdateStatus(string status, int saleId)
        {
            return await new SaleDL().UpdateStatus(status, saleId);
        }

        // Xóa đơn Sale
        public async Task<bool> DeleteSale(int id)
        {
            return await new SaleDL().DeleteSale(id);
        }

        // Load sản phẩm từ Customer
        public async Task<List<DTO.Products.Products>> LoadProductsFromCustomer(int customerId)
        {
            return await new SaleDL().LoadProductsFromCustomer(customerId);
        }

        public async Task<object> loadUsersToComboBox()
        {
            return await new DL.Sale.SaleDL().LoadUsertoComboBox();
        }

        public async Task<string> GetCustomerNameById(int customerId)
        {
            return await new DL.Sale.SaleDL().GetCustomerNameById(customerId);
        }

        public async Task<bool> updateStatus(string status, int saleId)
        {
            return await new SaleDL().updateStatus(status, saleId);
        }

        public async Task<List<DTO.Sale.SaleClass>> searchSale(string txt)
        {
            return await new DL.Sale.SaleDL().searchSale(txt);
        }
    }
}
