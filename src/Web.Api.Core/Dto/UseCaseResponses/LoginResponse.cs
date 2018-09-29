using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
  public class LoginResponse : UseCaseResponseMessage
  {
    public string Token { get; }
    public string[] Errors { get; }

    public LoginResponse(string[] errors, bool success = false, string message = null) : base(success, message)
    {
      Errors = errors;
    }

    public LoginResponse(string token, bool success = false, string message = null) : base(success, message)
    {
      Token = token;
    }
  }
}
