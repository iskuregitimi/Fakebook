using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fakebook.CoreUI.Filters
{
	public class AuthFilter :  IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			throw new NotImplementedException();
		}
	}



}
