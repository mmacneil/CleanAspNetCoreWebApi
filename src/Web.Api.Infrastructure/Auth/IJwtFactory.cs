using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.Api.Infrastructure.Auth
{
    public interface IJwtFactory
    {
      Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
      ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
    }
}
