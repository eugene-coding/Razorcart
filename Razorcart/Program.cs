using Microsoft.EntityFrameworkCore;

using Razorcart.Areas.Admin.Services.Catalog;
using Razorcart.Data;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddRazorPages();
services.AddLocalization();

services.AddDbContext<Context>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Razorcart");
    var serverVersion = ServerVersion.AutoDetect(connectionString);

    options
        .UseLazyLoadingProxies()
        .UseMySql(connectionString, serverVersion);
});

services.AddScoped<IAttributeGroupService, AttributeGroupService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    SeedData.Initialize(serviceProvider);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
