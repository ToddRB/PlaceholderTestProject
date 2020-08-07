using Common.Models;
using RestSharp;

namespace Common.Api
{
    public class PlaceholderService
    {
        private readonly string Service = "https://jsonplaceholder.typicode.com";

        public ServiceRequest GetAllPlaceholdersRequest()
        {
            return new ServiceRequest
            {
                Url = $"/{Service}/posts/",
                Method = Method.GET
            };
        }

        public ServiceRequest GetPlaceholdersRequestById(int placeholderId)
        {
            return new ServiceRequest
            {
                Url = $"/{Service}/posts/{placeholderId}",
                Method = Method.GET
            };
        }
    }
}
