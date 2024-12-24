using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Sale
{
    [Table("Sale")]
    public class SaleClass
    {
        [Key]
        public int SaleID { get; set; }
        public int CustomerID { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public decimal totalCostPrice { get; set; }
}
}
