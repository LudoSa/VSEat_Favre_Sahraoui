using DTO;
using Microsoft.Extensions.Configuration;
using System;
using DAL;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class RestaurantsManager : IRestaurantsManager
    {

        public IRestaurantsDB RestaurantsDb { get; }

        public RestaurantsManager(IConfiguration configuration)
        {

            RestaurantsDb = new RestaurantsDB(configuration);

        }

        public List<Restaurant> GetRestaurants()
        {
            return RestaurantsDb.GetRestaurants();
        }

        public Restaurant GetRestaurant(int id)
        {
            return RestaurantsDb.GetRestaurant(id);
        }

        
    }
}
