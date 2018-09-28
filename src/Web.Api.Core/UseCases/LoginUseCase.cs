using System;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Core.Domain;
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

    /*public async Task<bool> Handle(RegisterUserRequest message, IOutputPort<RegisterUserResponse> outputPort)
    {
      var (success, id, errors) = await _userRepository.Create(new User(message.FirstName, message.LastName, message.UserName), message.Password);
      outputPort.Handle(success ? new RegisterUserResponse(id, true) : new RegisterUserResponse(errors.Select(e => e.description).ToArray()));
      return success;
    }*/

    public Task<bool> Handle(LoginRequest message, IOutputPort<LoginResponse> outputPort)
    {
      throw new NotImplementedException();
    }
  }
}
