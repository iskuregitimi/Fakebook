using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fakebook.Microservices.Person.Api.DataBase
{
	public class Logs
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string UserName { get; set; }
		public string ActionName { get; set; }
		public string ControllerName { get; set; }
		public DateTime Date { get; set; }
		public string Information { get; set; }
	}
}
