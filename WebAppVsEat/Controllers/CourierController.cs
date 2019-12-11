using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppVsEat.Controllers
{
    public class CourierController : Controller
    {


        private ICourierManager CourierManager { get; }
        public int id { get; set; }
        public CourierController(ICourierManager courierManager)
        {
            CourierManager = courierManager;
        }

        // GET: Courier
        public ActionResult Index()
        {
            return View();
        }

        // GET: Courier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetOrders(string email)
        {

            
            id = CourierManager.GetCourierId(email);
            var orders = CourierManager.GetCourierOrders(id);


            return View(orders);

        }
    }
}