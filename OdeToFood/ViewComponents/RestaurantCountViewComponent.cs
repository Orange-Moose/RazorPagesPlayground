using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.ViewComponents
{
    // Note: ViewComponent instance does not respond to http requests it is more like a partial to be embeded in other view
    public class RestaurantCountViewComponent: ViewComponent
    {
        private readonly IRestaurantData _restaurantData;
        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        // Just like IActionResult it is a promise
        public IViewComponentResult Invoke()
        {
            /*Unlike a razor page where I can say return Page() to render the associated .cshtml file
             I have to return a View, so somewhere in the the file system there is gonna be .cshtml file 
            that represents the view for this View component.

            This is significant different with the View components and Razor pages:
            View conmponents work like MVC framework inside ASP.NET Core. You hava an Action method that builds a model
            and you pass that model to the View() by returning some sort of view result.

            While in Razor Page you can set a property in a .cshtml.cs file and then bind it to the .cshtml file.
             */



            var restaurantCount = _restaurantData.GetCountOfResturants();
            return View("Default", restaurantCount); // Looks into the /Components/RestaurantCount/Default.cshtml
        }

    }
}
