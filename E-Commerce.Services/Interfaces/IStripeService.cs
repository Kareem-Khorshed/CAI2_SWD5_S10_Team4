using Stripe.Checkout;
using E_Commerce.Models.ViewModels;
using E_Commerce.Models;

namespace E_Commerce.Services.Interfaces
{
    public interface IStripeService
    {
        Task<Session> CreateCheckoutSessionAsync(IEnumerable<CartItem> items);
    }
}
