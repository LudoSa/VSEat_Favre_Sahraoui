using Microsoft.Extensions.Configuration;
using System;
using DTO;
using DAL;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CitiesManager
    {


        public ICitiesDB CitiesDb { get; }

        public CitiesManager(IConfiguration configuration)
        {

            CitiesDb = new CitiesDB(configuration);

        }

        public List<Cities> GetCities()
        {
            return CitiesDb.GetCities();
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
