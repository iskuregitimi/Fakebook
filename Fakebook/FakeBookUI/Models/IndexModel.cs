using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeBookUI.Models
{
    public class IndexModel
    {

        public List<PostModel> Post{ get; set; }
       

        public List<FriendModel> Friend { get; set; }
        public List<MessageModel> Messages { get; set; }
    }
}
