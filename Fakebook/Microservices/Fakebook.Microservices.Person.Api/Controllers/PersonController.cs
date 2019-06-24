using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fakebook.Microservices.Person.Api.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fakebook.Microservices.Person.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {



	    FakebookDataContext _fakebookDataContext;

		public PersonController(FakebookDataContext fakebookDataContext)
		{
			_fakebookDataContext = fakebookDataContext;
		}
		[HttpGet]
		public List<Persons> GetPersonList()
		{
			return _fakebookDataContext.Persons.ToList();
		}


    }
}