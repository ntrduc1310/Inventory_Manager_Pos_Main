using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Invoice
{
    [Table("Invoice")]

    public class InvoiceClass
    {
        // Properties
        [Key]
        public int InvoiceID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int CustomerID { get; set; }
        public int SaleID { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Notes { get; set; }

        public string ProductNameList { get; set; }

        public string ProductQuantityList { get; set; }

        public string ProductPriceList { get; set; }

    }
          
}
