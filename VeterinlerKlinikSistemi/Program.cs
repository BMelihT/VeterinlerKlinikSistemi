using Microsoft.EntityFrameworkCore;
using VeterinlerKlinikSistemi.Veri;

var builder = WebApplication.CreateBuilder(args);

// Veritabanı (SQL Server LocalDB)
var baglantiCumlesi = builder.Configuration.GetConnectionString("VarsayilanBaglanti")
    ?? throw new InvalidOperationException("'VarsayilanBaglanti' bağlantı dizesi bulunamadı.");

builder.Services.AddDbContext<UygulamaDbContext>(options =>
    options.UseSqlServer(baglantiCumlesi));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
