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
        public ICitiesDB CitiesDB { get; }
        public RestaurantsManager(IRestaurantsDB RestaurantsDb, ICitiesDB citiesDB)
        {

            RestaurantsDbObject = RestaurantsDb;
            CitiesDB = citiesDB;
        }

        public List<Restaurant> GetRestaurants()
        {
            return RestaurantsDbObject.GetRestaurants();

        }
        public City getRestaurantCity(int id)
        {
            return CitiesDB.getCity(id);
        }
        public Restaurant GetRestaurant(int id)
        {
            return RestaurantsDbObject.GetRestaurant(id);
        }

        
    }
}
