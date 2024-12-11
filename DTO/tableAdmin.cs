using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Admin")]
    public class tableAdmin
    {
        [Key]
        public string id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
    }
}
