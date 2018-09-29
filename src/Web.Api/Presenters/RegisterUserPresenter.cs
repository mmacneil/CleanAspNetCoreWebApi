using System.Net;
using Newtonsoft.Json;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Presenters
{
    public sealed class RegisterUserPresenter : IOutputPort<RegisterUserResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RegisterUserPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RegisterUserResponse response)
        {
            ContentResult.Content = JsonConvert.SerializeObject(new Models.Response.RegisterUserResponse(response.Success, response.Id, response.Errors));
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }
    }
}
