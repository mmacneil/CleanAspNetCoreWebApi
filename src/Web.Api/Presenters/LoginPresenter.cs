using System.Net;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Presenters
{
  public sealed class LoginPresenter : IOutputPort<LoginResponse>
  {
    public JsonContentResult ContentResult { get; }

    public LoginPresenter()
    {
      ContentResult = new JsonContentResult();
    }

    public void Handle(LoginResponse response)
    {
      ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
      if (response.Success)
      {
        ContentResult.Content = response.Token;
      }
    }
  }
}
