using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fakebook.CoreUI.Models;
using FakeBook;
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

        public ActionResult Index(PeopleModel people)
        {
          PeopleModel po= HttpHelper.SendRequestModel<PeopleModel>("http://localhost:14247/api", "Login/Index", people,Method.GET);

            if (po!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }



        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(PeopleModel people)
        {
            HttpHelper.SendRequestModel<PeopleModel>("http://localhost:14247/", "api/Login/registerPeople", people, Method.POST);
            return View();
        }
    }
}