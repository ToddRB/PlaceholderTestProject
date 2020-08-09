using Common.Api;
using Common.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Common.Library
{
    public static class PlaceholderLibrary
    {
        private static readonly PlaceholderService service = new PlaceholderService();

        public static List<PlaceholderPost> GetAllPlaceholders()
        {
            var postMessageRequest = service.GetAllPlaceholdersRequest();
            var postMessageResponse = RestServiceRunner.SendRequest(postMessageRequest);
            var jsonResponse = DeserializeResponses.GetPlaceholderPostListAsJson(postMessageResponse);
            return jsonResponse;
        }

        public static PlaceholderPost GetPlaceholderPostById(int id)
        {
            var postMessageRequest = service.GetPlaceholdersRequestById(id);
            var postMessageResponse = RestServiceRunner.SendRequest(postMessageRequest);
            var jsonResponse = DeserializeResponses.GetPlaceholderPostAsJson(postMessageResponse);
            return jsonResponse;
        }
    }
}