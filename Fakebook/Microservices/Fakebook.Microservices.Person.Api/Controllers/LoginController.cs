using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fakebook.Microservices.Person.Models;
using FakeBookENTITIY.DataBase;
using FakeBookENTITIY.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fakebook.Microservices.Person.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        Repository<People> repo_people = new Repository<People>();

        [HttpPost]
        public PeopleModel GetPeople(PeopleModel people)
        {
            People po = repo_people.Find(x=>x.Email==people.Email);
            PeopleModel peop = new PeopleModel
            {
                ID=po.ID,
                Email = po.Email,
                Name = po.Name,
                Password = po.Password,
                Surname = po.Surname

            };
            return peop;
        }

        [HttpPost]
        public void registerPeople(PeopleModel people)
        {
            People poeop = new People
            {
                Email = people.Email,
                Name = people.Name,
                Password = people.Password,
                Surname = people.Surname

            };
            repo_people.Insert(poeop);
        }
        
    }
}