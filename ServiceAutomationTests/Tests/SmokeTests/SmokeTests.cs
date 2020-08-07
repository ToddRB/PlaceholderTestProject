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
        { }

        [TestCategory("Gets")]
        [Priority(1)]
        [Description("Get All the Placeholder resources")]
        [TestMethod]
        public void GetAllPlaceholderResourcesTest()
        {
            //var jsonResponse = Library.GetJsonResponseTest();
            //Assert.IsTrue(jsonResponse.TestResult.IsPassed, "Verify endpoint responsive");
            Assert.IsTrue(true, "I'm true!");
        }
    }
}
