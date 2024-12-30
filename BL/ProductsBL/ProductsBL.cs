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

        public async Task<bool> UpdateProduct(int id, string name, string barcode, int categoryID, decimal price, decimal costPrice, decimal discount, int supplierId, string description, string image)
        {
            return await new ProductsDL().UpdateProduct(id, name, barcode, categoryID, price, costPrice, discount, supplierId, description, image);
        }

        public async Task<DTO.Products.Products> getAllProducts()
        {
            return await new ProductsDL().getAllProducts();
        }
        public async Task<object> LoadCategoriesIntoComboBox()
        {
            return await new ProductsDL().LoadCategoriesIntoComboBox();
        }

        public async Task<object> LoadSupplierIntoComboBox()
        {
            return await new ProductsDL().LoadSupplierIntoComboBox();
        }

        public async Task<bool> AddQuantityProduct(int productId, int quantity)
        {
            return await new ProductsDL().AddQuantityProduct(productId, quantity);
        }

        public async Task<bool> SubtractQuantityProduct(int productId, int quantity)
        {
            return await new ProductsDL().SubtractQuantityProduct(productId, quantity);
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
        // Add this method to your ProductsBL class
        public async Task<List<DTO.Products.Products>> SearchProducts(string searchText)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchText))
                    return await LoadProducts();

                var products = await LoadProducts();
                searchText = searchText.ToLower().Trim();

                return products.Where(p =>
                    (p.Name?.ToLower().Contains(searchText) ?? false) ||
                    (p.Barcode?.ToLower().Contains(searchText) ?? false) ||
                    (p.Description?.ToLower().Contains(searchText) ?? false) ||
                    p.ProductID.ToString().Contains(searchText) ||
                    p.CategoryID.ToString().Contains(searchText) ||
                    p.SupplierID.ToString().Contains(searchText) ||
                    p.Price.ToString().Contains(searchText) ||
                    p.CostPrice.ToString().Contains(searchText) ||
                    p.QuantityInStock.ToString().Contains(searchText)
                ).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchProducts: {ex.Message}");
                return new List<DTO.Products.Products>();
            }
        }

        public async Task<DTO.Products.Products> getProducts(int productId)
        {
            return await new ProductsDL().getProducts(productId);
        }

        public async Task<string> LoadProductDetailsByIdAsString(int productId)
        {
            return await new ProductsDL().LoadProductDetailsByIdAsString(productId);
        }

        public async Task<List<DTO.Products.Products>> searchProduct(string txt)
        {
            return await new ProductsDL().searchProduct(txt);
        }
    }
}
