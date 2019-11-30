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
        private IConfiguration Configuration { get; }
        public RestaurantController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public ActionResult Restaurants()
        {
            IRestaurantsManager hmanager = new RestaurantsManager(Configuration);
            var restaurantlist = hmanager.GetRestaurants();
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
            IRestaurantsManager hman = new RestaurantsManager(Configuration);
            var hotel = hman.GetRestaurant(id);

            return View(hotel);
        }
    }
}