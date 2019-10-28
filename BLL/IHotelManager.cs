using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IHotelManager
    {

        IHotelsDb HotelsDb { get; }

        List<Hotel> GetHotels();

        Hotel GetHotel(int id);

        Hotel AddHotel(Hotel hotel);

        int UpdateHotel(Hotel hotel);

        int DeleteHotel(int id);



    }
}
