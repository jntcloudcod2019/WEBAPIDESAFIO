using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WebApiDesafio.Models;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
  .MinimumLevel.Information()
.WriteTo.File("Log/log.txt", rollingInterval: RollingInterval.Minute) 
.CreateLogger();

builder.Host.UseSerilog();

builder.Logging.AddSerilog();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Contexto>
(options => options.UseSqlServer("Data Source=DESKTOP-J4KHRVC\\PROJETOSQL;Initial Catalog=ProjetoClientes;Integrated Security=False; User ID=ProjetoDesafio; Password=1234; Timeout=15;Encrypt=False;TrustServerCertificate=False"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
