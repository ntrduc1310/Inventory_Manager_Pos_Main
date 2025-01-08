using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Threading.Tasks;
using DTO.Category;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace DL.Category
{
    public class CategoryDL : DataProviderEntity
    {
        // Tải danh sách Category
        public async Task<List<DTO.Category.TableCategory>> LoadCategory()
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    // Lấy tất cả các danh mục từ cơ sở dữ liệu
                    return await context.Category.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading categories from database: {ex.Message}");
                throw;
            }
        }

        // Thêm Category
        public async Task<bool> AddCategory(string name)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    var newCategory = new DTO.Category.TableCategory
                    {
                        Name = name,
                    };

                    // Kiểm tra nếu tên danh mục đã tồn tại
                    bool exists = await context.Category.AnyAsync(c => c.Name == name);
                    if (exists)
                    {
                        return false; // Trả về false nếu danh mục đã tồn tại
                    }

                    // Thêm danh mục vào DbSet
                    context.Category.Add(newCategory);

                    // Lưu thay đổi bất đồng bộ và đợi kết quả
                    int rowAffect = await context.SaveChangesAsync(); // await kết quả của SaveChangesAsync()

                    return rowAffect > 0; // Kiểm tra xem có bản ghi nào bị thay đổi không
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và ném lại thông báo lỗi:)))))))
                throw new Exception("Đã xảy ra lỗi khi thêm danh mục.", ex);
            }
        }

        // Xóa Category
        public async Task<bool> DeleteCategory(int categoryId)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    // Xóa tất cả các bản ghi liên quan trong bảng Products
                    var relatedProducts = context.Products.Where(p => p.CategoryID == categoryId);
                    context.Products.RemoveRange(relatedProducts);

                    // Tìm danh mục cần xóa
                    var categoryToDelete = await context.Category.FirstOrDefaultAsync(c => c.Id == categoryId);
                    if (categoryToDelete != null)
                    {
                        // Xóa danh mục
                        context.Category.Remove(categoryToDelete);

                        // Lưu thay đổi vào cơ sở dữ liệu
                        int affectedRows = await context.SaveChangesAsync();
                        return affectedRows > 0;
                    }

                    return false;
                }
            }
            catch (DbUpdateException dbEx)
            {
                // Log lỗi ràng buộc nếu cần
                Console.WriteLine($"Database update error: {dbEx.Message}");
                return false; // Trả về false nếu xảy ra lỗi ràng buộc
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting category: {ex.Message}");
                throw;
            }
        }


        public async Task<bool> UpdateCategory(int categoryId, string name)
        {
            try
            {
                // Sử dụng DataProviderEntity để kết nối với cơ sở dữ liệu
                using (var context = new DataProviderEntity())
                {
                    // Tìm người dùng có ID = id

                    var user = context.Category.Find(categoryId);
                    bool exists = await context.Category.AnyAsync(c => c.Name == name);
                    if (exists)
                    {
                        return false; // Trả về false nếu danh mục đã tồn tại
                    }

                    // Kiểm tra nếu người dùng tồn tại
                    if (user != null)
                    {
                        user.Name = string.IsNullOrEmpty(name) ? user.Name : name;
                       
                        // Lưu thay đổi vào cơ sở dữ liệu
                        int rowsAffected = await context.SaveChangesAsync();
                        Console.WriteLine($"Số bản ghi bị ảnh hưởng: {rowsAffected}");

                        return rowsAffected > 0; // Trả về true nếu có thay đổi
                    }
                    else
                    {
                        // Ghi lại lỗi khi không tìm thấy người dùng
                        Console.WriteLine($"Không tìm thấy người dùng với ID: {categoryId}");
                        return false; // Trả về false khi không tìm thấy người dùng
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi lại chi tiết lỗi vào console
                Console.WriteLine($"Lỗi khi cập nhật người dùng: {ex.Message}");
                Console.WriteLine($"Chi tiết lỗi: {ex.StackTrace}");

                // Ném lại lỗi để dừng chương trình và dễ dàng kiểm soát lỗi
                throw; // Ném lại lỗi để thông báo và dừng chương trình
            }
        }
        public async Task<List<DTO.Category.TableCategory>> SearchCategories(string searchText)
        {
            try
            {
                // If no search text is provided, load all categories
                if (string.IsNullOrWhiteSpace(searchText))
                    return await LoadCategory();

                // Load all categories
                var categories = await LoadCategory();
                searchText = searchText.ToLower().Trim();  // Normalize search text

                // Filter the categories based on the search text
                return categories.Where(c =>
                    c.Id.ToString().Contains(searchText) ||
                    (c.Name?.ToLower().Contains(searchText) ?? false)
                ).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchCategories: {ex.Message}");
                return new List<DTO.Category.TableCategory>();  // Return an empty list in case of an error
            }
        }


    }
}
