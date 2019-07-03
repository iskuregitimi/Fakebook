using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Fakebook.Microservices.Person.Api.Database;
using Fakebook.Microservices.Person.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Fakebook.Microservices.Person.Api.Services
{
    public class Login : ILogin
    {
        private FakebookContext _fakecontext;
        private readonly AppSetting _appSetting;

        public Login(FakebookContext fakecontext,IOptions<AppSetting> appSetting)
        {
            _fakecontext = fakecontext;
            this._appSetting = appSetting.Value;
        }

        public Persons Authenticate(string username, string password)
        {
            var user =_fakecontext.Persons.FirstOrDefault(x=>x.UserName==username&& x.Password==password);

            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {	                    //Add any claim	
                    new Claim(ClaimTypes.Name, user.ID.ToString())
                }),
                //Expire token after some time	           
                Expires = DateTime.UtcNow.AddDays(7),
                //Let's also sign token credentials for a security aspect, this is important!!!	         
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token= tokenHandler.WriteToken(token);
        
            return user;
        }

    }
}
