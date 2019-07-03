using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FakeBookENTITIY.DataBase
{
 public   class User_T
    {
        [Key]
        public int ID { get; set; }
        public int PeopleID { get; set; }
        public string Token{ get; set; }
    }
}
