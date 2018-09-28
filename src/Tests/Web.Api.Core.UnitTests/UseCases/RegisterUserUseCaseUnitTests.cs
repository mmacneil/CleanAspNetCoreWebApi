using System.Linq;
using System.Threading.Tasks;
using Moq;
using Web.Api.Core.Domain;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.UseCases;
using Xunit;

namespace Web.Api.Core.UnitTests.UseCases
{
    public class RegisterUserUseCaseUnitTests
    {
        [Fact]
        public async void Can_Register_User()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.Create(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult((success: true, id: "", errors: new[] { (code: "", description: "") }.AsEnumerable())));

            var mockOutputPort = new Mock<IOutputPort<RegisterUserResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<RegisterUserResponse>()));

            var useCase = new RegisterUserUseCase(mockUserRepository.Object);

            // act
            var response = await useCase.Handle(new RegisterUserRequest("", "", "", ""), mockOutputPort.Object);

            // assert
            Assert.True(response);
        }
    }
}
