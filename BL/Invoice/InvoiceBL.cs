using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Invoice
{
    public class InvoiceBL
    {
        public async Task<List<DTO.Invoice.InvoiceClass>> LoadInvoice()
        {
            return await new DL.Invoice.InvoiceDL().LoadInvoice();
        }

        public async Task<bool> AddInvoice(int CustomerId, int SaleId, decimal totalAmount, string productNameList, string productQuantityList, string productPriceList)
        {
            return await new DL.Invoice.InvoiceDL().AddInvoice(CustomerId, SaleId, totalAmount, productNameList, productQuantityList, productPriceList);
        }

        public async Task<DTO.Invoice.InvoiceClass> SaleIdGetInvoice(int saleId)
        {
            return await new DL.Invoice.InvoiceDL().SaleIdGetInvoice(saleId);
        }
    }
}
