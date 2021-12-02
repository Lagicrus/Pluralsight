using System.Collections.Generic;
using System.Linq;
using SnakeFood.Core;

namespace SnakeFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>();
            restaurants.Add(new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian });
            restaurants.Add(new Restaurant { Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisineType.Indian });
            restaurants.Add(new Restaurant { Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Mexican });
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }
    }
}