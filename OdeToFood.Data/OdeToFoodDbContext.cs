using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Since Data is stored in another project, use -s flag to run EF commands: dotnet ef migrations add MigrationName -s ../OdeToFood/OdeToFood.csproj

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options): base(options) {}

        //Collection name "Restaurants"
        public DbSet<Restaurant> Restaurants { get; set; } = null!; // Queries agains DbSet will be translated to queries agains DB
    }
}
