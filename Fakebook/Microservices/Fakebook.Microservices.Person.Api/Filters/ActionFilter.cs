using Fakebook.Microservices.Person.Api.DataBase;

using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fakebook.Microservices.Person.Api.Filters
{



	public class ActionFilter : ActionFilterAttribute ,IActionFilter
	{

		FakebookDataContext _fakebookDataContext;

		public ActionFilter(FakebookDataContext fakebookDataContext)
		{
			_fakebookDataContext = fakebookDataContext;
		}


		//action çalıştıktan sonra
		public void OnActionExecuted(ActionExecutedContext context)
		{
			_fakebookDataContext.Logs.Add(new Logs()
			{
				ID = 1,
				UserName = string.Empty,
				ActionName = "",
				ControllerName = "",
				Date = DateTime.Now,
				information = "OnActionExecuted",


			});
		}
		//action çalışmadan hemen önce
		public void OnActionExecuting(ActionExecutingContext context)
		{


			_fakebookDataContext.Logs.Add(new Logs()
			{
				ID=1,
				UserName = string.Empty,
				ActionName = "",
				ControllerName = "",
				Date = DateTime.Now,
				information = "OnActionExecuting",


			});
		}
	}
}
