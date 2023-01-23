using Common.Api;
using Common.Models;
using System.Collections.Generic;
using System.Net;

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

        public static bool GetPlaceholderPostByInvalidId(int id)
        {
            var postMessageRequest = service.GetPlaceholdersRequestById(id);
            var postMessageResponse = RestServiceRunner.SendRequest(postMessageRequest);
            return postMessageResponse.StatusCode == HttpStatusCode.NotFound;
        }

        public static PlaceholderPost PostPlaceholderRecord()
        {
            PlaceholderPost post = new PlaceholderPost();
            {
                post.UserId = 101;
                post.Title = "Todds Post Title";
                post.Body = "Todds Post Body";
            }

            var postMessageRequest = service.PostPlaceholder(post);
            var postMessageResponse = RestServiceRunner.SendRequest(postMessageRequest);
            var jsonResponse = DeserializeResponses.GetPlaceholderPostAsJson(postMessageResponse);
            return jsonResponse;
        }

        public static PlaceholderPost PostInvalidPlaceholderRecord()
        {
            PlaceholderPost post = new PlaceholderPost();
            {
                post.UserId = -1;
                post.Title = "Todds Post Title";
                post.Body = "Todds Post Body";
            }

            var postMessageRequest = service.PostPlaceholder(post);
            var postMessageResponse = RestServiceRunner.SendRequest(postMessageRequest);
            var jsonResponse = DeserializeResponses.GetPlaceholderPostAsJson(postMessageResponse);
            return jsonResponse;
        }

        public static PlaceholderPost ThisWouldBeAFunnyBug()
        {
            PlaceholderPost post = new PlaceholderPost();
            {
                post.UserId = 999;
                post.Title = "X Æ A-12 Musk";
                post.Body = "X Æ A-12 Musk";
            }

            var postMessageRequest = service.PostPlaceholder(post);
            var postMessageResponse = RestServiceRunner.SendRequest(postMessageRequest);
            var jsonResponse = DeserializeResponses.GetPlaceholderPostAsJson(postMessageResponse);
            return jsonResponse;
        }

        public static PlaceholderPost PutPlaceholderRecord(int placeholderId)
        {
            PlaceholderPost post = new PlaceholderPost();
            {
                post.UserId = 201;
                post.Title = "Todds Put Title";
                post.Body = "Todds Put Body";
            }

            var postMessageRequest = service.PutPlaceholderById(post, placeholderId);
            var postMessageResponse = RestServiceRunner.SendRequest(postMessageRequest);
            var jsonResponse = DeserializeResponses.GetPlaceholderPostAsJson(postMessageResponse);
            return jsonResponse;
        }

        public static bool DeletePlaceholderRecord(int placeholderId)
        {
            var postMessageRequest = service.DeletePlaceholderById(placeholderId);
            var postMessageResponse = RestServiceRunner.SendRequest(postMessageRequest);
            return postMessageResponse.StatusCode == HttpStatusCode.OK;
        }

        public static PlaceholderPost PatchPlaceholderRecord(int placeholderId)
        {
            PlaceholderPost post = new PlaceholderPost();
            {
                post.Id = 1;
                post.UserId = 1;
                post.Title = "Todds Patch Title";
                post.Body = "Todds Patch Body";
            }

            var postMessageRequest = service.PatchPlaceholderById(post, placeholderId);
            var postMessageResponse = RestServiceRunner.SendRequest(postMessageRequest);
            var jsonResponse = DeserializeResponses.GetPlaceholderPostAsJson(postMessageResponse);
            return jsonResponse;
        }
    }
}