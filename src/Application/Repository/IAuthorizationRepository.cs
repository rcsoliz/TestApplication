using Domain;

namespace Application.Repository
{
    public interface IAuthorizationRepository
    {
        User Login(Authorization authorization);
    }
}
