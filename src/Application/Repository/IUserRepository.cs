using Domain;

namespace Application.Repository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        bool Create(User user);
    }
}
