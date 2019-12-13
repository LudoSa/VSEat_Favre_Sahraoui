using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
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
        private ICitiesManager CitiesManager { get; }
        public CustomersController(ICustomersManager customersManager)
        {
            CustomersManager = customersManager;
        }


        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        // Permet de créer un customer
        public ActionResult Create()
        {

            //Permet d'extraire le nom des villes afin de les afficher dans un liste déroulante dans la view, plutôt que d'utiliser leurs id
            var cities = CustomersManager.GetCitiesName();

            IList<string> citiesList = new List<string>();
            foreach (var name in cities)
            {
                citiesList.Add(name);
            }
            TempData["City"] = cities;

            return View();
        }

        //On réceptionne les informations rentrées et on ajoute à la BDD le nouveau customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTO.Customer c)
        {

            CustomersManager.AddCustomer(c);
            
            return RedirectToAction(nameof(Index));
        }

    }
}