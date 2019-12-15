using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    private ICustomersManager CustomerManager { get; }
    
        public DishController(IDishesManager dishesManager, IRestaurantsManager restaurantsManager, ICourierManager courierManager, IOrder_dishesManager order_dishesManager, IOrdersManager orderManager, ICitiesManager citiesManager, ICustomersManager customerManager)
    {
            DishesManager = dishesManager;
            RestaurantsManager = restaurantsManager;
            CourierManager = courierManager;
            Order_dishesManager = order_dishesManager;
            OrderManager = orderManager;
            CitiesManager = citiesManager;
            CustomerManager = customerManager;
    }

        //variable globale qui correspond à toutes les plats à commander (panier)
        public static List<CardItem> basket = new List<CardItem>();


        
        public ActionResult DishesRestaurant(int id)
        {


            if (HttpContext.Session.GetString("User") != null)
            {
                var restaurant = RestaurantsManager.GetRestaurant(id);
                ViewData["Address"] = restaurant;
                int idRestaurantCity = CitiesManager.GetRestaurantCity(id);
                HttpContext.Session.SetInt32("idCityRestaurant", idRestaurantCity);

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


        public ActionResult AddToCard(int idDish, int price, string name, int idRestau)
        {

            var cardItem = new CardItem();
            cardItem.idDish = idDish;
            cardItem.price = price;
            cardItem.name = name;
            HttpContext.Session.SetInt32("idRestau", idRestau);
            ViewBag.idRestau = idRestau;
            /*
            var order_dishes = new OrderDishmodel();
            var datetime = RoundUp(DateTime.Now.AddMinutes(15), TimeSpan.FromMinutes(15));
            
            order_dishes.DeliveryTime = datetime;*/
            

            return View(cardItem);



        }
        
        //Méthode qui réceptionne les informations afin d'update l'order
        [HttpPost]
        public ActionResult AddToCard(Models.CardItem cardItem)
        {

            basket.Add(cardItem);
            var idRestau = Request.Form["idRestau"];
            int idRestauInt = 0;





            if (Int32.TryParse(idRestau, out idRestauInt))
                return RedirectToAction("DishesRestaurant", "Dish", new { id = idRestauInt });
            else
                return null;

        }

        //Montrer le panier
        public ActionResult Basket()
        {


            return View(basket);
        }


        //Création d'une order
        public ActionResult Order (int totalPrice)
        {

            //On récupère le prix total pour la condition if plus bas
            int totalPrice2 = totalPrice;

            

            var orderItem = new OrderItem();

            int idCustomer = (int) HttpContext.Session.GetInt32("idCustomer");

            orderItem.IdCustomer = idCustomer;
            orderItem.Status = "Ready";

            //Si le prix total n'est pas égal à 0, on crée l'order, sinon non et on affiche un message d'erreur
            if (totalPrice2 != 0)
                return View(orderItem);
            else
                return RedirectToAction("ErrorOrder", "Dish");
        }

        [HttpPost]
        public ActionResult Order (OrderItem orderItem)
        {


            int idCityRestaurant = (int)HttpContext.Session.GetInt32("idCityRestaurant");


            List<Courier> couriers = CourierManager.GetIdCourier(idCityRestaurant);



            //Cherche les livreurs de la même ville que le restaurant ceux qui n'ont pas 5 orders dans l'intervalle de 30 minutes
            foreach (Courier courier in couriers)
            {

                Boolean isAvailable = true;

                int cpt = 0;

                //Retourne la liste de toutes les orders correspondantes au livreur sélectionné
                List<Order> orders = OrderManager.GetCourierOrders(courier.IdCourier);

                //Si le livreur n'a pas d'order
                if (orders != null)
                {

                    foreach (Order order in orders)
                    {

                        //On trouve la différence de temps pour la vérification des 30 minutes. Si c'est le cas, on augmente le compteur de commande
                        double diffHours = (order.Delivery_time - orderItem.DeliveryTime).TotalMinutes;

                        if (diffHours >= -15 && diffHours<=0 || diffHours <= 15 && diffHours >=0)
                        {
                            cpt++;

                        }
                    }

                    //Si le compteur est égal à 5, on n'assigne pas le livreur
                    if (cpt >= 5)
                    {
                        isAvailable = false;
                    }

                    //Si le boolean est toujours à true, on assigne ce livreur.
                    if (isAvailable == true)
                    {
                        orderItem.IdCourier = courier.IdCourier;
                        break;
                    }
                }
                else
                {

                    //Si le boolean est toujours à true, on assigne ce livreur.
                    if (isAvailable == true)
                    {
                        orderItem.IdCourier = courier.IdCourier;
                    }
                }
            }

            //Si aucun livreur n'est disponible, on affiche une page qui le dit
            if (orderItem.IdCourier == 0)
            {
                basket.Clear();
                return RedirectToAction("NoCourierAvailable");
            }

            //Si le prix total n'est pas égal à 0, on crée l'order, sinon non et on affiche un message d'erreur
            if ( true)
            {

                //On crée un objet Order qu'on remplit avec les informations de l'orderItem
                int idOrder;
                var listOrderDish = new List<OrderDish>();
                Order order = new Order();
                order.Status = orderItem.Status;
                order.IdCourier = orderItem.IdCourier;
                order.IdCustomer = orderItem.IdCustomer;
                order.Delivery_time = orderItem.DeliveryTime;

                //Quand on a crée l'order, on récupère son id pour créer l'Order_dishes
                idOrder = OrderManager.AddOrder(order);

                //On remplit une liste d'orderDish qui permettra de créer toutes les lignes dans la base de données
                foreach (CardItem cardItem in basket)
                {

                    OrderDish orderDish = new OrderDish();

                    orderDish.IdOrder = idOrder;
                    orderDish.IdDishes = cardItem.idDish;
                    orderDish.Quantity = cardItem.quantity;

                    listOrderDish.Add(orderDish);
                }

                //Pour chaque objet dans la liste, on crée une ligne dans la BDD. Si la quantité est à 0, on ne crée pas de ligne
                foreach (OrderDish orderDishObject in listOrderDish)
                {
                    if (orderDishObject.Quantity != 0)
                        Order_dishesManager.AddOrderDishes(orderDishObject);

                }
                basket.Clear();
                //HttpContext.Session.SetString("Role", "Customer");
                return RedirectToAction("Restaurants", "Restaurant");
            }
        }



        public ActionResult GetMyOrders()
        {
            string email = HttpContext.Session.GetString("User");
            int id = CustomerManager.GetCustomerId(email);
            var orders = OrderManager.GetCustomerOrders(id);

            ViewBag.email = email;


            return View(orders);

        }

        public ActionResult GetCancelledOrders(string email)
        {

            int id = CustomerManager.GetCustomerId(email);
            var orders = OrderManager.GetCustomerCancelOrders(id);



            return View(orders);
        }


        public ActionResult CancelOrder(int idOrder)
        {

            //On trouve l'order à modifier grâce à son id
            var order = OrderManager.GetOrder(idOrder);
            return View(order);


        }

        [HttpPost]
        public ActionResult CancelOrder(Order order)
        {

            //On modifie l'order avec le nouveau statut
            OrderManager.UpdateOrder(order);

            return RedirectToAction(nameof(GetMyOrders));

        }


        public ActionResult NoCourierAvailable()
        {
            return View();
        }

        public ActionResult ErrorOrder()
        {
            return View();
        }

        //Permet d'arrondir le temps quand on sélectionne le temps de livraison

        DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
        }
         //<input class="form-control" style="width:300px;" type="datetime-local" value="@item.dateTime.ToString("yyyy-MM-ddTHH:mm")" min="@item.dateTime.ToString("yyyy-MM-ddTHH:mm")" step="900" a />


        
    }


}