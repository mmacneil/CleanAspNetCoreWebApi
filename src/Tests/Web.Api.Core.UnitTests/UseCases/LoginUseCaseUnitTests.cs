using System.Threading.Tasks;
using Moq;
using Web.Api.Core.Dto;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.UseCases;
using Xunit;

namespace Web.Api.Core.UnitTests.UseCases
{
  public class LoginUseCaseUnitTests
  {
    [Fact]
    public async void Can_Login()
    {
      // arrange
      var mockUserRepository = new Mock<IUserRepository>();
      mockUserRepository
        .Setup(repo => repo.Login(It.IsAny<string>(), It.IsAny<string>()))
        .Returns(Task.FromResult(new Dto.GatewayResponses.Repositories.LoginResponse(new Token("", "", 0), true)));

      var useCase = new LoginUseCase(mockUserRepository.Object);

      var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();
      mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

      // act
      var response = await useCase.Handle(new LoginRequest("userName", "password"), mockOutputPort.Object);

      // assert
      Assert.True(response);
    }
  }
}
