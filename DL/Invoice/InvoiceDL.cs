using DTO.Invoice;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Invoice
{
    public class InvoiceDL
    {
        public async Task<List<DTO.Invoice.InvoiceClass>> LoadInvoice()
        {
            using(var context = new DataProviderEntity())
            {
                return await context.Invoice.ToListAsync();
            }
        }
        public async Task<bool> UpdatePaymentStatus(int invoiceId, string status,
            string method, string qrData)
        {
            using (var context = new DataProviderEntity())
            {
                var invoice = await context.Invoice
                    .FirstOrDefaultAsync(i => i.InvoiceID == invoiceId);
                if (invoice != null)
                {
                    invoice.PaymentStatus = status;
                    invoice.PaymentMethod = method;
                    invoice.PaymentDate = DateTime.Now;
                    invoice.QRCodeData = qrData;
                    return await context.SaveChangesAsync() > 0;
                }
                return false;
            }
        }

        public async Task<bool> AddInvoice(int CustomerId, int SaleId, decimal totalAmount, string productNameList, string productQuantityList, string productPriceList)
        {
            using (var context = new DataProviderEntity())
            {
                InvoiceClass invoice = new InvoiceClass()
                {
                    InvoiceDate = DateTime.Now,
                    CustomerID = CustomerId,
                    SaleID = SaleId,
                    TotalAmount = totalAmount,
                    ProductNameList = productNameList,
                    ProductQuantityList = productQuantityList,
                    ProductPriceList = productPriceList,
                    PaymentStatus = "Pending"
                };
                context.Invoice.Add(invoice);

                // Lưu thay đổi bất đồng bộ và đợi kết quả
                int rowAffect = await context.SaveChangesAsync(); // await kết quả của SaveChangesAsync()

                return rowAffect > 0; // Kiểm tra xem có bản ghi nào bị thay đổi không
            }
        }


        public async Task<DTO.Invoice.InvoiceClass> SaleIdGetInvoice(int saleId)
        {
            using (var context = new DataProviderEntity())
            {
                return await context.Invoice.FirstOrDefaultAsync(i => i.SaleID == saleId);
            }
        }

    }
}
