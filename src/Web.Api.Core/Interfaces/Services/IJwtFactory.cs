using System.Threading.Tasks;
using Web.Api.Core.Dto;

namespace Web.Api.Core.Interfaces.Services
{
    public interface IJwtFactory
    {
        Task<Token> GenerateEncodedToken(string id, string userName);
    }
}
