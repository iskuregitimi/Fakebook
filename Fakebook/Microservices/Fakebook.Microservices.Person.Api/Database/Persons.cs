using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fakebook.Microservices.Person.Api.Database
{
    public class Persons
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneorEmail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public string Token { get; set; }

    }
}
