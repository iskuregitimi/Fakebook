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
    public class MessageController : ControllerBase
    {

        Repository<Message> repo_message = new Repository<Message>();
        [HttpGet]
        public List<Message> Messages()
        {
            return repo_message.List();
        }
        [HttpPost]
        public List<Message> GetMessages(Message message)
        {
            return repo_message.List(x=>x.ReceiverID==message.ReceiverID);
        }
        [HttpPost]
        public Message GetMessageDetail(int id)
        {
            return repo_message.Find(x => x.ID == id);
        }
        [HttpPost]
        public void SendMessage(Message message)
        {
            repo_message.Insert(message);
        }
    }
}