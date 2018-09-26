using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Presenters
{
    public sealed class RegisterUserPresenter : IOutputPort<RegisterUserResponse>
    {
        public bool IsRegistered { get; set; }

        public void Handle(RegisterUserResponse response)
        {
            IsRegistered = response.Registered;
        }
    }
}
