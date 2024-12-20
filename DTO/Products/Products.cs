using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Products
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public int ProductID {  get; set; }
        public string Name { get; set; }

        public string Barcode { get; set; }

        public int CategoryID { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }

        public decimal CostPrice { get; set; }

        public decimal Discount { get; set; }

        public int SupplierID { get; set; }

        public string? Description { get; set; }

        public string? Image {  get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
