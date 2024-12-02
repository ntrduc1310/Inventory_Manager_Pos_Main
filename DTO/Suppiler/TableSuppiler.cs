using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DTO.Suppiler
{ 
    [Table("Suppiler")]

    public class TableSuppiler
    {
        [Key]
        public int Id { get; set; }
       public string Name { get; set; }   

        public string Phone { get; set; }  

        public string Email { get; set; }
        
        public string Adress { get; set; }
    }
}
