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

        Restaurant DeleteRestaurant(int id);

        int GetCountOfResturants();

        int CommitChanges();
    }
}
