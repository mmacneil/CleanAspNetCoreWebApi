using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Web.Api.Controllers;
using Web.Api.Core.Domain;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.UseCases;
using Web.Api.Presenters;
using Xunit;

namespace Web.Api.UnitTests.Controllers
{
    public class AccountControllerUnitTests
    {
        [Fact]
        public async void Post_Returns_Ok_When_Use_Case_Succeeds()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.Create(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult((success: true, id: "", errors: new[] { (code: "", description: "") }.AsEnumerable())));

            // fakes
            var outputPort = new RegisterUserPresenter();
            var useCase = new RegisterUserUseCase(mockUserRepository.Object);
            
            var controller = new AccountController(useCase, outputPort);

            // act
            var result = await controller.Post(new Models.Request.RegisterUserRequest
            {
                FirstName = "Mark",
                LastName = "Macneil",
                Password = "Pa$$word!",
                UserName = "mmacneil"
            });

            // assert
            var statusCode = ((ContentResult) result).StatusCode;
            Assert.True(statusCode.HasValue && statusCode.Value == (int) HttpStatusCode.OK);
        }
    }
}
