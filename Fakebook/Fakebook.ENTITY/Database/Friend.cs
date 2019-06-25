using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FakeBookENTITIY.DataBase
{
    public class Friend
    {
        [Key]
        public int ID { get; set; }

        public int FriendRequest { get; set; }

        public int incomingFriendRequest { get; set; }

    }
}
