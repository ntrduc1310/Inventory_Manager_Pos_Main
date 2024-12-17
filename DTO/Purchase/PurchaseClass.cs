using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Purchase
{
    [Table("Purchase")]
    public class PurchaseClass
    {
        [Key]
        public int PurchaseID { get; set; }
        public int SupplierId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }    

        public string Status {  get; set; }

        public string CreatedBy { get; set; }
        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
