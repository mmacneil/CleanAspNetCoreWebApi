using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
    public class RegisterUserResponse : UseCaseResponseMessage, IUseCaseRequest
    {
        public bool Registered { get; }
        public RegisterUserResponse(bool registered, bool success=false, string message=null) : base(success, message)
        {
            Registered = registered;
        }
    }
}
