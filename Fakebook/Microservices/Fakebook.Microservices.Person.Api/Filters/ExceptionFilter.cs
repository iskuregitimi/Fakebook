using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fakebook.Microservices.Person.Api.Filters
{
	public class ExceptionFilter : IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			context.ExceptionHandled = true;
			throw new NotImplementedException();
		}
	}
}
