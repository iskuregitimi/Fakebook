using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fakebook.CoreUI.Models;
using FakeBook;
using FakeBookUI.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Microsoft.AspNetCore.Http;
using Fakebook.CoreUI;

namespace FakeBookUI.Controllers
{
    public class PostController : Controller
    {
        [HttpPost]
        public IActionResult InsertPost(string PostTitle,string Detail)
        {

            PeopleModel peopleModel = HttpContext.Session.GetObjectFromJson<PeopleModel>("user");
            PostModel postModel = new PostModel();
            postModel.SenderID = peopleModel.ID;
            postModel.PostTitle = PostTitle;
            postModel.Detail = Detail;
            HttpHelper.SendRequestModel<PostModel>("http://localhost:14258/api/", "Post/InsertPost", postModel, Method.POST);
            return RedirectToAction("Index", "Home");

        }
    }
}