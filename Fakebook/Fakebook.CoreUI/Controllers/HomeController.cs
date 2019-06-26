using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Fakebook.CoreUI.Models;

namespace Fakebook.CoreUI.Controllers
{
    public class HomeController : Controller
    {
        HttpHelper _helper;
        public HomeController(HttpHelper helper)
        {
            _helper = helper;
        }
        public IActionResult Index()
        {
            HttpContext.Session.SetString("Deneme", "Değer");

            OrnekComplexType ornek = new OrnekComplexType();

            HttpContext.Session.SetObjectAsJson("user", ornek);

            _helper.SendRequest();

            return View();
        }

        public class OrnekComplexType
        {
            public string adı { get; set; }
            public int yasi { get; set; }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
