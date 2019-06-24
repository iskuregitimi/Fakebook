using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fakebook.Microservices.Person.Api.DataBase
{
	public class FakebookDataContext:DbContext
	{

		public FakebookDataContext(DbContextOptions<FakebookDataContext> options)
		   : base(options)
		{

		}
		public DbSet<Persons> Persons { get; set; }
	}
}
