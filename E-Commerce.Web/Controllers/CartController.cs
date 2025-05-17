using E_Commerce.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Authorize]
public class CartController : Controller
{
    private readonly ICartService _cart;

    public CartController(ICartService cart) => _cart = cart;

    // GET /Cart
    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        var items = await _cart.GetAsync(userId);
        return View(items);
    }

    // POST /Cart/Add/5
    [HttpPost]
    public async Task<IActionResult> Add(int productId, int qty = 1)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        await _cart.AddAsync(userId, productId, qty);
        return RedirectToAction(nameof(Index));
    }

    // POST /Cart/Remove/5
    [HttpPost]
    public async Task<IActionResult> Remove(int productId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        await _cart.RemoveAsync(userId, productId);
        return RedirectToAction(nameof(Index));
    }

    // POST /Cart/Clear
    [HttpPost]
    public async Task<IActionResult> Clear()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        await _cart.ClearAsync(userId);
        return RedirectToAction(nameof(Index));
    }

    // GET /Cart/Checkout
    public async Task<IActionResult> Checkout()
    {
        // load items & pass to Stripe view
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        var items = await _cart.GetAsync(userId);
        return View(items);
    }
}
