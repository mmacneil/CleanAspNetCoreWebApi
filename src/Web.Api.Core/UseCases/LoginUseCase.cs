using System.Linq;
using System.Threading.Tasks;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.Interfaces.UseCases;

namespace Web.Api.Core.UseCases
{
  public sealed class LoginUseCase : ILoginUseCase
  {
    private readonly IUserRepository _userRepository;

    public LoginUseCase(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<bool> Handle(LoginRequest message, IOutputPort<LoginResponse> outputPort)
    {
      var response = await _userRepository.Login(message.UserName, message.Password);
      outputPort.Handle(response.Success ? new LoginResponse(response.Token, true) : new LoginResponse(response.Errors.Select(e => e.Value)));
      return true;
    }
  }
}
