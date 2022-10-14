using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string? name = null);
        Restaurant GetRestaurantById(int id);
        Restaurant UpdateRestaurant(Restaurant updatedRestaurant);
        Restaurant CreateRestaurant(Restaurant newRestaurant);
        int CommitChanges();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        public List<Restaurant> restaurantList = new List<Restaurant>();
        public InMemoryRestaurantData()
        {
            restaurantList.Add(new Restaurant(1, "Brussels Mussels", "Vilnius", CuisineType.Mexican));
            restaurantList.Add(new Restaurant(2, "Scott's Pizza", "New York", CuisineType.Italian));
            restaurantList.Add(new Restaurant(3, "La Costa", "California", CuisineType.Indian));
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return restaurantList.Where(x => string.IsNullOrEmpty(name) || x.Name.ToLower().Contains(name.ToLower())).OrderBy(x => x.Name);
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurantList.FirstOrDefault(x => x.Id == id);
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var restaurant = restaurantList.FirstOrDefault(x => x.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public Restaurant CreateRestaurant(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurantList.Max(x => x.Id) + 1;
            restaurantList.Add(newRestaurant);
            return newRestaurant;
        }

        public int CommitChanges()
        {
            return 1;
        }
    }
}
