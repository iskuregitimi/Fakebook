using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fakebook.Microservices.Person.Api.DataBase;
using Microsoft.Extensions.DependencyInjection;
using Fakebook.Microservices.Person.Api.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

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


		//[ActionFilter]
		//[ServiceFilter(typeof(ResultFilter))]
		//[ServiceFilter(typeof(ActionFilter))]
		[HttpGet]	
		public List<Persons> GetPersonList()
		{
			return _fakebookDataContext.Persons.ToList();
		}
		//[TypeFilter(typeof(ActionFilter))]
		//[ActionFilter]
		[HttpGet]
		public Persons Login(string Email,string Password) {


			Persons person = _fakebookDataContext.Persons.Where(x => x.Email == Email && x.Password == Password).Select(y => new Persons
			{
				

				PersonID = y.PersonID,
				Email = Email,
				Password = Password,
				Name = y.Name,
				Surname = y.Surname,
				Address = y.Address,
				City = y.City,
				Phone = y.Phone,
				BirthDate = y.BirthDate,
				Gender = y.Gender,
				Image = y.Image
			}
			
			 ).FirstOrDefault();
			string token = Guid.NewGuid().ToString() + "æ" + DateTime.Now;

			return person;
		}

		[HttpPost]
		public void AddPerson(Persons persons)
		{

			_fakebookDataContext.Set<Persons>().Add(persons);
			_fakebookDataContext.SaveChanges();
		

		}


	}
}