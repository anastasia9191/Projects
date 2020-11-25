using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel (IRestaurantData restaurantData,IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantID)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
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
