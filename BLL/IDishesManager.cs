using System;
using DTO;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IDishesManager
    {

        IDishesDb DishesDb { get; }

        List<Dishes> GetDishes();

        Dishes GetDish(int id);

        Dishes AddDish(Dishes dish);

        int UpdateDish(Dishes dish);

        int DeleteDish(int id);


    }
}
