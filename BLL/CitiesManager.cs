using Microsoft.Extensions.Configuration;
using System;
using DTO;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CitiesManager
    {


        public ICitiesDb CitiesDb { get; }

        public CitiesManager(IConfiguration configuration)
        {

            CitiesDb = new CitiesDb(configuration);

        }

        public List<Cities> GetHotels()
        {
            return CitiesDb.GetHotel();
        }

        public Cities GetHotel(int id)
        {
            return CitiesDb.GetHotel(id);
        }

        public Cities AddHotel(Cities hotel)
        {
            return CitiesDb.AddHotel(hotel);
        }

        public int UpdateHotel(Cities hotel)
        {
            return CitiesDb.UpdateHotel(hotel);
        }

        public int DeleteHotel(int id)
        {
            return CitiesDb.DeleteHotel(id);
        }


    }
}
