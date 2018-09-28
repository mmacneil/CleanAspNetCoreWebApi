using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Web.Api.Core.Domain;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Infrastructure.Data.EntityFramework.Entities;

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

        public async Task<(bool success,string id, IEnumerable<(string code, string description)> errors)> Create(User user, string password)
        {
            var appUser = _mapper.Map<AppUser>(user);
            var identityResult = await _userManager.CreateAsync(appUser, password);
            return identityResult.Succeeded ? (true, appUser.Id, null) : (false,"", identityResult.Errors.Select(e => (e.Code, e.Description)));
        }
    }
}
