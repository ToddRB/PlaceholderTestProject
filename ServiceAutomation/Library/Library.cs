using Common.Api;
using Common.Models;
using System.Collections.Generic;

namespace Common.Library
{
    public static class Library
    {
        private static readonly PlaceholderService service = new PlaceholderService();

        public static PlaceholderPost GetAllPlaceholders()
        {
            var postMessageRequest = service.GetAllPlaceholdersRequest();
            var postMessageResponse = RestServiceRunner.SendRequest(postMessageRequest);
            var jsonResponse = DeserializeResponses.GetPlaceholderPostAsJson(postMessageResponse);
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