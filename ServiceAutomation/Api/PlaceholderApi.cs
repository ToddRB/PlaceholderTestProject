using Common.Models;
using Newtonsoft.Json;
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
                Url = $"{Service}/posts/",
                Method = Method.GET
            };
        }

        public ServiceRequest GetPlaceholdersRequestById(int placeholderId)
        {
            return new ServiceRequest
            {
                Url = $"{Service}/posts/{placeholderId}",
                Method = Method.GET
            };
        }

        public ServiceRequest PostPlaceholder(PlaceholderPost post)
        {
            return new ServiceRequest
            {
                Url = $"{Service}/posts",
                Method = Method.POST,
                Json = JsonConvert.SerializeObject(post)
            };
        }

        public ServiceRequest PutPlaceholderById(PlaceholderPost post, int placeholderId)
        {
            return new ServiceRequest
            {
                Url = $"{Service}/posts/{placeholderId}",
                Method = Method.PUT,
                Json = JsonConvert.SerializeObject(post)
            };
        }

        public ServiceRequest DeletePlaceholderById(int placeholderId)
        {
            return new ServiceRequest
            {
                Url = $"{Service}/posts/{placeholderId}",
                Method = Method.DELETE
            };
        }

        public ServiceRequest PatchPlaceholderById(PlaceholderPost post, int placeholderId)
        {
            return new ServiceRequest
            {
                Url = $"{Service}/posts/{placeholderId}",
                Method = Method.PATCH,
                Json = JsonConvert.SerializeObject(post)
            };
        }
    }
}
