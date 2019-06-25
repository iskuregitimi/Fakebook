namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FriendTable")]
    public partial class FriendTable
    {
        public int ID { get; set; }

        public int FriendRequest { get; set; }

        public int incomingFriendRequest { get; set; }
    }
}
