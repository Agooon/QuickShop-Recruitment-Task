using Newtonsoft.Json;
using QuickShop.CoreBusiness.Models;
using QuickShop.Usecases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace QuickShop.DataStore.StaticFile
{
    public class ProductRepository : IProductRepository
    {
        // To get to Project directory and then to wwwroot
        public static string FilePath = Directory.GetCurrentDirectory() + "\\wwwroot\\data\\data.json";

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            string jsonData = await File.ReadAllTextAsync(FilePath);

            return JsonConvert.DeserializeObject<List<Product>>(jsonData) ?? new List<Product>();
        }

        public async Task<Product> GetProductBySKU(string sku)
        {
            string jsonData = await File.ReadAllTextAsync(FilePath);
            IEnumerable<Product> productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(jsonData) ?? new List<Product>();

            return productList.FirstOrDefault(x => x.SKU == sku);
        }

        public async Task<IEnumerable<Product>> GetProducts(int startIndex, int length)
        {
            if (startIndex < 0 || length <= 0)
                return new List<Product>();

            string jsonData = await File.ReadAllTextAsync(FilePath);
            List<Product> productList = JsonConvert.DeserializeObject<List<Product>>(jsonData) ?? new List<Product>();

            if (productList.Count <= startIndex || productList.Count <= startIndex + length)
                return new List<Product>();

            return productList.GetRange(startIndex, length);
        }

        public async Task<IEnumerable<Product>> GetProductsMatching(string searchString)
        {
            searchString = searchString.ToLower();
            string jsonData = await File.ReadAllTextAsync(FilePath);
            List<Product> productList = JsonConvert.DeserializeObject<List<Product>>(jsonData) ?? new List<Product>();

            return productList.Where(x => x.SKU.ToLower().Contains(searchString) 
                                    || x.Name.ToLower().Contains(searchString) 
                                    || x.Description.ToLower().Contains(searchString));
        }

        public Task<Product> AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> AddProducts(IEnumerable<Product> products)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveProducts(List<Product> products)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
