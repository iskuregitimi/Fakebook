using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeBookENTITIY.DataBase;
using FakeBookENTITIY.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fakebook.Microservices.Social.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        Repository<FriendTable> repo_friend = new Repository<FriendTable>();
        [HttpGet]
        public List<FriendTable> GetFriends()
        {
            List<FriendTable> friend = repo_friend.List();
            return friend;
        }

    }
}