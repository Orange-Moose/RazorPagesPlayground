using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    // Used for EDIT and CREATE
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper) // Inject Html helper that is ussualy awailable in .cshtml files and not in to cshtml.cs files
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
        }


        // Bind user input to property
        // This attribute binds form inputs values to property while invoking OnGet().
        // When user click "Save" on the form, this property is populated with new data
        [BindProperty]
        public Restaurant Restaurant { get; set; } // store model

        public IEnumerable<SelectListItem> Cuisines { get; set; } // store enum

        public IActionResult OnGet(int? restaurantId)
        {
            // Populate select input
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();

            // Returns values for editing "Edit"
            if (restaurantId.HasValue)
            {
                Restaurant = _restaurantData.GetRestaurantById((int)restaurantId);
            }
            else // Initializes data for creating "Add new" (can provide some default values)
            {
                Restaurant = new Restaurant();
            }

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {

            //POST to GET Redirect pattern

            //Check Model validation annotations defined in Restaurant.cs
            if (!ModelState.IsValid)
            {
                // rebuild options in select field on the Edit form as this is generated dynamically and not used in model binding (property Restaurant)
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                // reload the page if there are errors    
                return Page();
            }

            if (Restaurant.Id > 0)
            {
                _restaurantData.UpdateRestaurant(Restaurant); // Restaurant property is already populated by OnGet()
            }
            else
            {
                _restaurantData.CreateRestaurant(Restaurant);
            }

            _restaurantData.CommitChanges();

            // Flash message for next request
            TempData["FlashMessage"] = "Restaurant saved.";

            // Redirect to restautant page if there are no errors
            return RedirectToPage("./Details", new { restaurantId = Restaurant.Id }); // construct nameless object that has restaurantId property that is expected in the ./Details page route
        }

    }
}
