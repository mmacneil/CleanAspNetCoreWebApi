using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IUserRepositoryx
    {
        Task<(bool success, IEnumerable<(string code,string description)>)> Create(string firstName, string lastName, string userName, string password);
    }
}
