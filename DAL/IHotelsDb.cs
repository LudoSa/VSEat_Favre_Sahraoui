using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IHotelsDb
    {

        IConfiguration Configuration { get; }
        List<Hotel> GetHotels();
        Hotel GetHotel(int id);
        Hotel AddHotel(Hotel hotel);
        int UpdateHotel(Hotel hotel);
        int DeleteHotel(int id);
        List<Hotel> GetHotel();
    }
}
