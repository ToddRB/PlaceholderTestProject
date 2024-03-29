﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Library;
using Tests.Base;

namespace Tests.Scripts.RegressionTests
{
    [TestClass]
    public class RegressionTests : BaseTest
    {
        [TestCleanup]
        public void TearDown()
        {
            FinalizeTest(testContext);
        }

        [TestInitialize]
        public void Setup()
        { }

        [ClassInitialize]
        public static void TestClassInitialize(TestContext context)
        {
            testContext = context;
        }
 
        [TestCategory("Get")]
        [TestCategory("Positive")]
        [Priority(1)]
        [Description("Get All the Placeholder resources")]
        [TestMethod]
        public void GetAllPlaceholderResourcesTest()
        {
            var response = PlaceholderLibrary.GetAllPlaceholders();
            Assert.IsTrue(response.Count == 100);
            Assert.IsTrue(!string.IsNullOrEmpty(response[0].Title), "Check that at least one record is valid");
            Assert.IsTrue(!string.IsNullOrEmpty(response[0].Body), "Body returned");
            Assert.IsTrue(response[0].UserId != 0, "Title returned");
            Assert.IsTrue(response[0].Id != 0, "Id returned");
        }

        [TestCategory("Get")]
        [TestCategory("Positive")]
        [Priority(1)]
        [Description("Get the Placeholder by id")]
        [TestMethod]
        public void GetPlaceholderByIdTest()
        {
            var response = PlaceholderLibrary.GetPlaceholderPostById(1);
            Assert.IsTrue(!string.IsNullOrEmpty(response.Title), "Title returned");
            Assert.IsTrue(!string.IsNullOrEmpty(response.Body), "Body returned");
            Assert.IsTrue(response.UserId != 0, "Title returned");
            Assert.IsTrue(response.Id != 0, "Id returned");
        }

        [TestCategory("Get")]
        [TestCategory("Negative")]
        [Priority(2)]
        [Description("Get the Placeholder by an invalid id")]
        [TestMethod]
        public void GetPlaceholderByIdNegativeTest()
        {
            var response = PlaceholderLibrary.GetPlaceholderPostByInvalidId(200);
            Assert.IsTrue(response, "Response in a bool in this case, and the failed successfully");
        }

        [TestCategory("Fail")]
        [Priority(3)]
        [Description("Get the Placeholder by id and compare with file")]
        [TestMethod]
        public void GetPlaceholderByIdInvalidFileCompareTest()
        {
            var response = PlaceholderLibrary.GetPlaceholderPostById(1);
            var json = JsonReader.ReadJsonFromInputFile("1InvalidRecord.json");
            var placeholderJson = DeserializeResponses.GetPlaceholderPostAsJson(json);

            Assert.IsFalse(response.Title == placeholderJson.Title, "File does not match returned record");
        }

        [TestCategory("Get")]
        [TestCategory("Positive")]
        [Priority(1)]
        [Description("Get the Placeholder by id and compare with file")]
        [TestMethod]
        public void GetPlaceholderByIdValidFileCompareTest()
        {
            var response = PlaceholderLibrary.GetPlaceholderPostById(1);
            var json = JsonReader.ReadJsonFromInputFile("1ValidRecord.json");
            var placeholderJson = DeserializeResponses.GetPlaceholderPostAsJson(json);

            Assert.IsTrue(response.Title == placeholderJson.Title, "Record compared against baseline file title");
            Assert.IsTrue(response.Body == placeholderJson.Body, "Record compared against baseline file title");
        }

        [TestCategory("Post")]
        [TestCategory("Positive")]
        [Priority(1)]
        [Description("Post a new Placeholder record")]
        [TestMethod]
        public void PostPlaceholderTest()
        {
            var response = PlaceholderLibrary.PostPlaceholderRecord();
            Assert.IsTrue(response.Title == "Todds Post Title");
            Assert.IsTrue(response.Body == "Todds Post Body");
            Assert.IsTrue(response.UserId == 101);
            Assert.IsTrue(response.Id == 101);
        }

        [TestCategory("Put")]
        [TestCategory("Positive")]
        [Priority(1)]
        [Description("Put a new Placeholder record")]
        [TestMethod]
        public void PutPlaceholderTest()
        {
            var response = PlaceholderLibrary.PutPlaceholderRecord(1);
            Assert.IsTrue(response.Title == "Todds Put Title");
            Assert.IsTrue(response.Body == "Todds Put Body");
            Assert.IsTrue(response.UserId == 201);
            Assert.IsTrue(response.Id == 1);
        }

        [TestCategory("Delete")]
        [TestCategory("Positive")]
        [Priority(1)]
        [Description("Put a Placeholder record")]
        [TestMethod]
        public void DeletePlaceholderTest()
        {
            var response = PlaceholderLibrary.DeletePlaceholderRecord(1);
            Assert.IsTrue(response, "Response in a bool in this case, and the delete call returned successfully");            
        }

        [TestCategory("Bug?")]
        [TestCategory("Post")]
        [TestCategory("Negative")]
        [Priority(3)]
        [Description("Attempt to Post an invalid Placeholder record")]
        [TestMethod]
        public void PostPlaceholderNegativeTest()
        {
            //I thought the API would prevent negative ids but this passes so tagging it as "Bug?"
            var response = PlaceholderLibrary.PostInvalidPlaceholderRecord();
            Assert.IsTrue(response.Title == "Todds Post Title");
            Assert.IsTrue(response.Body == "Todds Post Body");
            Assert.IsTrue(response.UserId == -1);
            Assert.IsTrue(response.Id == 101);
        }

        [TestCategory("Post")]
        [TestCategory("Negative")]
        [Priority(3)]
        [Description("Attempt to Post an invalid Placeholder record")]
        [TestMethod]
        public void PostPlaceholderNegativeTestSecondTry()
        {
            var response = PlaceholderLibrary.ThisWouldBeAFunnyBug();
            Assert.IsTrue(response.Title == "X Æ A-12 Musk");
            Assert.IsTrue(response.Body == "X Æ A-12 Musk");
            Assert.IsTrue(response.UserId == 999);
            Assert.IsTrue(response.Id == 101);
        }
    }
}
