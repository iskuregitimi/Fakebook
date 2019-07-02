using System;
using System.Collections.Generic;

namespace ddd.Models
{
    public partial class Posts
    {
        public int PostId { get; set; }
        public DateTime PostDate { get; set; }
        public int PersonId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PostImage { get; set; }

        public virtual Persons Person { get; set; }
    }
}
