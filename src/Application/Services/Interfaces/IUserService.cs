using Domain;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        bool Create(User user);
    }
}
