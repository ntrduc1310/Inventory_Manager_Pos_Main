using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace DL.Products
{
    public class ProductsDL:DataProviderEntity
    {
        public async Task<List<DTO.Products.Products>> LoadProducts()
        {
            using (var context = new DataProviderEntity()) // DataProviderEntity là DbContext của bạn
            {
                return await context.Products.ToListAsync();
            }
        }
        public async Task<bool> AddProducts(string name, string barcode, int categoryID, int quantityInStock, decimal price, decimal costPrice, decimal discount, int supplierId, string description, string image)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                   

                    // Kiểm tra nếu email đã tồn tại
                    bool exists = await context.Products.AnyAsync(a => a.Barcode == barcode);
                    if (exists)
                    {
                        return false; // Trả về false nếu nhà cung cấp đã tồn tại
                    }

                    var newProduct =  new DTO.Products.Products
                    {
                        Name = name,
                        Barcode = barcode,
                        CategoryID = categoryID,
                        QuantityInStock = quantityInStock,
                        Price = price,
                        CostPrice = costPrice,
                        Discount = discount,
                        SupplierID = supplierId,
                        Description = description,
                        Image = image,
                        CreatedAt = DateTime.Now

                    };
                    // Thêm nhà cung cấp vào DbSet
                    context.Products.Add(newProduct);

                    // Lưu thay đổi bất đồng bộ và đợi kết quả
                    int rowAffect = await context.SaveChangesAsync(); // await kết quả của SaveChangesAsync()

                    return rowAffect > 0; // Kiểm tra xem có bản ghi nào bị thay đổi không
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và ném lại thông báo lỗi
                throw new Exception("Đã xảy ra lỗi khi thêm nhà cung cấp.", ex);
            }
        }


        public async Task<bool> DeleteProducts(int ProductId)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    // Sử dụng await để đợi kết quả trả về từ FirstOrDefaultAsync
                    var productDelete = await context.Products.FirstOrDefaultAsync(e => e.ProductID== ProductId);

                    if (productDelete != null)
                    {
                        // Xóa đối tượng Employee
                        context.Products.Remove(productDelete);

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

        public async Task<string> getValueByIdCategory(int id)
        {
            using (var context = new DataProviderEntity())
            {
                var category = await context.Category.FindAsync(id);
                if (category != null)
                {
                    // Kiểm tra nếu Name không null trước khi trả về
                    return category.Name ?? "Category Name not found";
                }
                return "Category not found"; // Trả về thông báo nếu không tìm thấy Category
            }
        }

        public async Task<object> LoadCategoriesIntoComboBox()
        {
            using (var context = new DataProviderEntity())
            {
                // Lấy danh sách tên danh mục từ cơ sở dữ liệu
                var categoryNames = await context.Category
                                                .ToListAsync();

                // Trả về danh sách categoryNames
                return categoryNames;
            }
        }

        public async Task<object> LoadSupplierIntoComboBox()
        {
            using (var context = new DataProviderEntity())
            {
                // Lấy danh sách tên danh mục từ cơ sở dữ liệu
                var employeesNames = await context.Suppiler
                                                .ToListAsync();

                // Trả về danh sách categoryNames
                return employeesNames;
            }
        }

        public async Task<string> GetCategoryNameById(int categoryId)
        {
            using (var context = new DataProviderEntity())
            {
                // Lấy tên danh mục từ cơ sở dữ liệu theo ID
                var categoryName = await context.Category
                                                .Where(c => c.Id == categoryId)
                                                .Select(c => c.Name)
                                                .FirstOrDefaultAsync();

                return categoryName ?? "Unknown"; // Trả về tên nếu tìm thấy, nếu không trả về "Unknown"
            }
        }

        public async Task<string> GetSupplierNameById(int supplierId)
        {
            using (var context = new DataProviderEntity())
            {
                // Lấy tên danh mục từ cơ sở dữ liệu theo ID
                var supplierName = await context.Suppiler
                                                .Where(c => c.Id == supplierId)
                                                .Select(c => c.Name)
                                                .FirstOrDefaultAsync();

                return supplierName ?? "Unknown"; // Trả về tên nếu tìm thấy, nếu không trả về "Unknown"
            }
        }



        public async Task<bool> addQuantityCategory(int categoryId,int quantity)
        {
            using (var context = new DataProviderEntity())
            {

                // Tìm sản phẩm theo ID
                var category = context.Category.FirstOrDefault(p => p.Id == categoryId);

                if (category != null)
                {
                    // Cập nhật số lượng
                    category.QuantityProducts += quantity;

                    // Lưu thay đổi
                    context.SaveChanges();

                    Console.WriteLine($"Cập nhật thành công. Số lượng mới: {category.QuantityProducts}");
                    return true;
                }
                else
                {
                    Console.WriteLine("Không tìm thấy sản phẩm với ID được cung cấp.");
                    return false;
                }
            }
        }


    }
}
