﻿using System;
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

namespace FakeBookUI.Controllers
{
    public class HomeController : Controller
    {
        HttpHelper _helper;
        public HomeController(HttpHelper helper)
        {
            _helper = helper;
        }
        public IActionResult Index()
        {
            List<PostModel> post = new List<PostModel>();
    
            List<FriendModel> friends = new List<FriendModel>();
           post = HttpHelper.SendRequest<List<PostModel>>("http://localhost:14258/api/", "Post/GetPost", Method.GET);
           friends =HttpHelper.SendRequest<List<FriendModel>>("http://localhost:14258/api/", "Friend/GetFriends", Method.GET);

            int count = 0;
            foreach (var item in friends)
            {
                count += friends.Count;

            }
            string coo = count.ToString();
            ViewData["Count"] = count.ToString();
            ViewBag.sessionp = HttpContext.Session.GetString("People");
                return View(post);
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
