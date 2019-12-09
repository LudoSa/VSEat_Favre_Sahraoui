﻿using System;
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

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customers/Create
        public ActionResult Create()
        {

            //Pas fini
            var cities = CitiesManager.GetCities();

            ViewBag.Cities = new SelectList(cities., "Name");

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