using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public static T List<T>(string host, string resource, Method httpMethod)
          where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod) { RequestFormat = DataFormat.Json };
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public static T Login<T>(string host, string resource, string username, string password, Method httpMethod)
          where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod) { RequestFormat = DataFormat.Json };
            request.AddParameter("username", username);
            request.AddParameter("password", password);          
            var response = client.Execute<T>(request);
            return response.Data;
        }
    }
}
