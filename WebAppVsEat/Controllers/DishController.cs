using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppVsEat.Controllers
{
    public class DishController : Controller
    {
    private IDishesManager DishesManager { get; }
    private IRestaurantsManager RestaurantsManager { get; }
    public DishController(IDishesManager dishesManager, IRestaurantsManager restaurantsManager)
    {
            DishesManager = dishesManager;
            RestaurantsManager = restaurantsManager;
    }
    // GET: Dish/Details/5
    public ActionResult DishesRestaurant(int id)
        {

            var restaurant = RestaurantsManager.GetRestaurant(id);

            ViewData["Address"] = restaurant;
            var dishes = DishesManager.GetDishes(id);



            return View(dishes);
        }

    }
}