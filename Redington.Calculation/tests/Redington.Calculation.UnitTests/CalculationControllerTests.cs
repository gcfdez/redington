using Microsoft.AspNetCore.Mvc;
using Moq;
using Redington.Calculation.Domain;
using System.Threading.Tasks;
using Xunit;

namespace Redington.Calculation.Api.Tests
{
    public class CalculationControllerTests
    {
        private ILogFileService _logService;

        public CalculationControllerTests()
        {
            _logService = new Mock<ILogFileService>().Object;
        }

        private CalculationController GetCalculationController()
        {
            return new CalculationController(_logService);
        }

        [Fact]
        public async Task CalculationController_CombineWith_Ok()
        {
            var calculationRequest = SeedData.CreateValidCalculationRequest();
            var calculationController = GetCalculationController();

            var actionResult = await calculationController.CalculateCombinedWithFunction(calculationRequest);
            var okObjectResult =
                Assert.IsType<OkObjectResult>(actionResult);

            Assert.NotNull(okObjectResult);
            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.IsType<CalculationResult>(okObjectResult.Value);

            var model = Assert.IsType<CalculationResult>(okObjectResult.Value);

            Assert.Equal(0.8m, model.Result);
        }

        [Fact]
        public async Task CalculationController_CombineWith__WrongProbabilityA_BadRequest()
        {
            var calculationRequest = SeedData.CreateInvalidCalculationRequestWithWrongProbabilityA();
            var calculationController = GetCalculationController();

            var actionResult = await calculationController.CalculateCombinedWithFunction(calculationRequest);
            var badRequestResult =
                Assert.IsType<BadRequestObjectResult>(actionResult);

            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal("Value [1.5] is not valid (Parameter 'Value')", badRequestResult.Value);
        }

        [Fact]
        public async Task CalculationController_CombineWith__WrongProbabilityB_BadRequest()
        {
            var calculationRequest = SeedData.CreateInvalidCalculationRequestWithWrongProbabilityB();
            var calculationController = GetCalculationController();

            var actionResult = await calculationController.CalculateCombinedWithFunction(calculationRequest);

            var badRequestResult =
                Assert.IsType<BadRequestObjectResult>(actionResult);

            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal("Value [-0.8] is not valid (Parameter 'Value')", badRequestResult.Value);
        }

        [Fact]
        public async Task CalculationController_Either_Ok()
        {
            var calculationRequest = SeedData.CreateValidCalculationRequest();
            var calculationController = GetCalculationController();

            var actionResult = await calculationController.CalculateEitherFunction(calculationRequest);
            var okObjectResult =
                Assert.IsType<OkObjectResult>(actionResult);

            Assert.NotNull(okObjectResult);
            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.IsType<CalculationResult>(okObjectResult.Value);

            var model = Assert.IsType<CalculationResult>(okObjectResult.Value);

            Assert.Equal(1, model.Result);
        }

        [Fact]
        public async Task CalculationController_Either__WrongProbabilityA_BadRequest()
        {
            var calculationRequest = SeedData.CreateInvalidCalculationRequestWithWrongProbabilityA();
            var calculationController = GetCalculationController();

            var actionResult = await calculationController.CalculateEitherFunction(calculationRequest);
            var badRequestResult =
                Assert.IsType<BadRequestObjectResult>(actionResult);

            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async Task CalculationController_Either__WrongProbabilityB_BadRequest()
        {
            var calculationRequest = SeedData.CreateInvalidCalculationRequestWithWrongProbabilityB();
            var calculationController = GetCalculationController();

            var actionResult = await calculationController.CalculateEitherFunction(calculationRequest);
            var badRequestResult =
                Assert.IsType<BadRequestObjectResult>(actionResult);

            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
        }
    }
}
