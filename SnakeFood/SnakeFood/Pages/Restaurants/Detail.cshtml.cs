using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SnakeFood.Core;
using SnakeFood.Data;

namespace SnakeFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        public Restaurant Restaurant { get; set; }
        public DetailModel(IRestaurantData restaurantData)
        {
            this._restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetById(restaurantId);
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}