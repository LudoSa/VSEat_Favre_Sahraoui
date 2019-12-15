using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace WebAppVsEat.Controllers
{
    public class LoginController : Controller
    {


        private ILoginManager LoginManager { get; }
        public LoginController(ILoginManager loginManager)
        {
            LoginManager = loginManager;
        }


        //Page de connection
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        //On récupère les infos de la page de connection
        [HttpPost]
        public IActionResult Index(Login l)
        {

            //On récupère les boolean de validation du compte: Si le compte est valide et si le compte est un client
            bool isValid = LoginManager.IsUserValid(l);
            bool isCustomerValid = LoginManager.IsCustomerValid(l);
            //Utile quand on crée l'order
            int idCustomer = LoginManager.GetIdCustomer(l.Email);

            if (isValid)
            {

                if (isCustomerValid)
                {
                    //Si le compte est un client, on initialise un rôle pour la view Layout et le User pour afficher son nom en haut de la page
                    //On retourne sur la page d'acceuil
                    HttpContext.Session.SetString("Role", "Customer");
                    HttpContext.Session.SetString("User", l.Email);
                    HttpContext.Session.SetInt32("idCustomer", idCustomer);
                    return RedirectToAction("Index", "Restaurant", new { isAccountValid = isValid, isCustomer = isCustomerValid});
                }
                else
                {
                    //Si le compte est un livreur, on initialise le rôle pour la view Layout, on retient sur mail pour trouver par la suite son id pour les orders
                    //On retourne la view qui affichera toutes les commandes correspondantes à son id
                    HttpContext.Session.SetString("Role", "Courier");
                    HttpContext.Session.SetString("User", l.Email);
                    string emailLog = l.Email;
                    return RedirectToAction("GetOrders", "Courier", new  { email = emailLog, isAccountValid = isValid, isCourierValid = true });
                }

            }
            else
            {
                return View();
            }
        }


        //Déconnexion du compte
        public IActionResult Logout()
        {

            //On nettoie la Session et on remet le Role à null
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("Role", "");
            //On retourne sur la page d'acceuil
            return RedirectToAction("Index", "Restaurant");
        }
    }
}