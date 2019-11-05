using DTO;
using Microsoft.Extensions.Configuration;
using System;
using DAL;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class RestaurantsManager
    {

        public IRestaurantsDB RestaurantsDb { get; }

        public RestaurantsManager(IConfiguration configuration)
        {

            RestaurantsDb = new RestaurantsDB(configuration);

        }

        public List<Restaurants> GetHotels()
        {
            return RestaurantsDb.GetRestaurants();
        }

        public Restaurants GetHotel(int id)
        {
            return RestaurantsDb.GetRestaurant(id);
        }

        public Restaurants AddHotel(Restaurants courier)
        {
            return RestaurantsDb.AddRestaurant(courier);
        }

        public int UpdateHotel(Restaurants courier)
        {
            return RestaurantsDb.UpdateRestaurant(courier);
        }

        public int DeleteHotel(int id)
        {
            return RestaurantsDb.DeleteRestaurant(id);
        }



    }
}
