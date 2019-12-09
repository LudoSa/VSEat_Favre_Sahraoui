using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace WebAppVsEat.Controllers
{
    public class CustomersController : Controller
    {
        //Configuration
        private ICustomersManager CustomersManager { get; }
        public CustomersController(ICustomersManager customersManager)
        {
            CustomersManager = customersManager;
        }


        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
           
            var cities = CustomersManager.GetCitiesName();
            IList<string> citiesList = new List<string>();
            foreach (var name in cities)
            {
                citiesList.Add(name);
            }
            TempData["City"] = citiesList;

            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTO.Customer c)
        {

            CustomersManager.AddCustomer(c);
            return RedirectToAction(nameof(Index));
        }

    }
}