using DTO.Purchase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Purchase
{
    public class PurchaseDL: DataProviderEntity
    {
        public async Task<List<PurchaseClass>> LoadPurchase()
        {
            try
            {


                using (var context = new DataProviderEntity()) // DataProviderEntity là DbContext của bạn
                {
                    var data = await context.Purchase.Select(p => new PurchaseClass
                    {
                        PurchaseID = p.PurchaseID,
                        SupplierId = p.SupplierId,
                        CreatedAt = p.CreatedAt,
                        TotalAmount = p.TotalAmount,
                        CreatedBy = p.CreatedBy,
                        Status = p.Status
                         // Thêm ánh xạ cột CreateBy
                    }).ToListAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> updateStatus(string status, int purchaseId)
        {
            using (var context = new DataProviderEntity()) // DataProviderEntity là DbContext của bạn
            {
                var purchase = await context.Purchase
                    .FirstOrDefaultAsync(p => p.PurchaseID == purchaseId);

                // Kiểm tra nếu không tìm thấy giao dịch
                if (purchase == null)
                {
                    return false;
                }
                else
                {
                    purchase.Status = status;
                    purchase.PurchaseDate = DateTime.Now;
                    int rowAffect = await context.SaveChangesAsync(); // await kết quả của SaveChangesAsync()

                    return rowAffect > 0;
                }
            }
        }

        public async Task<string> LoadPurchaseDetailsByIdAsString(int purchaseId)
        {
            using (var context = new DataProviderEntity()) // DataProviderEntity là DbContext của bạn
            {
                var purchase = await context.Purchase
                    .FirstOrDefaultAsync(p => p.PurchaseID == purchaseId);

                // Kiểm tra nếu không tìm thấy giao dịch
                if (purchase == null)
                {
                    return "Không tìm thấy giao dịch nào với ID đã cho.";
                }

                // Biểu diễn thông tin giao dịch thành chuỗi, mỗi thông tin một hàng
                string result = $"Purchase Date: {purchase.PurchaseDate:dd/MM/yyyy}\n" +
                                $"Total Amount: {purchase.TotalAmount:C2}\n" +
                                $"Status: {purchase.Status}\n" +
                                $"Created By: {purchase.CreatedBy}\n" +
                                $"Notes: {purchase.Notes}\n" +
                                $"Created Date: {purchase.CreatedAt:dd/MM/yyyy HH:mm:ss}\n" +
                                $"Updated Date: {purchase.UpdatedAt:dd/MM/yyyy HH:mm:ss}";

                return result;
            }
        }



        //public async Task<DTO.Products.Products> getProducts(int productId)
        //{
        //    using (var context = new DataProviderEntity()) // DataProviderEntity là DbContext của bạn
        //    {
        //        return await context.Products.FirstOrDefaultAsync(p => p.ProductID == productId);
        //    }
        //}
        public async Task<bool> AddPurchase(int SupplierID, decimal totalAmount, string createdBy, string notes)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {

                    var purchaseDate = DateTime.Now;
                    if (purchaseDate < new DateTime(1753, 1, 1))
                    {
                        throw new Exception("Invalid purchase date.");
                    }
                    var newPurchase = new PurchaseClass
                    {
                        SupplierId = SupplierID,
                        TotalAmount = totalAmount,
                        Status = "Đang xử lý",
                        CreatedBy = createdBy,
                        Notes = notes,
                        CreatedAt = purchaseDate

                    };
                    // Thêm nhà cung cấp vào DbSet
                    context.Purchase.Add(newPurchase);

                    // Lưu thay đổi bất đồng bộ và đợi kết quả
                    int rowAffect = await context.SaveChangesAsync(); // await kết quả của SaveChangesAsync()

                    return rowAffect > 0; // Kiểm tra xem có bản ghi nào bị thay đổi không
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và ném lại thông báo lỗi
                throw;
            }
        }


        public async Task<bool> DeletePurchase(int ProductId)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    // Sử dụng await để đợi kết quả trả về từ FirstOrDefaultAsync
                    var productDelete = await context.Purchase.FirstOrDefaultAsync(e => e.PurchaseID == ProductId);

                    if (productDelete != null)
                    {
                        // Xóa đối tượng Employee
                        context.Purchase.Remove(productDelete);

                        // Lưu thay đổi vào cơ sở dữ liệu
                        int affectedRows = await context.SaveChangesAsync(); // Cần await với SaveChangesAsync để làm việc với bất đồng bộ
                        return affectedRows > 0;
                    }

                    return false; // Nếu không tìm thấy employee để xóa
                }
            }
            catch (Exception ex)
            {
                // Có thể thêm log hoặc xử lý lỗi theo cách khác
                throw ex;
            }
        }


        public async Task<bool> UpdateProduct(int id, string name, string barcode, int categoryID, int quantityInStock, decimal price, decimal costPrice, decimal discount, int supplierId, string description, string image)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    // Tìm sản phẩm có ID = id
                    var product = await context.Products.FindAsync(id);

                    if (product != null)
                    {
                        // Kiểm tra các trường bắt buộc không null hoặc không rỗng
                        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Tên không được để trống.");
                        if (string.IsNullOrEmpty(barcode)) throw new ArgumentException("Mã vạch không được để trống.");
                        if (categoryID <= 0) throw new ArgumentException("Danh mục phải hợp lệ.");
                        if (quantityInStock < 0) throw new ArgumentException("Số lượng không được nhỏ hơn 0.");
                        if (price <= 0) throw new ArgumentException("Giá phải lớn hơn 0.");
                        if (costPrice <= 0) throw new ArgumentException("Giá gốc phải lớn hơn 0.");
                        if (discount < 0) throw new ArgumentException("Giảm giá không được âm.");
                        if (supplierId <= 0) throw new ArgumentException("Nhà cung cấp phải hợp lệ.");

                        // Kiểm tra và gán giá trị cho các trường
                        product.Name = name;
                        product.Barcode = barcode;
                        product.CategoryID = categoryID;
                        product.QuantityInStock = quantityInStock; // Cộng thêm số lượng nhập vào
                        product.Price = price;
                        product.CostPrice = costPrice;
                        product.Discount = discount;
                        product.SupplierID = supplierId;
                        product.Description = description; // Cho phép null hoặc rỗng
                        product.Image = !string.IsNullOrEmpty(image) ? image : product.Image; // Image không thể null, giữ nguyên giá trị cũ nếu không cập nhật
                        product.UpdatedAt = DateTime.Now;

                        // Lưu thay đổi vào cơ sở dữ liệu
                        int rowsAffected = await context.SaveChangesAsync();

                        return rowsAffected > 0;
                    }
                    else
                    {
                        Console.WriteLine($"Không tìm thấy sản phẩm với ID: {id}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật sản phẩm: {ex.Message}");
                throw;
            }
        }

        public async Task<object> LoadUsertoComboBox()
        {
            using (var context = new DataProviderEntity())
            {
                // Lấy danh sách tên danh mục từ cơ sở dữ liệu
                var employeesNames = await context.Users.Where(u => u.Role.ToLower() == "quản lý".ToLower())
                                                .ToListAsync();

                // Trả về danh sách categoryNames
                return employeesNames;
            }
        }

        public async Task<List<DTO.Products.Products>> LoadProductFromSupplier(int supplierId)
        {
            using (var context = new DataProviderEntity())
            {
                // Lấy danh sách tên danh mục từ cơ sở dữ liệu
                var product = await context.Products.Where(p => p.SupplierID == supplierId)
                                                .ToListAsync();

                // Trả về danh sách categoryNames
                return product;
            }
        }


    }
}
