using E_CommerceBackend.Entities;

namespace E_CommerceBackend.Services
{
    public interface IUserService
    {
        public bool UserIsAdmin(string username);

        public void CreateUser(UserModel user);
    }
}
