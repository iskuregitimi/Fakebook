using Fakebook.Microservices.Person.Api.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fakebook.Microservices.Person.Api.Services
{
    public interface ILogin
    {
        Persons Authenticate(string username, string password);
    }
}
