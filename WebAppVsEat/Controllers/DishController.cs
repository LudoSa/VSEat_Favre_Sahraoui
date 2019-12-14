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
    private ICourierManager CourierManager { get; }
    private IOrder_dishesManager Order_dishesManager { get; }
    private IOrdersManager OrderManager { get; }
    private ICitiesManager CitiesManager { get; }
   
    public DishController(IDishesManager dishesManager, IRestaurantsManager restaurantsManager, ICourierManager courierManager, IOrder_dishesManager order_dishesManager, IOrdersManager orderManager, ICitiesManager citiesManager)
    {
            DishesManager = dishesManager;
            RestaurantsManager = restaurantsManager;
            CourierManager = courierManager;
            Order_dishesManager = order_dishesManager;
            OrderManager = orderManager;
            CitiesManager = citiesManager;
    }



    // GET: Dish/Details/5
    public ActionResult DishesRestaurant(int id)
        {


            if (HttpContext.Session.GetString("User") != null)
            {
                var restaurant = RestaurantsManager.GetRestaurant(id);
                ViewData["Address"] = restaurant;

                var order_dishes = new List<OrderDishmodel>();
                var dishes = DishesManager.GetDishes(id);

                foreach (var item in dishes)
                {
                    var dishOrder = new Models.OrderDishmodel();
                    dishOrder.dish = DishesManager.GetDish(item.IdDishes);
                    dishOrder.dish.Name = item.Name;

                    order_dishes.Add(dishOrder);

                }

                return View(order_dishes);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult AddToCard(int idDish)
        {

            var cardItem = new CardItem();
            cardItem.idDish = idDish;

            /*
            var order_dishes = new OrderDishmodel();
            var datetime = RoundUp(DateTime.Now.AddMinutes(15), TimeSpan.FromMinutes(15));
            
            order_dishes.DeliveryTime = datetime;*/
            

            return View(cardItem);



        }
        
        //Méthode qui réceptionne les informations afin d'update l'order
        [HttpPost]
        public ActionResult AddToCard(Models.OrderDishmodel orderDish)
        {

            //On modifie l'order avec les nouvelles informations
            //Add la méthode add


            /*
            int idCity = CitiesManager.GetRestaurantCity(orderDish.dish.Restaurants_id);
            int idCourier = GetFreeCourier(orderDish.DeliveryTime, idCity);
            if (idCourier != null)
            {
                orderDish.addOrder(idCustomer, Delivery_time, idCourier, quantity)
            }
            else
            {
                redirecttoaction
            }
            */
            return RedirectToAction(nameof(DishesRestaurant));
        }



        DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
        }
         //<input class="form-control" style="width:300px;" type="datetime-local" value="@item.dateTime.ToString("yyyy-MM-ddTHH:mm")" min="@item.dateTime.ToString("yyyy-MM-ddTHH:mm")" step="900" a />

    }
}