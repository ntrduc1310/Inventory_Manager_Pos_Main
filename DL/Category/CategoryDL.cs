using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Threading.Tasks;
using DTO.Category;
using Microsoft.EntityFrameworkCore;

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
        public async Task<bool> AddCategory(string name, int quantityProducts)
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    var newCategory = new DTO.Category.TableCategory
                    {
                        Name = name,
                        QuantityProducts = quantityProducts
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
                // Xử lý lỗi và ném lại thông báo lỗi
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
                    // Sử dụng await để đợi kết quả trả về từ FirstOrDefaultAsync
                    var categoryToDelete = await context.Category.FirstOrDefaultAsync(c => c.Id == categoryId);

                    if (categoryToDelete != null)
                    {
                        // Xóa đối tượng Category
                        context.Category.Remove(categoryToDelete);

                        // Lưu thay đổi vào cơ sở dữ liệu
                        int affectedRows = await context.SaveChangesAsync(); // Cần await với SaveChangesAsync để làm việc với bất đồng bộ
                        return affectedRows > 0;
                    }

                    return false; // Nếu không tìm thấy category để xóa
                }
            }
            catch (Exception ex)
            {
                // Có thể thêm log hoặc xử lý lỗi theo cách khác
                throw ex;
            }
        }

        public async Task<bool> UpdateCategory(int categoryId, string name, int quantityProducts)
        {
            throw new NotImplementedException();
        }
    }
}
