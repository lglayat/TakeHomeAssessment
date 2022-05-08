using Coterie.Api.Controllers;
using Coterie.Api.Services;
using NUnit.Framework;

namespace Coterie.UnitTests
{
    /* Sample service setup and teardown is provided
    For more info - https://docs.nunit.org/articles/nunit/writing-tests/attributes/setup.html */
    
    public class ControllerTestsBase
    {
        // Sample Moq setup
        // protected Mock<ITestService> MockTestService;

        protected RatingEngineService RatingEngineService;
        protected RatingEngineController RatingEngineController;

        [OneTimeSetUp]
        public void BaseOneTimeSetup()
        {
            //MockTestService = new Mock<ITestService>();
            RatingEngineService = new RatingEngineService();
            RatingEngineController = new RatingEngineController(RatingEngineService);
        }

        [TearDown]
        public void Cleanup()
        {
            // Sample reset after each test is ran
            //MockTestService.Reset();
        }
    }
}