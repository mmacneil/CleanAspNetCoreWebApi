using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Api.Core.Domain;

namespace Web.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IUserRepository
    {
        Task<(bool success,string id, IEnumerable<(string code,string description)> errors)> Create(User user, string password);
    }
}
