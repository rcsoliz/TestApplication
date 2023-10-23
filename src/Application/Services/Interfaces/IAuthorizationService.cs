using Domain;

namespace Application.Services.Interfaces
{
    public interface IAuthorizationService
    {
        User Login(Authorization authorization);
    }
}
