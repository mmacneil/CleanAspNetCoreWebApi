using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto;

namespace Web.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IUserRepository
    {
        Task<(bool success,string id, IEnumerable<(string code,string description)> errors)> Create(User user, string password);
        Task<(bool success, Token token, IEnumerable<(string code, string description)> errors)> Login(string userName, string password);
    }
}
