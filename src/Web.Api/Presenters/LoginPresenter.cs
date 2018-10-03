using System.Net;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Serialization;

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
      ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(response.Token) : JsonSerializer.SerializeObject(response.Errors);
    }
  }
}
