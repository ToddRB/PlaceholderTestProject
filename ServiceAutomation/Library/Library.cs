using Common.Api;
using Common.Models;
using System.Collections.Generic;

namespace Common.Library
{
    public static class Library
    {
        private static readonly PlaceholderService service = new PlaceholderService();

        public static List<PlaceholderPost> GetAllPlaceholders()
        {
            var getSystemMessageRequest = service.GetAllPlaceholdersRequest();
            return null; // ServiceRunner.ServiceRunTests(getSystemMessageRequest);
        }
    }
}