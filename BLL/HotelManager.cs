using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class HotelManager
    {

        public IHotelsDb HotelDb { get; }

        public HotelManager (IConfiguration configuration)
        {

            HotelDb = new HotelsDB(configuration);

        }

        public List<Hotel> GetHotels()
        {
            return HotelDb.GetHotel();
        }

        public Hotel GetHotel(int id)
        {
            return HotelDb.GetHotel(id);
        }

        public Hotel AddHotel(Hotel hotel)
        {
            return HotelDb.AddHotel(hotel);
        }

        public int UpdateHotel(Hotel hotel)
        {
            return HotelDb.UpdateHotel(hotel);
        }

        public int DeleteHotel(int id)
        {
            return HotelDb.DeleteHotel(id);
        }

    }
}
