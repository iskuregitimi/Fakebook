using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fakebook.CoreUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RestSharp;

namespace Fakebook.CoreUI.Controllers
{
    public class LoginController : Controller
    {
        HttpHelper _helper;
        public LoginController(HttpHelper helper)
        {               
                _helper = helper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username,string password)
        {
           
          var  person = HttpHelper.Login<Persons>("http://localhost:14247/api/", "Login/Login", username, password ,Method.GET);
        
            if (person != null)
            {
                if (person.UserName== username && person.Password==password)
                {
                    //HttpContext.Session.SetString("token", person.Token);
                    return RedirectToAction("PersonList", "Person");
                }
               
            }
            return RedirectToAction("Login");
            
                
           
        }
    }
}