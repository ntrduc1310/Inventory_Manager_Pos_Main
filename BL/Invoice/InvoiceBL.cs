using DTO.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Invoice
{
    public class InvoiceBL
    {
        public async Task<bool> UpdatePaymentStatus(int invoiceId, string status,
           string method, string qrData)
        {
            return await new DL.Invoice.InvoiceDL()
                .UpdatePaymentStatus(invoiceId, status, method, qrData);
        }

        public string GenerateQRCodeData(InvoiceClass invoice)
        {
            var qrData = new
            {
                invoice.InvoiceID,
                invoice.CustomerID,
                invoice.TotalAmount,
                DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            return System.Text.Json.JsonSerializer.Serialize(qrData);
        }
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
