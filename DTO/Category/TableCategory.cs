using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Category
{
    [Table("Category")] // Tên bảng trong cơ sở dữ liệu
    public class TableCategory
    {
        [Key]
        public int Id { get; set; } // Khóa chính

        public string Name { get; set; } // Tên danh mục

        public int QuantityProducts { get; set; } // Số lượng sản phẩm

    }
}

//có rồi tạo làm gì 
//:)))kh có thấy rõ