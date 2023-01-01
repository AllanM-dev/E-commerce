using E_CommerceBackend.Entities;
using E_CommerceBackend.Repositories;

namespace E_CommerceBackend.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(User user)
        {
            if(_userRepository.GetUserByUsername(user.Username) != null)
            {
                throw new Exception("User already exists");
            }
            _userRepository.CreateUser(user);
        }

        public bool UserIsAdmin(string username)
        {
            return _userRepository.GetUserByUsername(username)?.IsAdmin == true;
        }
    }
}
