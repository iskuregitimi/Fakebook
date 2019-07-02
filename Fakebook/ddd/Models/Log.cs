using System;
using System.Collections.Generic;

namespace ddd.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public DateTime Date { get; set; }
        public string Information { get; set; }
    }
}
