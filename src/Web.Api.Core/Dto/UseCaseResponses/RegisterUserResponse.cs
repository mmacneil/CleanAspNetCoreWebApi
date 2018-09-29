using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
    public class RegisterUserResponse : UseCaseResponseMessage 
    {
        public string Id { get; }
        public string[] Errors {  get; }

        public RegisterUserResponse(string[] errors, bool success=false, string message=null) : base(success, message)
        {
            Errors = errors;
        }

        public RegisterUserResponse(string id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}
