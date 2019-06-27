
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Fakebook.CoreUI;
using Fakebook.CoreUI.Models;
using FakeBook;
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
           PeopleModel people1= HttpHelper.SendRequestModel<PeopleModel>("http://localhost:14247/api/", "Login/GetPeople", people, Method.POST);

            if (people1!=null)
            {
                return RedirectToAction("Index", "Home");
                
       
            HttpContext.Session.SetObjectAsJson("user", people1);
           ViewBag.username = people1.Name.ToString();
            _httpHelper.SendRequest();
                ViewBag.userName = people1.Name;
        
              
            }
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