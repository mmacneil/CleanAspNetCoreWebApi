using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseRequests
{
  public class LoginRequest : IUseCaseRequest<LoginResponse>
  {
    public string UserName { get; }
    public string Password { get; }

    public LoginRequest(string userName, string password)
    {
      UserName = userName;
      Password = password;
    }
  }
}
