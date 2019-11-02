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

        public List<Dishes> GetDishes()
        {
            return DishesDb.GetHotel();
        }

        public Dishes GetDish(int id)
        {
            return DishesDb.GetHotel(id);
        }

        public Dishes AddDish(Dishes dishes)
        {
            return DishesDb.AddHotel(dishes);
        }

        public int UpdateDish(Dishes dishes)
        {
            return DishesDb.UpdateHotel(dishes);
        }

        public int DeleteDish(int id)
        {
            return DishesDb.DeleteHotel(id);
        }



    }
}
