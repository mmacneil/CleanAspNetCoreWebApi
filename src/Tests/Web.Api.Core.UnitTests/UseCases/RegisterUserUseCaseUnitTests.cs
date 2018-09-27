using Xunit;

namespace Web.Api.Core.UnitTests.UseCases
{
    public class RegisterUserUseCaseUnitTests
    {
        [Fact]
        public void Can_Register_User()
        {
            // arrange
            var userRepository = new UserRepository();
            var useCase = new RegisterUserUseCase(userRepository);
            var user = new AppUser("test", "user", "somePa$$W0rd");

            // act
            var response = useCase.Handle(user);

            // assert
            Assert.True(response);
        }
    }
}
