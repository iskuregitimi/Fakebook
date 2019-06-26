using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeBookUI.Models
{
    public class MessageModel
    {
        public int SenderID { get; set; }

        public int ReceiverID { get; set; }

        public string MessageTitle { get; set; }

        public string MessageDetail { get; set; }
    }
}
