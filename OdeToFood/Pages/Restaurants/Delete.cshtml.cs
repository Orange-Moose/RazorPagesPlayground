using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;

        public DeleteModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public Restaurant Restaurant { get; set; } // Holds data to pass to the view

        //Render page to confirm deletion
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetRestaurantById(restaurantId); // populates data to pass to the view
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound"); // redirect NotFound.cshtml view
            }

            return Page(); // render the Delete.cshtml view
        }

        // Post to confirm deletion and redirect
        public IActionResult OnPost(int restaurantId)
        {

            var restaurant = _restaurantData.GetRestaurantById(restaurantId);
            if(restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            
            _restaurantData.DeleteRestaurant(restaurantId);

            _restaurantData.CommitChanges();

            // Flash message for next request
            TempData["FlashMessage"] = $"Restaurant \"{restaurant.Name}\" was deleted.";

            return RedirectToPage("./List");
        }
    }
}
