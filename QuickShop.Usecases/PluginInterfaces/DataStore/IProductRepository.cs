using QuickShop.CoreBusiness.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickShop.Usecases.PluginInterfaces.DataStore
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetProducts(int startIndex, int endIndex);
        Task<IEnumerable<Product>> GetProductsMatching(string searchString);
        Task<Product> GetProductBySKU(string sku);

        // No use in current static file, but for the future, 
        // we can implement some database to add, update and delete data
        Task<Product> AddProduct(Product product);
        Task<IEnumerable<Product>> AddProducts(IEnumerable<Product> products);
        Task<Product> UpdateProduct(Product product);
        Task<bool> RemoveProductById(int productId);
        Task<bool> RemoveProducts(List<Product> products);
    }
}
