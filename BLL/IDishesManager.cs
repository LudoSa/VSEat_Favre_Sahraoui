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

        List<Dishes> GetDishes();

        Dishes GetDish(int id);

        Dishes AddDish(Dishes dish);

        int UpdateDish(Dishes dish);

        int DeleteDish(int id);


    }
}
