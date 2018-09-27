

namespace Web.Api.Core.Interfaces
{
    public interface IOutputPortx<in TUseCaseResponse>
    {
        void Handle(TUseCaseResponse response);
    }
}
