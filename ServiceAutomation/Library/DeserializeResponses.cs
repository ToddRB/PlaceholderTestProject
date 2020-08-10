using Common.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Common.Library
{
    public static class DeserializeResponses
    {
        public static PlaceholderPost GetPlaceholderPostAsJson(Response response)
        {
            var result = JsonConvert.DeserializeObject<PlaceholderPost>(response.RestResponse.Content);
            return result;
        }

        public static PlaceholderPost GetPlaceholderPostAsJson(string json)
        {
            var result = JsonConvert.DeserializeObject<PlaceholderPost>(json);
            return result;
        }

        public static List<PlaceholderPost> GetPlaceholderPostListAsJson(Response response)
        {
            var result = JsonConvert.DeserializeObject<List<PlaceholderPost>>(response.RestResponse.Content);
            return result;
        }
    }
}
