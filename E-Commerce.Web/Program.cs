using E_Commerce.Data;
using E_Commerce.Models.Settings;
using E_Commerce.Models.ViewModels;
using E_Commerce.Services.Implementations;
using E_Commerce.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// إعداد الاتصال بقاعدة البيانات
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("con")));


// إضافة Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// إعداد الكوكيز
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

// إضافة Swagger
builder.Services.AddSwaggerGen();

// إضافة MVC
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
// pull Stripe config into a POCO
builder.Services.Configure<StripeSettings>(
  builder.Configuration.GetSection("Stripe")
);
// register your IStripeService implementation
builder.Services.AddScoped<IStripeService, StripeService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My MVC API V1");
    });
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
