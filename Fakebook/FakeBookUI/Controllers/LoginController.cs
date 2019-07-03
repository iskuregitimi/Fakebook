
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Fakebook.CoreUI;
using Fakebook.CoreUI.Models;
using FakeBook;
using FakeBookUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace FakeBookUI.Controllers
{
    public class LoginController : Controller
    {
        HttpHelper _httpHelper;
        public LoginController(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;

        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]

        public IActionResult Index(PeopleModel people)
        {
            PeopleModel people1 = HttpHelper.SendRequestModel<PeopleModel>("http://localhost:14247/api/", "Login/GetPeople", people, Method.POST);
            if (people1 != null)
            {

                User_TModel user_TModel = HttpHelper.SendRequestModel<User_TModel>("http://localhost:14247/api/", "Login/Token", people1, Method.POST);
                HttpContext.Session.SetObjectAsJson("user", people1);
                HttpContext.Session.SetObjectAsJson("token", user_TModel);
                _httpHelper.SendRequest();
                return RedirectToAction("Index", "Home");
            }
            return View();

        }




        [HttpPost]
        public IActionResult Register(PeopleModel peopleModel)
        {

            HttpHelper.SendRequestModel<PeopleModel>("http://localhost:14247/api/", "Login/registerPeople", peopleModel, Method.POST);
            return RedirectToAction("Index", "Home");
        }


    }
}