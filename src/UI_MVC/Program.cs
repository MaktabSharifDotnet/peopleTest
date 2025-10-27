// این دو using برای کار با دیتابیس لازم هستند
using Microsoft.EntityFrameworkCore;
using UI_MVC.Models.DataBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// --- این خط گمشده بود ---
// این کد AppDbContext را به برنامه معرفی می‌کند
// تا بتواند آن را به کنترلرها (مثل PeopleController) تزریق کند
builder.Services.AddDbContext<AppDbContext>();
// ------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();