using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FakeBookENTITIY.DataBase
{
    public class PostTable
    {
        [Key]
        public int ID { get; set; }

        public int SenderID { get; set; }

        public string PostTitle { get; set; }

        public string Detail { get; set; }

    }
}
