using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Base
{
    [TestClass]
    public class BaseTest
    {
        public static TestContext testContext;
      
        public BaseTest()
        {
            
        }

        public TestContext GetTestContext()
        {
            return testContext;
        }

        public void SetTestContext(TestContext context)
        {
            testContext = context;
        }

        public void SetupTest()
        {
            
        }

        public void FinalizeTest(TestContext testContext)
        {

        }
    }
}