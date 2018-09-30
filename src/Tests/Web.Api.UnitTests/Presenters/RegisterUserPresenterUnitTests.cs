using System.Net;
using Newtonsoft.Json;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Presenters;
using Xunit;

namespace Web.Api.UnitTests.Presenters
{
    public class RegisterUserPresenterUnitTests
    {
        [Fact]
        public void Contains_Ok_Status_Code_When_Use_Case_Response_Succeeds()
        {
            // arrange
            var presenter = new RegisterUserPresenter();

            // act
            presenter.Handle(new RegisterUserResponse("", true));

            // assert
            Assert.Equal((int)HttpStatusCode.OK,presenter.ContentResult.StatusCode);
        }

        [Fact]
        public void Contains_Id_When_Use_Case_Response_Succeeds()
        {
            // arrange
            var presenter = new RegisterUserPresenter();

            // act
            presenter.Handle(new RegisterUserResponse("1234", true));

            // assert
            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
            Assert.True(data.Success.Value);
            Assert.Equal("1234",data.Id.Value);
        }

        [Fact]
        public void Contains_Errors_When_Use_Case_Response_Fails()
        {
            // arrange
            var presenter = new RegisterUserPresenter();

            // act
            presenter.Handle(new RegisterUserResponse(new [] {"missing first name"}));

            // assert
            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
            Assert.False(data.Success.Value);
            Assert.Equal("missing first name", data.Errors.First.Value);
        }
    }
}
