using Domain;

namespace Application.Repository
{
    public interface ITokenRepository
    {
        Tokens Authenticate(Authorization users);
    }
}
