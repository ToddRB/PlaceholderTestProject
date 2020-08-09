using Common.Models;
using Newtonsoft.Json;

namespace Common.Library
{
    public static class DeserializeResponses
    {
        public static PlaceholderPost GetPlaceholderPostAsJson(Response response)
        {
            var result = JsonConvert.DeserializeObject<PlaceholderPost>(response.RestResponse.Content);
            return result;
        }
    }
}
