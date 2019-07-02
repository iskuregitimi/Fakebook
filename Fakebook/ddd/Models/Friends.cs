using System;
using System.Collections.Generic;

namespace ddd.Models
{
    public partial class Friends
    {
        public int FriendsId { get; set; }
        public int Person1Id { get; set; }
        public int Person2Id { get; set; }
        public string Date { get; set; }
        public bool IsRequest { get; set; }

        public virtual Persons Person1 { get; set; }
        public virtual Persons Person2 { get; set; }
    }
}
