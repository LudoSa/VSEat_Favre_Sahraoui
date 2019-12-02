using DTO;
using Microsoft.Extensions.Configuration;
using System;
using DAL;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class DishesManager : IDishesManager
    {
        public IDishesDB DishesDb { get; }

        public DishesManager(IConfiguration configuration)
        {

            DishesDb = new DishesDB(configuration);

        }

        public List<Dish> GetDishes()
        {
            return DishesDb.GetDishes();
        }

        public Dish GetDish(int id)
        {
            return DishesDb.GetDish(id);
        }



    }
}
