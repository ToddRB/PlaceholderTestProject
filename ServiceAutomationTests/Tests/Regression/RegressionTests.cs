using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [Priority(1)]
        [Description("Get the Placeholder by an invalid id")]
        [TestMethod]
        public void GetPlaceholderByIdNegativeTest()
        {
            var response = PlaceholderLibrary.GetPlaceholderPostById(200); 
            Assert.IsTrue(string.IsNullOrEmpty(response.Title), "Invalid response");
            Assert.IsTrue(string.IsNullOrEmpty(response.Body), "Invalid response");
            Assert.IsTrue(response.UserId == 0, "Invalid response");
            Assert.IsTrue(response.Id == 0, "Invalid response");
        }

        [TestCategory("Get")]
        [TestCategory("Fail")]
        [Priority(2)]
        [Description("Get the Placeholder by id and compare with file")]
        [TestMethod]
        public void GetPlaceholderByIdFileCompareTest()
        {
            var response = PlaceholderLibrary.GetPlaceholderPostById(1);
            var json = JsonReader.ReadJsonFromInputFile("1Record.json");
            var placeholderJson = DeserializeResponses.GetPlaceholderPostAsJson(json);

            Assert.IsTrue(response.Title == placeholderJson.Title, "I expect this to fail actually");
        }
    }
}
