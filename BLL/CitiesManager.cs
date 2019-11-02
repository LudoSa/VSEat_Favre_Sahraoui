using Microsoft.Extensions.Configuration;
using System;
using DTO;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CitiesManager
    {


        public ICities CitiesDb { get; }

        public CitiesManager(IConfiguration configuration)
        {

            CitiesDb = new CitiesDb(configuration);

        }

        public List<Cities> GetCities()
        {
            return CitiesDb.GetHotel();
        }

        public Cities GetCity(int id)
        {
            return CitiesDb.GetHotel(id);
        }

        public Cities AddCity(Cities hotel)
        {
            return CitiesDb.AddHotel(hotel);
        }

        public int UpdateCity(Cities hotel)
        {
            return CitiesDb.UpdateHotel(hotel);
        }

        public int DeleteCity(int id)
        {
            return CitiesDb.DeleteHotel(id);
        }


    }
}
