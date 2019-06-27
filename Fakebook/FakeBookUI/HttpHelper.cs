using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeBook
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
        public static T SendRequest<T>(string host, string resource, Method httpMethod) where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);
            
            var response2 = client.Execute<T>(request);
            return response2.Data;
        }

        public static T SendRequestModel<T>(string host, string resource, object model, Method httpMethod) where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);

            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(model);

            var response2 = client.Execute<T>(request);
            //var tokenHeader = response2.Headers.Where(x => x.Name == "TOKEN").FirstOrDefault();
            //if (tokenHeader != null)
            //{
            //   HttpContext.
            //}
            return response2.Data;
        }

    }
}
