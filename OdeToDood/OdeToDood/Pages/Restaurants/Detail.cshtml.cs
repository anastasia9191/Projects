using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant { get; set; }
        public IRestaurantData restaurantData { get; set; }
        [TempData]
        public string Message { get; set; }
        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantID)
        {
            Restaurant = restaurantData.GetById(restaurantID);
            if(Restaurant == null)
            {
                return RedirectToPagePermanent("./NotFound");
            }
            return Page();
         
        }
    }
}
