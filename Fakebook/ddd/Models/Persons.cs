using System;
using System.Collections.Generic;

namespace ddd.Models
{
    public partial class Persons
    {
        public Persons()
        {
            FriendsPerson1 = new HashSet<Friends>();
            FriendsPerson2 = new HashSet<Friends>();
            MessagesIncomming = new HashSet<Messages>();
            MessagesOutgoing = new HashSet<Messages>();
            Posts = new HashSet<Posts>();
        }

        public int PersonId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Friends> FriendsPerson1 { get; set; }
        public virtual ICollection<Friends> FriendsPerson2 { get; set; }
        public virtual ICollection<Messages> MessagesIncomming { get; set; }
        public virtual ICollection<Messages> MessagesOutgoing { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
