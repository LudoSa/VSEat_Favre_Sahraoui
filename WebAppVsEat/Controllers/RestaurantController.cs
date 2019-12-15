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
        public RestaurantController(IRestaurantsManager restaurantsManager, IDishesManager dishesManager)
        {
            RestaurantsManager = restaurantsManager;
            DishesManager = dishesManager;
        }

        //Get a list of restaurants and inject it in the view Restaurants situated in the Restaurant folder
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
       
        // Show the index view situated in the Shared folder
        public ActionResult Index()
        {
            return View();
        }
        
    }
}