using Stripe;
using Stripe.Checkout;
using E_Commerce.Services.Interfaces;
using E_Commerce.Models.ViewModels;
using E_Commerce.Models;

namespace E_Commerce.Services.Implementations
{
    public class StripeService : IStripeService
    {
        public StripeService()
        {
            StripeConfiguration.ApiKey = "YOUR_SECRET_KEY";
        }

        public async Task<Session> CreateCheckoutSessionAsync(IEnumerable<CartItem> items)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = items.Select(i => new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmountDecimal = i.Price * 100, // cents
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = i.ProductName
                        }
                    },
                    Quantity = i.Quantity
                }).ToList(),
                Mode = "payment",
                SuccessUrl = "https://localhost:57877/cart/success",
                CancelUrl = "https://localhost:57877/cart"
            };
            var service = new SessionService();
            return await service.CreateAsync(options);
        }
    }
}
