using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Runtime.CompilerServices;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;
        public SqlRestaurantData(OdeToFoodDbContext dbContext)
        {
            db = dbContext;
        }

        

        public Restaurant GetRestaurantById(int id)
        {
            return db.Restaurants.Find(id);
            
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string? name = null)
        {
            var restaurants = db.Restaurants.Where(x => string.IsNullOrEmpty(name) || x.Name.ToLower().Contains(name.ToLower()));
            return restaurants;
        }

        public Restaurant CreateRestaurant(Restaurant newRestaurant)
        {
            db.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }

        public Restaurant DeleteRestaurant(int id)
        {
            var restaurant = GetRestaurantById(id);
            if(restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int CommitChanges()
        {
            return db.SaveChanges(); // updates DB and returns number of updated rows
        }
    }
}
