using Application.Repository;
using Domain;

namespace Infraestructure
{
    public class UserRepository: IUserRepository
    {
        private readonly OrganizationDbContext _context;

        public UserRepository(OrganizationDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
           return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserId == id);
            
            return user!;

        }

        public bool Create(User user)
        {
            user.UserId = 0;
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }


    }
}
