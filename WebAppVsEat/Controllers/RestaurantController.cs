using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using BLL;

namespace WebAppVsEat.Views
{
    public class RestaurantController : Controller
    {
        //Configuration
        private IRestaurantsManager RestaurantsManager { get;  }
        public RestaurantController(IRestaurantsManager restaurantsManager)
        {
            RestaurantsManager = restaurantsManager;
        }


        public ActionResult Restaurants()
        {
            var restaurantlist = RestaurantsManager.GetRestaurants();
            return View(restaurantlist);
        }
        
        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {
            var hotel = RestaurantsManager.GetRestaurant(id);

            return View(hotel);
        }
    }
}