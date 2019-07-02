using Fakebook.Microservices.Person.Api.DataBase;

using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fakebook.Microservices.Person.Api.Filters
{



	public class ActionFilter : IActionFilter
	{
		FakebookDataContext _fakebookDataContext;
		public ActionFilter(FakebookDataContext fakebookDataContext)
		{
			_fakebookDataContext = fakebookDataContext;
		}
		//action çalıştıktan sonra
		public void OnActionExecuted(ActionExecutedContext context)
		{

			var logs = new Logs()
			{
				Id=1,
				UserName = "fadile",
				ActionName = "kaydet",
				ControllerName = "dfw",
				Date = DateTime.Now,
				Information = "bilgi",
			};
			_fakebookDataContext.Logs.Add(logs);
			_fakebookDataContext.SaveChanges();



			//var result=_fakebookDataContext.Logs.Add(new Logs()
			//{
			//	UserName = string.Empty,
			//	ActionName = "",
			//	ControllerName = "",
			//	Date = DateTime.Now,
			//	information = "OnActionExecuted",
			//});
			//_fakebookDataContext.SaveChanges();


			//var author = new Author { FirstName = "William", LastName = "Shakespeare" };
			//context.Add<Author>(author);
			//context.SaveChanges();
		}
		//action çalışmadan hemen önce
		public void OnActionExecuting(ActionExecutingContext context)
		{


			Logs logs = new Logs()
			{
				Id = 1,
				UserName = "fadile",
				ActionName = "kaydet",
				ControllerName = "dfw",
				Date = DateTime.Now,
				Information = "bilgi",
			};
			_fakebookDataContext.Logs.Add(logs);
			_fakebookDataContext.SaveChanges();

			//_fakebookDataContext.Logs.Add(new Logs()
			//{		
			//	UserName = string.Empty,
			//	ActionName = "",
			//	ControllerName = "",
			//	Date = DateTime.Now,
			//	information = "OnActionExecuting",
			//});
			//_fakebookDataContext.SaveChanges();
		}
	}
}
