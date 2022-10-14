using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Core
{

    public class Restaurant
    {
        public Restaurant() {} // parameterless constructor is used if user data is sent from post request, etc.
        public Restaurant(int id, string name, string location, CuisineType cuisine): this()
        {
            Id = id;
            Name = name;
            Location = location;
            Cuisine = cuisine;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "The dfsdfName is required"), MaxLength(80) ] // model validation attributes
        public string Name { get; set; }
        
        [Required(ErrorMessage = "The Location is sdfsrequired")]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
