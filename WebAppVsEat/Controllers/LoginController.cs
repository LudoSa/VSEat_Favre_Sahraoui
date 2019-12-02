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
    public class LoginController : Controller
    {


        private ILoginManager LoginManager { get; }
        public LoginController(ILoginManager loginManager)
        {
            LoginManager = loginManager;
        }


        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login l)
        {
            bool isValid = LoginManager.IsUserValid(l);
            if (isValid)
            {

                HttpContext.Session.SetString("Username", l.Username);
                HttpContext.Session.SetString("Password", l.Password);
                return RedirectToAction("GetHotels", "Hotel", new { isValid = isValid, user = l.Username });
            }
            else
            {
                return View();
            }

        }
    }
}