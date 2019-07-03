using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fakebook.CoreUI.Models;
using FakeBookUI.Models;
using FakeBook;
using RestSharp;
using RabbitMQ.Client.Impl;
using Microsoft.AspNetCore.Http;
using Fakebook.CoreUI;

namespace FakeBookUI.Controllers
{
    public class HomeController : Controller
    {
        HttpHelper _helper;
        public HomeController(HttpHelper helper)
        {
            _helper = helper;
        }
        
        public IActionResult Index(/*PeopleModel peopleModel1*/)
        {
            MessageModel message = new MessageModel();

            //int id = Convert.ToInt32(HttpContext.Session.GetInt32("peopleID"));



            User_TModel user_TModel= HttpContext.Session.GetObjectFromJson<User_TModel>("token");
            if (user_TModel!=null)
            {

            message.ReceiverID = user_TModel.PeopleID;
            }
                
            IndexModel ındexModel = new IndexModel();
            ındexModel.Post = HttpHelper.SendRequest<List<PostModel>>("http://localhost:14258/api/", "Post/GetPost", Method.GET);
           ındexModel.Friend =HttpHelper.SendRequest<List<FriendModel>>("http://localhost:14258/api/", "Friend/GetFriends", Method.GET);
            ındexModel.Messages = HttpHelper.SendRequestModel<List<MessageModel>>("http://localhost:14258/api/", "Message/GetMessages", message, Method.POST);
            int count = 0;
           
            foreach (var item in ındexModel.Friend)
            {
                count += ındexModel.Friend.Count;

            }
          
            ViewData["Count"] = count.ToString();

        ViewBag.userss = HttpContext.Session.GetString("user");


                return View(ındexModel);
         
        }

        public IActionResult Friend()
        {
            List<FriendModel> friends = new List<FriendModel>();
            friends = HttpHelper.SendRequest<List<FriendModel>>("http://localhost:14258/api/", "Friend/GetFriends", Method.GET);
            

            return View(friends);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
