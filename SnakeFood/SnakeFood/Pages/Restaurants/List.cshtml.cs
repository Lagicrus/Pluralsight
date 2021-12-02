using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using SnakeFood.Core;
using SnakeFood.Data;

namespace SnakeFood.Pages.Restaurants
{
    public class List : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public List(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}