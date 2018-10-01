using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseRequests
{
  public class RegisterUserRequest : IUseCaseRequest<RegisterUserResponse>
  {
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string UserName { get; }
    public string Password { get; }

    public RegisterUserRequest(string firstName, string lastName, string email, string userName, string password)
    {
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      UserName = userName;
      Password = password;
    }
  }
}
