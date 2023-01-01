using E_CommerceBackend.Entities;

namespace E_CommerceBackend.Repositories
{
    public interface IUserRepository
    {
        public User? GetUserByUsername(string username);
        public void CreateUser(User user);
    }
}
