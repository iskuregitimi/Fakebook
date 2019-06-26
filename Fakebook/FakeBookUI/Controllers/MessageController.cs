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
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendMessage(MessageModel messageModel)
        {
            HttpHelper.SendRequestModel<MessageModel>("http://localhost:14258/api", "Message/SendMessage", messageModel, Method.POST);
            return RedirectToAction("Index", "Home");

        }
    }
}