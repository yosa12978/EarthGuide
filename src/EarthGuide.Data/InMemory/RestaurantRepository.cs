using EarthGuide.Core.Domain;
using EarthGuide.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthGuide.Data.InMemory
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private List<Restaurant> restaurants = new List<Restaurant>
        {
            new Restaurant
            { 
                Id = Guid.NewGuid().ToString(), 
                Name = "The Best Restaurant",
                Desc = "the most delicious restaurant in the city",
                Latitude = 45.000d,
                Longitude = 51.1234d,
                IsActive = true,
            },
            new Restaurant
            { 
                Id = Guid.NewGuid().ToString(), 
                Name = "Common Stakes",
                Desc = "Just common beef stakes",
                Latitude = 42.000d,
                Longitude = 69.69d,
                IsActive = true,
            }
        };
        public async Task Create(Restaurant r)
        {
            restaurants.Add(r);
        }

        public async Task Delete(string id)
        {
            restaurants.Remove(restaurants.FirstOrDefault(x => x.Id == id));
        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            return restaurants;
        }

        public async Task<Restaurant> GetById(string id)
        {
            return restaurants.FirstOrDefault(x => x.Id == id);
        }

        public async Task Update(string id, Restaurant r)
        {
            restaurants[restaurants.IndexOf(restaurants.FirstOrDefault(x => x.Id == id))] = r;
        }
    }
}
