using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fakebook.CoreUI
{
    public class HttpHelper
    {
  
        ISession _session;
        public HttpHelper(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }


        public string SendRequest()
        {
            var d = _session.GetString("Deneme");
            return "";
        }
    }
}
