using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fakebook.CoreUI
{
    public static class HttpHelper
    {
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
            return response2.Data;
        }

        public static T SendRequestParam<T>(string host, string resource, object id, Method httpMethod) where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource + "?id={id}", httpMethod);

            request.AddParameter("id", id, ParameterType.UrlSegment);

            var response2 = client.Execute<T>(request);
            return response2.Data;
        }

        public static void DeleteMethod(string host, string resource, Method Httpmethod, object id)
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, Httpmethod);
            request.AddParameter("id", id);
            client.Execute(request);
        }
    }
}
