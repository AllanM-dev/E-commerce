using E_CommerceBackend.Entities;
using E_CommerceBackend.Repositories;

namespace E_CommerceBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        ///  Create a new User
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="Exception">If the username exist</exception>
        public void CreateUser(UserModel user)
        {
            if(_userRepository.GetUserByUsername(user.Username) != null)
            {
                throw new Exception("User already exists");
            }
            _userRepository.Create(user);
        }

        /// <summary>
        /// Get the role of a specific user
        /// </summary>
        /// <param name="username">Name of the User</param>
        public bool UserIsAdmin(string username)
        {
            return _userRepository.GetUserByUsername(username)?.IsAdmin == true;
        }
    }
}
