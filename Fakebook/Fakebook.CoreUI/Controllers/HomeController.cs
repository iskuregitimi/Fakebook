using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fakebook.CoreUI.Models;
using RestSharp;

namespace Fakebook.CoreUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
		 
		[HttpGet]
		public ActionResult Login()
		{
			return View(new PersonModel());
		}

		[HttpPost]
		public ActionResult Login(string Email,string Password)
		{
			var person = HttpHelper.GetMethod<PersonModel>("http://localhost:14247/", "api/Person/Login/", Method.GET, Email, Password);
			if (person.Password == Password)
			{
				
				return RedirectToAction("Index", "Home");
			}
			return View();

		
		}


		public ActionResult SignUp()
		{
			return View();
		}


		
	
	


	}
}
