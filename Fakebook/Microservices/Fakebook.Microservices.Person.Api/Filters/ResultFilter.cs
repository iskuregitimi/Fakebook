using Fakebook.Microservices.Person.Api.DataBase;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fakebook.Microservices.Person.Api.Filters
{
	public class ResultFilter : IResultFilter
	{

		FakebookDataContext _fakebookDataContext;
		public ResultFilter(FakebookDataContext fakebookDataContext)
		{
			_fakebookDataContext = fakebookDataContext;
		}


		public void OnResultExecuted(ResultExecutedContext context)
		{
			var result = _fakebookDataContext.Logs.Add(new Logs()
			{
				UserName = string.Empty,
				ActionName = "",
				ControllerName = "",
				Date = DateTime.Now,
				Information = "OnResultExecuted",
			});
			_fakebookDataContext.SaveChanges();
		}

		public void OnResultExecuting(ResultExecutingContext context)
		{
			//throw new NotImplementedException();
		}
	}
}
