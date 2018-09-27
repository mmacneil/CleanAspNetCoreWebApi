using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Infrastructure.Data.EntityFramework.Entities;

namespace Web.Api.Infrastructure.Data.EntityFramework.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<(bool success, IEnumerable<(string code, string description)> errors)> Create(string firstName, string lastName, string userName, string password)
        {
            var identityResult = await _userManager.CreateAsync(new AppUser {FirstName = firstName, LastName = lastName,UserName = userName}, password);
            return identityResult.Succeeded ? (true, null) : (false, identityResult.Errors.Select(e => (e.Code, e.Description)));
        }
    }
}
