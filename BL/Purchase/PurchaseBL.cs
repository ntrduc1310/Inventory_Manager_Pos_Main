using DL.Sale;
using DTO.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Purchase
{
    public class PurchaseBL
    {
        public async Task<List<PurchaseClass>> LoadPurchase()
        {
            return await new DL.Purchase.PurchaseDL().LoadPurchase();
        }

        public async Task<bool> addPurchase(int supplierId, decimal totalAmount, string createdBy, string notes)
        {
            return await new DL.Purchase.PurchaseDL().AddPurchase(supplierId, totalAmount, createdBy, notes);
        }

        public async Task<object> loadUsersToComboBox()
        {
            return await new DL.Purchase.PurchaseDL().LoadUsertoComboBox();
        }

        public async Task<string> LoadPurchaseDetailsByIdAsString(int purchaseId)
        {
            return await new DL.Purchase.PurchaseDL().LoadPurchaseDetailsByIdAsString(purchaseId);
        }

        public async Task<bool> updateStatus(string status, int purchaseId)
        {
            return await new DL.Purchase.PurchaseDL().updateStatus(status, purchaseId);
        }

        public async Task<List<DTO.Products.Products>> LoadProductFromSupplier(int supplierId)
        {
            return await new DL.Purchase.PurchaseDL().LoadProductFromSupplier(supplierId);
        }

        public async Task<bool> DeletePurchase(int id)
        {
            return await new DL.Purchase.PurchaseDL().DeletePurchase(id);
        }
    }

}
