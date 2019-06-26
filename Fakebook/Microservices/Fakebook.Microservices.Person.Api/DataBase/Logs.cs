using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fakebook.Microservices.Person.Api.DataBase
{
	public class Logs
	{
		[Key]
		public int ID { get; set; }
		public string UserName { get; set; }
		public string ActionName { get; set; }
		public string ControllerName { get; set; }
		public DateTime Date { get; set; }
		public string information { get; set; }
	}
}
