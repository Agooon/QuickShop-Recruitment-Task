using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using QuickShop.App.Models;
using QuickShop.App.Utility;
using QuickShop.CoreBusiness.Models;
using QuickShop.Usecases.PluginInterfaces.DataStore;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuickShop.App.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageIndex = 1, int quantity = 10, string searchString = "")
        {
            _logger.LogInformation($"Called index method with: pageIndex:{pageIndex} | quantity:{quantity} | searchString:{searchString}");

            Task<IEnumerable<Product>> productList;
            if (string.IsNullOrWhiteSpace(searchString))
                productList = _productRepository.GetAllProducts();
            else
                productList = _productRepository.GetProductsMatching(searchString);

            // If not in allowed values, return the one closest to it
            quantity = PagingUtils.CheckProductNumberValue(quantity);

            ViewBag.allowedPageValues = new SelectList(PagingUtils.AllowedProductValues);
            ViewBag.quantity = quantity;
            ViewBag.searchString = searchString;

            var model = PagingList.Create(await productList, quantity, pageIndex);
            return View(model);
        }

        // To get the parameters in a link I have to redirect it to HttpGet method
        // In case of search pages, the ability to copy-paste link is important
        [HttpPost]
        public async Task<IActionResult> IndexPost(int pageIndex = 1, int quantity = 10, string searchString = "")
        {
            _logger.LogInformation("Called IndexPost method");
            return await Task.Run<IActionResult>(() =>
            {
                return RedirectToAction("Index", new { pageIndex, quantity, searchString });
            });
        }

        // For showing the modal of product
        [HttpGet]
        public async Task<IActionResult> GetProduct(string sku)
        {
            _logger.LogInformation("Called GetProduct method");
            var model = await _productRepository.GetProductBySKU(sku);
            return PartialView("PartialViews/_ProductModalPartial", model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
