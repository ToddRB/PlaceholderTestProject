using RestSharp;
using System.Net;

namespace Common.Models
{
    public class Response
    {
        public IRestResponse RestResponse;

        public HttpStatusCode StatusCode { get; set; }
    }
}
