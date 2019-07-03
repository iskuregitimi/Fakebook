using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeBook;
using FakeBookUI.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Microsoft.AspNetCore.Http;
using Fakebook.CoreUI.Models;
using Fakebook.CoreUI;

namespace FakeBookUI.Controllers
{
    public class MessageController : Controller
    {

        public IActionResult GetMessages()
        {
            MessageModel messageModel = new MessageModel();
            messageModel.ListMessage = HttpHelper.SendRequest<List<MessageModel>>("http://localhost:14258/api", "Message/Messages", Method.GET);

            return View(messageModel);
        }
        [HttpGet]
        public IActionResult GetDetail(int id)
        {
            MessageModel message = HttpHelper.SendRequestModel<MessageModel>("http://localhost:14258/api", "Message/GetMessageDetail", id, Method.POST);

            return View(message);

        }
        public IActionResult SendMessage(MessageModel messageModel)
        {

            PeopleModel peopleModel = HttpContext.Session.GetObjectFromJson<PeopleModel>("user");
            messageModel.SenderID = peopleModel.ID;
            HttpHelper.SendRequestModel<MessageModel>("http://localhost:14258/api", "Message/SendMessage", messageModel, Method.POST);
            return RedirectToAction("Index", "Home");

        }
    }
}