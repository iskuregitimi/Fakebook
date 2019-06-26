using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fakebook.Microservices.Social.Api.Models;
using FakeBookENTITIY.DataBase;
using FakeBookENTITIY.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fakebook.Microservices.Social.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        Repository<PostTable> repo_post = new Repository<PostTable>();
        [HttpGet]
        public List<PostTable> GetPost()
        {
           List<PostTable> post=  repo_post.List();
            return post;


        }
        [HttpPost]
        public void InsertPost(PostModel model)
        {
            PostTable postTable = new PostTable
            {
                Detail = model.Detail,
                PostTitle = model.PostTitle,
                SenderID = model.SenderID
            };
            repo_post.Insert(postTable);
        }
    }
}