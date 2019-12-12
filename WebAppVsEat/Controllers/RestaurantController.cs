using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using BLL;
using WebAppVsEat.Models;


namespace WebAppVsEat.Views
{
    public class RestaurantController : Controller
    {
        //Configuration
        private IRestaurantsManager RestaurantsManager { get;  }
        private IDishesManager DishesManager { get; }
        public RestaurantController(IRestaurantsManager restaurantsManager)
        {
            RestaurantsManager = restaurantsManager;
        }


        public ActionResult Restaurants()
        {
            var restaurantlist = RestaurantsManager.GetRestaurants();
            IList <string> cityaddress = new List<string>();
            foreach (var citycode in restaurantlist)
            {
                var city = RestaurantsManager.getRestaurantCity(citycode.Country_code);
                cityaddress.Add(city.Code + " " + city.Name);
            }
            ViewData["Address"] = cityaddress;

            return View(restaurantlist);
        }
        
    }
}