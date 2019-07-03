using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fakebook.CoreUI.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Fakebook.CoreUI.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult PersonList()
        {
            List<Persons> persons = new List<Persons>();
            persons =HttpHelper.List<List<Persons>>("http://localhost:14247/api/", "Person/List", Method.GET);
            return View(persons);
        }
        public IActionResult PersonListDeneme()
        {
            List<Persons> persons = new List<Persons>();
            persons = HttpHelper.List<List<Persons>>("http://localhost:14247/api/", "Person/List", Method.GET);
            return View(persons);
        }
    }
}