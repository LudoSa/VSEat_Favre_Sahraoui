using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IOrder_dishesManager
    {


        IHotelsDb HotelsDb { get; }

        List<Hotel> GetHotels();

        Hotel GetHotel(int id);

        Hotel AddHotel(Hotel hotel);

        int UpdateHotel(Hotel hotel);

        int DeleteHotel(int id);


    }
}
