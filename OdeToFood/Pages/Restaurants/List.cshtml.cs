using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Runtime.CompilerServices;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config; // appsettings.json
        private readonly IRestaurantData _restaurantData; // OdeToFood.Data project IRestaurantData service 

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            _config = config;
            _restaurantData = restaurantData;
        }


        public string ConfigMessage { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        // Bind user input to property
        // This attribute binds <input name="SearchQuery" value=""> to SearchQuery property while invoking OnGet().
        // So SearchQuery property can be used to get input value and also populate the DOM 
        [BindProperty(SupportsGet = true)] // by default ASP.NET Core is going to bind input properties during POST request, so we use a flag to support GET
        public string SearchQuery { get; set; } // value is set with get request

        // When asp.net core sees this attribute, it goes into the TempData structure and find value with key FlashMessage
        [TempData]
        public string FlashMessage { get; set; }


        public void OnGet() 
        {
            //Few ways to access input value by name field of a form, eg. <input name="lookfor" value="">
            //1. var query = HttpContext.Request.QueryString.Value; // ?lookfor=Cili
            //2. Model binding: OnGet(string searchinputname) or [BindProperty(SupportsGet = true)]

            //ConfigMessage = _config["Message"];
            Restaurants = _restaurantData.GetRestaurantsByName(SearchQuery);
        }
    }
}
