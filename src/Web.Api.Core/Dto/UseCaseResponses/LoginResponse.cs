using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
  public class LoginResponse : UseCaseResponseMessage, IUseCaseRequest
  {
    public string Token { get; }
   
    public LoginResponse(string token, bool success = false, string message = null) : base(success, message)
    {
      Token = token;
    }
  }
}
