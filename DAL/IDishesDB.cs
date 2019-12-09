using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface IDishesDB
    {
        List<Dish> GetDishes(int id);
        Dish GetDish(int id);

    }
}
