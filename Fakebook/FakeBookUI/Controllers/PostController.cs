using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeBook;
using FakeBookUI.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace FakeBookUI.Controllers
{
    public class PostController : Controller
    {
        [HttpPost]
        public IActionResult InsertPost(PostModel postModel)
        {
            HttpHelper.SendRequest<PostModel>("http://localhost:14258/api/", "Post/InsertPost", Method.POST);
            return RedirectToAction("Index","Home");
        }
    }
}