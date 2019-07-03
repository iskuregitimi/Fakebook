using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fakebook.Microservices.Person.Api.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Fakebook.Microservices.Person.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : Controller
    {
        FakebookContext _fakebookContext;
       
        public PersonController(FakebookContext fakebookContext)
        {
            _fakebookContext = fakebookContext;
        }

        [HttpGet]
        public List<Persons> List()
        {
            var persons = _fakebookContext.Persons.ToList();
            return persons;
        }
    }
}