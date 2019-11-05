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

        List<Restaurants> GetRestaurants();

        Restaurants GetRestaurant(int id);

        Restaurants AddRestaurant(Restaurants restaurant);

        int UpdateRestaurant(Restaurants restaurant);

        int DeleteRestaurant(int id);

    }
}
