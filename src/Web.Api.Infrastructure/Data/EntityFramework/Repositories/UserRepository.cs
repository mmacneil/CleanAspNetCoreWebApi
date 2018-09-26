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

        public async Task Create()
        {
           var identityResult = await _userManager.CreateAsync(new AppUser() {FirstName = "Mark", LastName = "Macneil",UserName = "mark123"},"password123");
        }
    }
}
