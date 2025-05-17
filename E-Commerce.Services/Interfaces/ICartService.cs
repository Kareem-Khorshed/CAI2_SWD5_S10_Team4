using E_Commerce.Models.ViewModels;
using E_Commerce.Models;

namespace E_Commerce.Services.Interfaces;

public interface ICartService
{
    Task<IEnumerable<CartItem>> GetAsync(string userId);
    Task AddAsync(string userId, int productId, int qty = 1);
    Task RemoveAsync(string userId, int productId);
    Task ClearAsync(string userId);

}
