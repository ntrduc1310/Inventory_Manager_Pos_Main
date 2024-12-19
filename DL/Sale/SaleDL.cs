using DTO.Sale;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Sale
{
    public class SaleDL : DataProviderEntity
    {
        // Load danh sách Sale
        public async Task<List<SaleClass>> LoadSales()
        {
            try
            {
                using (var context = new DataProviderEntity()) // DbContext của bạn
                {
                    var data = await context.Sale.Select(s => new SaleClass
                    {
                        SaleID = s.SaleID,
                        CustomerID = s.CustomerID,
                        CreatedAt = s.CreatedAt,
                        TotalAmount = s.TotalAmount,
                        CreatedBy = s.CreatedBy,
                        Status = s.Status
                    }).ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Thêm mới Sale
        public async Task<bool> AddSale(int customerId, decimal totalAmount, string createdBy, string notes)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {

                    var newSale = new SaleClass
                    {
                        CustomerID = customerId, 
                        TotalAmount = totalAmount,
                        Status = "Đang xử lý",
                        CreatedBy = createdBy,
                        Notes = notes,
                    };

                    context.Sale.Add(newSale);

                    int rowAffect = await context.SaveChangesAsync();
                    return rowAffect > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Lưu thông tin Sale (bao gồm chi tiết sản phẩm)
        public async Task<bool> SaveSale(int customerId, decimal totalAmount, List<SaleDetail> saleDetails, string notes)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    // Tạo một đối tượng Sale mới
                    var newSale = new SaleClass
                    {
                        CustomerID = customerId,
                        TotalAmount = totalAmount,
                        Status = "Đang xử lý",
                        Notes = notes,
                        CreatedAt = DateTime.Now,
                        CreatedBy = "Hệ thống" // Hoặc thay bằng tên người dùng hiện tại
                    };

                    // Thêm Sale vào DbContext
                    context.Sale.Add(newSale);
                    await context.SaveChangesAsync();

                    // Duyệt qua danh sách SaleDetails và thêm từng sản phẩm vào chi tiết đơn hàng
                    foreach (var detail in saleDetails)
                    {
                        detail.SaleID = newSale.SaleID;  // Gán SaleID cho chi tiết đơn hàng
                        context.SaleDetail.Add(detail);  // Thêm SaleDetail vào DbContext
                    }

                    // Lưu tất cả thay đổi vào cơ sở dữ liệu
                    int affectedRows = await context.SaveChangesAsync();
                    return affectedRows > 0;
                }
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                Console.WriteLine($"Error saving sale: {ex.Message}");
                return false;
            }
        }

        // Cập nhật trạng thái Sale
        public async Task<bool> UpdateStatus(string status, int saleId)
        {
            using (var context = new DataProviderEntity())
            {
                var sale = await context.Sale.FirstOrDefaultAsync(s => s.SaleID == saleId);

                if (sale == null)
                {
                    return false;
                }

                sale.Status = status;
                sale.UpdatedAt = DateTime.Now;

                int rowAffect = await context.SaveChangesAsync();
                return rowAffect > 0;
            }
        }

        // Xóa Sale
        public async Task<bool> DeleteSale(int saleId)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    var saleDelete = await context.Sale.FirstOrDefaultAsync(s => s.SaleID == saleId);

                    if (saleDelete != null)
                    {
                        context.Sale.Remove(saleDelete);

                        int affectedRows = await context.SaveChangesAsync();
                        return affectedRows > 0;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Load chi tiết Sale dưới dạng chuỗi
        public async Task<string> LoadSaleDetailsByIdAsString(int saleId)
        {
            using (var context = new DataProviderEntity())
            {
                var sale = await context.Sale.FirstOrDefaultAsync(s => s.SaleID == saleId);

                if (sale == null)
                {
                    return "Không tìm thấy giao dịch nào với ID đã cho.";
                }

                string result = $"Sale Date: {sale.CreatedAt:dd/MM/yyyy}\n" +
                                $"Total Amount: {sale.TotalAmount:C2}\n" +
                                $"Status: {sale.Status}\n" +
                                $"Created By: {sale.CreatedBy}\n" +
                                $"Notes: {sale.Notes}\n" +
                                $"Updated Date: {sale.UpdatedAt:dd/MM/yyyy HH:mm:ss}";

                return result;
            }
        }

        // Load danh sách khách hàng (customer) cho ComboBox
        public async Task<object> LoadCustomerToComboBox()
        {
            using (var context = new DataProviderEntity())
            {
                var customerList = await context.Customer
                                    .ToListAsync();  // Load khách hàng từ bảng Customers

                return customerList;
            }
        }

        // Load sản phẩm từ khách hàng (nếu có liên kết)
        public async Task<List<DTO.Products.Products>> LoadProductsFromCustomer(int customerId)
        {
            using (var context = new DataProviderEntity())
            {
                var products = await (from p in context.Products
                                      join sd in context.SaleDetail on p.ProductID equals sd.ProductID
                                      join s in context.Sale on sd.SaleID equals s.SaleID
                                      where s.CustomerID == customerId
                                      select new DTO.Products.Products
                                      {
                                          ProductID = p.ProductID,
                                          Name = p.Name,
                                          Price = p.Price,
                                          // Các trường khác bạn muốn ánh xạ
                                      }).ToListAsync();

                return products;
            }
        }
    }
}
