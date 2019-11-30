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


        public ActionResult getRestaurants()
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
            return View();
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}