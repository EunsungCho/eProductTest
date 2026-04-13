using eProductTest.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<eStoreTestDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("appDbConnection"));
});
builder.Services.AddScoped<IDataRepository, StoreDataRepository>();
builder.Services.AddScoped<IOrderRepository, StoreOrderRepository>();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
app.UseSession();

app.MapControllerRoute("catpage", "{category}/Page{productPage:int}", new {controller="home", action="index"});
app.MapControllerRoute("page", "Page{productPage:int}", new { controller = "home", action = "index", productPage = 1 });
app.MapControllerRoute("category", "{category}", new {controller="home", action="index", productPage=1 });
app.MapControllerRoute("pagination", "Product/Page{productPage}", new {Controller="Home", action="Index", productPage=1});
app.MapDefaultControllerRoute();
app.MapRazorPages();

InitializeData.SeedData(app);

app.Run();
