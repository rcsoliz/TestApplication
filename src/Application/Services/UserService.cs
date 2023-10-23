using Application.Repository;
using Application.Services.Interfaces;
using Domain;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> GetAll()
        {
            var users = _userRepository.GetAll();
            return users;
        }

        public User GetById(int id)
        {
            var user = _userRepository.GetById(id);
            return user;
        }
        public bool Create(User user)
        {
            var itemUser =  _userRepository.Create(user);
            return itemUser;
        }


    }
}
