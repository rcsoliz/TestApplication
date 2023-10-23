using Application.Repository;
using Domain;

namespace Infraestructure
{
    public class AuthorizationRepository: IAuthorizationRepository
    {
        private readonly OrganizationDbContext _context;

        public AuthorizationRepository(OrganizationDbContext context)
        {
            _context = context;
        }
        public User Login(Authorization authorization)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserEmail == authorization.UserEmail 
                && x.UserPassword == authorization.UserPassword);
                
            return user;
        }
    }
}
