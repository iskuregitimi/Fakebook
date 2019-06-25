using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fakebook.CoreUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fakebook.CoreUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
