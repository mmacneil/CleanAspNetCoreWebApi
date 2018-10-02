using System.Collections.Generic;

namespace Web.Api.Core.Dto.GatewayResponses
{
  public abstract class BaseGatewayResposne
  {
    public bool Success { get; }
    public IEnumerable<KeyValuePair<string, string>> Errors { get; }

    protected BaseGatewayResposne(bool success=false, IEnumerable<KeyValuePair<string, string>> errors=null)
    {
      Success = success;
      Errors = errors;
    }
  }
}

