using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]//priveazca mojno ispolizovati priamo v tele metoda s takim je nazvaniem
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel (IRestaurantData restaurantData,IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantID)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();//this shows the list of cuisines that is enume type
            if (restaurantID.HasValue)
            {
                Restaurant = restaurantData.GetById(restaurantID.Value);
            }
            else
            {
                Restaurant = new Restaurant();
               
            }
            if (Restaurant == null)
            {
                return RedirectToPagePermanent("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            if(Restaurant.ID>0)
            {
                restaurantData.Update(Restaurant);
            }
            else
            {
                TempData["Message"] = "Restaurant saved!";
                restaurantData.Add(Restaurant);
            }
            restaurantData.Commit();
            return RedirectToPage("./Detail", new { restaurantID = Restaurant.ID });

        }
    }
}
