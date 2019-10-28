using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class RestaurantsManager
    {

        public IRestaurants RestaurantsDb { get; }

        public RestaurantsManager(IConfiguration configuration)
        {

            RestaurantsDb = new RestaurantsDb(configuration);

        }

        public List<Restaurants> GetHotels()
        {
            return RestaurantsDb.GetHotel();
        }

        public Restaurants GetHotel(int id)
        {
            return RestaurantsDb.GetHotel(id);
        }

        public Restaurants AddHotel(Restaurants courier)
        {
            return RestaurantsDb.AddHotel(courier);
        }

        public int UpdateHotel(Restaurants courier)
        {
            return RestaurantsDb.UpdateHotel(courier);
        }

        public int DeleteHotel(int id)
        {
            return RestaurantsDb.DeleteHotel(id);
        }



    }
}
