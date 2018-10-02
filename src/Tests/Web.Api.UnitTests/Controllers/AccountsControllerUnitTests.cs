using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Web.Api.Controllers;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.GatewayResponses.Repositories;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.UseCases;
using Web.Api.Presenters;
using Xunit;

namespace Web.Api.UnitTests.Controllers
{
    public class AccountsControllerUnitTests
    {
        [Fact]
        public async void Post_Returns_Ok_When_Use_Case_Succeeds()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.Create(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new CreateUserResponse("",true)));

            // fakes
            var outputPort = new RegisterUserPresenter();
            var useCase = new RegisterUserUseCase(mockUserRepository.Object);
            
            var controller = new AccountsController(useCase, outputPort);

            // act
            var result = await controller.Post(new Models.Request.RegisterUserRequest());

            // assert
            var statusCode = ((ContentResult) result).StatusCode;
            Assert.True(statusCode.HasValue && statusCode.Value == (int) HttpStatusCode.OK);
        }

        [Fact]
        public async void Post_Returns_Bad_Request_When_Model_Validation_Fails()
        {
            // arrange
            var controller = new AccountsController(null,null);
            controller.ModelState.AddModelError("FirstName", "Required");

            // act
            var result = await controller.Post(null);

            // assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }
    }
}
