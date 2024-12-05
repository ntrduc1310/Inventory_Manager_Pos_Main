using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Customer
{
    [Table("Customer")]
    public class TableCustomer
    {
        [Key]
        public int Id { get; set; } // Khóa chính

      
        public string Name { get; set; } // Tên khách hàng

       
        public string Phone { get; set; } // Số điện thoại (chuỗi)


        public string Email { get; set; } // Email khách hàng
    }
}
