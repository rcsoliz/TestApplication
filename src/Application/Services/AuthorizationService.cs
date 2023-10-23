using Application.Repository;
using Application.Services.Interfaces;
using Domain;

namespace Application.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IAuthorizationRepository _authorizationRepository;

        public AuthorizationService(IAuthorizationRepository authorizationRepository)
        {
            _authorizationRepository = authorizationRepository;
        }

        public User Login(Authorization authorization)
        {
            var item = _authorizationRepository.Login(authorization);
            return item;
        }
    }
}
