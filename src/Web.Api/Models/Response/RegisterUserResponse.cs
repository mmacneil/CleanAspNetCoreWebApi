
namespace Web.Api.Models.Response
{
    public class RegisterUserResponse
    {
        public bool Succeeded { get; }
        public string Id { get; set; }
        public string[] Errors { get; set; }

        public RegisterUserResponse(bool succeeded, string id = null, string[] errors = null)
        {
            Succeeded = succeeded;
            Id = id;
            Errors = errors;
        }
    }
}
