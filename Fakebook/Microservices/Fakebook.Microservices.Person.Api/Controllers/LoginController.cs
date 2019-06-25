using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeBookENTITIY.DataBase;
using FakeBookENTITIY.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Fakebook.Microservices.Person.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        Repository<People> repo = new Repository<People>();

        [HttpGet]
        public People GetPeople(People people)
        {
            People p = repo.Find(x => x.ID == people.ID);
            return p;
        }

        [HttpPost]
        public void registerPeople(People people)
        {
            People peop = new People
            {
                Email = people.Email,
                Name = people.Name,
                Password = people.Password,
                Surname = people.Surname
            };
            repo.Insert(peop);
        }
    }
}