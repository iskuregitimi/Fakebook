using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fakebook.CoreUI.Models;
using FakeBook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace FakeBookUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]

        public IActionResult Index(PeopleModel people)
        {
           PeopleModel people1= HttpHelper.SendRequestModel<PeopleModel>("http://localhost:14247/api/", "Login/GetPeople", people, Method.POST);

            if (people1!=null)
            {
                return RedirectToAction("Index", "Home");

              
            }

            string name = people1.Name;
            HttpContext.Session.SetString("People", name);
            return View();

        }


     

        [HttpPost]
        public IActionResult Register(PeopleModel peopleModel)
        {

            HttpHelper.SendRequestModel<PeopleModel>("http://localhost:14247/api/", "Login/registerPeople", peopleModel, Method.POST);
            return RedirectToAction("Index","Home");
        }


    }
}