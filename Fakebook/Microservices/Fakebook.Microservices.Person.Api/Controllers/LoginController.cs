using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Fakebook.Microservices.Person.Api.Database;
using Fakebook.Microservices.Person.Api.Helpers;
using Fakebook.Microservices.Person.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Fakebook.Microservices.Person.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILogin _login;
        FakebookContext _fakebookcontext;
       
        public LoginController(ILogin login,FakebookContext fakebookContext)
        {         
            this._login = login;
            _fakebookcontext = fakebookContext;
           
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string username,string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;
            var person = _login.Authenticate(username, password);
            // check if username exists
            if (person == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            // authentication successful
            return Ok(person);
        }    
    }
}