using System;
using DTO;
using DAL;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IDishesManager
    {

        IDishesDB DishesDb { get; }

        List<Dish> GetDishes(int id);

        Dish GetDish(int id);


    }
}
