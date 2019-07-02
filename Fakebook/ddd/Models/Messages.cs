using System;
using System.Collections.Generic;

namespace ddd.Models
{
    public partial class Messages
    {
        public int MessageId { get; set; }
        public int OutgoingId { get; set; }
        public int IncommingId { get; set; }
        public string MessageBody { get; set; }
        public DateTime? MessageDate { get; set; }

        public virtual Persons Incomming { get; set; }
        public virtual Persons Outgoing { get; set; }
    }
}
