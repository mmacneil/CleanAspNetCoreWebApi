using System.Collections.Generic;
 

namespace Web.Api.Core.Dto.GatewayResponses.Repositories
{
  public sealed class LoginResponse : BaseGatewayResposne
  {
    public Token Token { get; }
    public LoginResponse(Token token, bool success = false, IEnumerable<KeyValuePair<string, string>> errors = null) : base(success, errors)
    {
      Token = token;
    }
  }
}
