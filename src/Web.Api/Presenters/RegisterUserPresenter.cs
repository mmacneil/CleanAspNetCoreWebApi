using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Presenters
{
    public sealed class RegisterUserPresenter : IOutputPort<RegisterUserResponse>
    {
        public Models.Response.RegisterUserResponse RegisterUserResponse { get; set; }

        public void Handle(RegisterUserResponse response)
        {
            RegisterUserResponse = new Models.Response.RegisterUserResponse(response.Success, response.Id,response.Errors);
        }
    }
}
