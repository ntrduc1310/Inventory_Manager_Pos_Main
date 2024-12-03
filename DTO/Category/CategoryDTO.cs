using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Category
{
    internal class CategoryDTO
    {
        public int Id { get; set; }     // ID danh mục
        public string Name { get; set; }  // Tên danh mục

        public int QuantityProduct { get; set; } // Số lượng sản phẩm

        public CategoryDTO(string Id, string Name, string QuantityProduct)
        {
          Id = Id;
          Name = Name;
          QuantityProduct = QuantityProduct;

        }
    }
}
