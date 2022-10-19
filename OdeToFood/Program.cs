using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//TEMP - register temporary data store for development and testing
//builder.Services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();

//register sql db data store service
builder.Services.AddScoped<IRestaurantData, SqlRestaurantData>();

builder.Services.AddDbContext<OdeToFoodDbContext>(dbContextOptions =>
{
    dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:OdeToFoodDbConnectionString"]);
}); // register Db context

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Middleware, process HTTP requests, order matters

app.UseHttpsRedirection();
app.UseStaticFiles(); // Allows static files from wwwroot (default on), when used without arguments.

app.UseNodeModules(); // Allows serving of static files from node_modules folder, requires library nuget OdeToCode by Scott Allen

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages(); // adds endpoints for Razor pages
app.UseEndpoints(endpoints => endpoints.MapControllers()); // adds endpoints for controller actions

app.Run();
