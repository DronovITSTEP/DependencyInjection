using DependencyInjection.Repositories;
using DependencyInjection.Models;
using DependencyInjection.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddTransient<IRepository, Repository>();
//builder.Services.AddTransient<IStorage, Storage>();

IWebHostEnvironment env = builder.Environment;
builder.Services.AddTransient<IRepository>(provider =>
{
    if (env.IsDevelopment())
    {
        var x = provider.GetService<Repository>();
        return x;
    }
    else
    {
        return new ProductionRepository();
    }
});

builder.Services.AddTransient<Repository>();

builder.Services.AddTransient<ProductSum>();

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
