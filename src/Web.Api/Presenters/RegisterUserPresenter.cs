using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;

namespace Web.Api.Presenters
{
    public sealed class RegisterUserPresenter : IOutputPort<RegisterUserResponse>
    {
        public ContentResult ContentResult { get; }

        public RegisterUserPresenter()
        {
            ContentResult = new ContentResult();
        }

        public void Handle(RegisterUserResponse response)
        {
            ContentResult.Content = JsonConvert.SerializeObject(new Models.Response.RegisterUserResponse(response.Success, response.Id, response.Errors));
            ContentResult.ContentType = "application/json";
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }
    }
}
