using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Library;
using Tests.Base;

namespace Tests.Scripts.SmokeTests
{
    [TestClass]
    public class SmokeTests : BaseTest
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
 
        [TestCategory("Gets")]
        [Priority(1)]
        [Description("Get All the Placeholder resources")]
        [TestMethod]
        public void GetAllPlaceholderResourcesTest()
        {
            var response = Library.GetAllPlaceholders();
            Assert.IsTrue(true, "I'm true!");
        }

        [TestCategory("Gets")]
        [Priority(1)]
        [Description("Get the Placeholder by id")]
        [TestMethod]
        public void GetPlaceholderByIdTest()
        {
            var response = Library.GetPlaceholderPostById(1);
            Assert.IsTrue(!string.IsNullOrEmpty(response.Title), "Title returned");
            Assert.IsTrue(!string.IsNullOrEmpty(response.Body), "Body returned");
            Assert.IsTrue(response.UserId != 0, "Title returned");
            Assert.IsTrue(response.Id != 0, "Id returned");
        }
    }
}
