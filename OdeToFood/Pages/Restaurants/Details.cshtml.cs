using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly IRestaurantData _restaurantData
            ;
        public DetailsModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public Restaurant Restaurant { get; set; }

        // When asp.net core sees this attribute, it goes into the TempData structure and find value with key FlashMessage
        [TempData]
        public string FlashMessage { get; set; }

        public IActionResult OnGet(int restaurantId) // IAction result = response in nodeJS
        {
            Restaurant = _restaurantData.GetRestaurantById(restaurantId);

            if (Restaurant == null) 
                return RedirectToPage("./NotFound"); // generates 302 status and renders specified cshtml template

            return Page(); // loads "/Details" page

        }
    }
}
