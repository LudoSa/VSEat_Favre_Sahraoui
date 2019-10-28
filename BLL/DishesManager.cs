using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class DishesManager
    {
        public IDishes DishesDb { get; }

        public DishesManager(IConfiguration configuration)
        {

            DishesDb = new DishesDb(configuration);

        }

        public List<Dishes> GetHotels()
        {
            return DishesDb.GetHotel();
        }

        public Dishes GetHotel(int id)
        {
            return DishesDb.GetHotel(id);
        }

        public Dishes AddHotel(Dishes dishes)
        {
            return DishesDb.AddHotel(dishes);
        }

        public int UpdateHotel(Dishes dishes)
        {
            return DishesDb.UpdateHotel(dishes);
        }

        public int DeleteHotel(int id)
        {
            return DishesDb.DeleteHotel(id);
        }



    }
}
