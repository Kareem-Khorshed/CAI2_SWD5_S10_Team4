using System.Security.Claims;
using E_Commerce.Services.Interfaces;
using E_Commerce.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class PaymentsController : Controller
{
    private readonly ICartService _cart;
    private readonly IStripeService _stripe;

    public PaymentsController(ICartService cart, IStripeService stripe)
    {
        _cart = cart;
        _stripe = stripe;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSession()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        var items = await _cart.GetAsync(userId);
        var session = await _stripe.CreateCheckoutSessionAsync(items);
        return Redirect(session.Url);
    }

    public async Task<IActionResult> Success()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        await _cart.ClearAsync(userId);
        return View();
    }

    public IActionResult Cancel() => View();
}
