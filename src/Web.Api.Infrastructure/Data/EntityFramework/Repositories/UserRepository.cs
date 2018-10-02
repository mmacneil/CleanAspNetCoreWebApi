using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto;
using Web.Api.Core.Dto.GatewayResponses.Repositories;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Infrastructure.Auth;
using Web.Api.Infrastructure.Data.EntityFramework.Entities;


namespace Web.Api.Infrastructure.Data.EntityFramework.Repositories
{
  internal sealed class UserRepository : IUserRepository
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IJwtFactory _jwtFactory;
    private readonly JwtIssuerOptions _jwtOptions;

    public UserRepository(UserManager<AppUser> userManager, IMapper mapper, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
    {
      _userManager = userManager;
      _mapper = mapper;
      _jwtFactory = jwtFactory;
      _jwtOptions = jwtOptions.Value;
    }

    public async Task<CreateUserResponse> Create(User user, string password)
    {
      var appUser = _mapper.Map<AppUser>(user);
      var identityResult = await _userManager.CreateAsync(appUser, password);
      return new CreateUserResponse(appUser.Id,identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new KeyValuePair<string, string>(e.Code, e.Description)));
    }

    public async Task<LoginResponse> Login(string userName, string password)
    {
      var identity = await GetClaimsIdentity(userName, password);

      if (identity == null)
      {
        return new LoginResponse(null,false, new[] {new KeyValuePair<string, string>("login_failure", "Invalid username or password.")});
      }

      return new LoginResponse(new Token(identity.Claims.Single(c => c.Type == "id").Value, await _jwtFactory.GenerateEncodedToken(userName, identity), (int)_jwtOptions.ValidFor.TotalSeconds), true);
    }

    private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
    {
      if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
        return await Task.FromResult<ClaimsIdentity>(null);

      // get the user to verifty
      var userToVerify = await _userManager.FindByNameAsync(userName);

      if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

      // check the credentials
      if (await _userManager.CheckPasswordAsync(userToVerify, password))
      {
        return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id));
      }

      // Credentials are invalid, or account doesn't exist
      return await Task.FromResult<ClaimsIdentity>(null);
    }
  }
}
