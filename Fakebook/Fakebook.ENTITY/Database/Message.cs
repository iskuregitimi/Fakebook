using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FakeBookENTITIY.DataBase
{
    public class Message
    {
        [Key]
        public int ID { get; set; }

        public int SenderID { get; set; }

        public int ReceiverID { get; set; }

        public string MessageTitle { get; set; }

        public string MessageDetail { get; set; }

    }
}
