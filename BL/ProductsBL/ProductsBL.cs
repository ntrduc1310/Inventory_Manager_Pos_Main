using DL.Products;
using DL.Suppiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ProductsBL
{
    public class ProductsBL
    {
        public async Task<List<DTO.Products.Products>> LoadProducts()
        {
            return await new ProductsDL().LoadProducts();
        }

        public async Task<bool> AddProducts(string name, string barcode, int categoryID, int quantityInStock, decimal price, decimal costPrice, decimal discount, int supplierId, string description, string image)
        {
            return await new ProductsDL().AddProducts(name, barcode, categoryID, quantityInStock, price, costPrice, discount, supplierId, description, image);
        }

        public async Task<bool> DeleteProducts(int ProductId)
        {
            return await new ProductsDL().DeleteProducts(ProductId);
        }

        public async Task<bool> UpdateProduct(int id, string name, string barcode, int categoryID, int quantityInStock, decimal price, decimal costPrice, decimal discount, int supplierId, string description, string image)
        {
            return await new ProductsDL().UpdateProduct(id, name, barcode, categoryID, quantityInStock, price, costPrice, discount, supplierId, description, image);
        }

        public async Task<object> LoadCategoriesIntoComboBox()
        {
            return await new ProductsDL().LoadCategoriesIntoComboBox();
        }

        public async Task<object> LoadSupplierIntoComboBox()
        {
            return await new ProductsDL().LoadSupplierIntoComboBox();
        }

        //public async Task<List<DTO.Products.Products>> LoadProductsFromCustomer(int customerId)
        //{
        //    return await new ProductsDL().LoadProductsFromCustomer(customerId);
        //}
        public async Task<string> GetCategoryNameById(int categoryId)
        {
            return await new ProductsDL().GetCategoryNameById(categoryId);
        }

        public async Task<string> GetSupplierNameById(int employeeId)
        {
            return await new ProductsDL().GetSupplierNameById(employeeId);
        }
        public async Task<bool> addQuantityCategory(int categoryId, int quantity)
        {
            return await new ProductsDL().addQuantityCategory(categoryId, quantity);
        }

        public async Task<bool> subtractQuantityCategory(int categoryId, int quantity)
        {
            return await new ProductsDL().subtractQuantityCategory(categoryId, quantity);
        }


        public async Task<DTO.Products.Products> getProducts(int productId)
        {
            return await new ProductsDL().getProducts(productId);
        }

        public async Task<string> LoadProductDetailsByIdAsString(int productId)
        {
            return await new ProductsDL().LoadProductDetailsByIdAsString(productId);
        }
    }
}
