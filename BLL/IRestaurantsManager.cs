using System;
using DTO;
using DAL;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IRestaurantsManager
    {

        IRestaurantsDB RestaurantsDb { get; }

        List<Restaurant> GetRestaurants();

        Restaurant GetRestaurant(int id);

    }
}
