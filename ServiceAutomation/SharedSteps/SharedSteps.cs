using Common.Models;
using Newtonsoft.Json;

namespace Common.SharedSteps
{
    public static class SharedSteps
    {
        public static PlaceholderPost GetCustomModelFromJson(dynamic response)
        {
            return null; // JsonConvert.DeserializeObject<PlaceholderPost>(response.DataSerialized);
        }
    }
}
