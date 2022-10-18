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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
