using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Users")]  // Đảm bảo rằng tên bảng là đúng
    public class Users
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string? Phone { get; set; }

        public string? Picture { get; set; }  // Sửa từ Piture thành Picture

        public string Role { get; set; }
    }
}
