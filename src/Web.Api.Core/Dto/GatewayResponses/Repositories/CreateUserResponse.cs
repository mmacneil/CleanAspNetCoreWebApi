using System.Collections.Generic;

namespace Web.Api.Core.Dto.GatewayResponses.Repositories
{
  public sealed class CreateUserResponse : BaseGatewayResposne
  {
    public string Id { get; }
    public CreateUserResponse(string id, bool success = false, IEnumerable<KeyValuePair<string, string>> errors = null) : base(success, errors)
    {
      Id = id;
    }
  }
}
