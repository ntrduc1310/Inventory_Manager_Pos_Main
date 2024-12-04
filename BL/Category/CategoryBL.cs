using DL.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Category
{
    public class CategoryBL
    {
        // Phương thức tải tất cả danh sách Category
        public async Task<List<DTO.Category.TableCategory>> LoadCategory()
        {
            return await new CategoryDL().LoadCategory();
        }

        
        // Phương thức thêm mới Category
        public async Task<bool> AddCategory(string Name)
        {
            return await new CategoryDL().AddCategory(Name);
        }

        // Phương thức xóa Category theo ID
        public async Task<bool> DeleteCategory(int CategoryId)
        {
            return await new CategoryDL().DeleteCategory(CategoryId);
        }
     

        // Phương thức cập nhật thông tin Category
        public async Task<bool> UpdateCategory(int CategoryId, string name)
        {
            return await new CategoryDL().UpdateCategory(CategoryId, name);
        }
    }
}
