using E_Commerce.Models;
using E_Commerce.Services.ProductManagement;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace E_Commerce.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        // Constructor مع Dependency Injection
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // Action لعرض قائمة المنتجات
        public IActionResult Index()
        {
            List<Product> products = _productService.GetAllProducts();
            return View(products);
        }
    }
}
