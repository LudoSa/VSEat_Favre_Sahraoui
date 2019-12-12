using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppVsEat.Models;

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
            
            var order_dishes = new List<OrderDishmodel>();
            var dishes = DishesManager.GetDishes(id);
            
            foreach (var item in dishes)
            {
                var dishOrder = new Models.OrderDishmodel();
                dishOrder.dish.Add(DishesManager.GetDish(item.IdDishes));
                


                order_dishes.Add(dishOrder);
                
            }


            return View(order_dishes);
        }
       
    }
}