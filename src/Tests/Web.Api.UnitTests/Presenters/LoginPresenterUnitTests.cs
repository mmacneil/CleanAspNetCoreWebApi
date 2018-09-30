using System.Net;
using Newtonsoft.Json;
using Web.Api.Core.Dto;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Presenters;
using Xunit;

namespace Web.Api.UnitTests.Presenters
{
  public class LoginPresenterUnitTests
  {
    [Fact]
    public void Contains_Ok_Status_Code_When_Use_Case_Succeeds()
    {
      // arrange
      var presenter = new LoginPresenter();

      // act
      presenter.Handle(new LoginResponse(new Token("","",0), true));

      // assert
      Assert.Equal((int)HttpStatusCode.OK, presenter.ContentResult.StatusCode);
    }

    [Fact]
    public void Contains_Token_When_Use_Case_Succeeds()
    {
      // arrange
      const string authToken = "777888AAABBB";
      var presenter = new LoginPresenter();

      // act
      presenter.Handle(new LoginResponse(new Token("1",authToken,0), true));

      // assert
      dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
      Assert.Equal(authToken, data.AuthToken.Value);
    }

    [Fact]
    public void Contains_Errors_When_Use_Case_Fails()
    {
      // arrange
      var presenter = new LoginPresenter();

      // act
      presenter.Handle(new LoginResponse(new[] { "Invalid username/password" }));

      // assert
      dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
      Assert.Equal((int)HttpStatusCode.Unauthorized,presenter.ContentResult.StatusCode);
      Assert.Equal("Invalid username/password", data.First.Value);
    }
  }
}
