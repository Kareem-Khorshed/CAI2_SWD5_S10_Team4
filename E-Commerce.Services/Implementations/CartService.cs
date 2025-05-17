using E_Commerce.Services.Interfaces;
using E_Commerce.Services.Implementations;
using E_Commerce.Models;
using E_Commerce.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.Services.Implementations
{
    public class CartService : ICartService
    {
        // مثال: هنا تحضر IHttpContextAccessor عشان الكوكيز أو السيّشن
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<IEnumerable<CartItem>> GetAsync(string userId)
        {
            // logic to read from session/cookie
            throw new NotImplementedException();
        }

        public Task AddAsync(string userId, int productId, int qty = 1)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string userId, int productId)
        {
            throw new NotImplementedException();
        }

        public Task ClearAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
