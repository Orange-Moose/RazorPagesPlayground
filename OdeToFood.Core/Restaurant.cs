using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Core
{

    public class Restaurant
    {
        public Restaurant(int id, string name, string location, CuisineType cuisine)
        {
            Id = id;
            Name = name;
            Location = location;
            Cuisine = cuisine;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
