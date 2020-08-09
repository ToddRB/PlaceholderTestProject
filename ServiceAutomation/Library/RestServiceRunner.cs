using Common.Models;
using RestSharp;
using System;

namespace Common.Library
{
    public class RestServiceRunner
    {
        public static Response SendRequest(ServiceRequest serviceRequest)
        {
            var client = GetRestClient(serviceRequest);
            var request = SetRequestHeaders(serviceRequest);
            var response = client.Execute<PlaceholderPost>(request);

            var sendRequest = new Response();
            {
                sendRequest.RestResponse = response;
            }

            return sendRequest;
        }

        public static RestRequest SetRequestHeaders(ServiceRequest serviceRequest)
        {
            var request = new RestRequest(serviceRequest.Url, serviceRequest.Method) { Timeout = 900000 };
            foreach (var header in serviceRequest.RequestHeaders)
            {
                request.AddHeader(header.Name, header.Value);
            }
            if (!string.IsNullOrEmpty(serviceRequest.Json))
            {
                request.AddParameter("application/json", serviceRequest.Json, ParameterType.RequestBody);
            }
            return request;
        }

        public static RestClient GetRestClient(ServiceRequest serviceRequest)
        {
            return new RestClient
            {
                BaseUrl = new Uri(serviceRequest.Url)
            };
        }
    }
}
