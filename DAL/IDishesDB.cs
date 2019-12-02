using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface IDishesDB
    {
        List<Dish> GetDishes();
        Dish GetDish(int id);

    }
}
