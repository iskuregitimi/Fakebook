using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fakebook.CoreUI.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Fakebook.CoreUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Register(PeopleModel model)
        {
            HttpHelper.SendRequestModel<PeopleModel>("http://localhost:14247/api/", "Login/registerUser", model, Method.POST);
            return RedirectToAction("Index", "Login");
        }


        public IActionResult Login(PeopleModel model)
        {
            PeopleModel people = HttpHelper.SendRequestModel<PeopleModel>("http://localhost:14247/api/", "Login/getUser", model, Method.GET);

            if (people != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Login");

        }
    }
}
