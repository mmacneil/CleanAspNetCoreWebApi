using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto;
using Web.Api.Core.Dto.GatewayResponses.Repositories;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Infrastructure.Data.Entities;


namespace Web.Api.Infrastructure.Data.EntityFramework.Repositories
{
  internal sealed class UserRepository : IUserRepository
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public UserRepository(UserManager<AppUser> userManager, IMapper mapper)
    {
      _userManager = userManager;
      _mapper = mapper;
    }

    public async Task<CreateUserResponse> Create(User user, string password)
    {
      var appUser = _mapper.Map<AppUser>(user);
      var identityResult = await _userManager.CreateAsync(appUser, password);
      return new CreateUserResponse(appUser.Id,identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
    }

      public async Task<User> FindByName(string userName)
      {
          return _mapper.Map<User>(await _userManager.FindByNameAsync(userName));
      }

      public async Task<bool> CheckPassword(User user, string password)
      {
         return await _userManager.CheckPasswordAsync(_mapper.Map<AppUser>(user), password);
      }
  }
}
