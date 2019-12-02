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

        public IRestaurantsDB RestaurantsDbObject { get; }

        public RestaurantsManager(IRestaurantsDB RestaurantsDb)
        {

            RestaurantsDbObject = RestaurantsDb;

        }

        public List<Restaurant> GetRestaurants()
        {
            return RestaurantsDbObject.GetRestaurants();
        }

        public Restaurant GetRestaurant(int id)
        {
            return RestaurantsDbObject.GetRestaurant(id);
        }

        
    }
}
