using AutoMapper;
using Web.Api.Core.Domain;
using Web.Api.Infrastructure.Data.EntityFramework.Entities;

namespace Web.Api.Infrastructure.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<User, AppUser>().ConstructUsing(u => new AppUser {FirstName = u.FirstName, LastName = u.LastName, UserName = u.UserName});
        }
    }
}
