using E_Commerce.Data;
using E_Commerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerce.Services.ProductManagement
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        // Get Products From Databsase
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
    }
}
