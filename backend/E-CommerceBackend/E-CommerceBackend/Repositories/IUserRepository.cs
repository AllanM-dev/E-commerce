using E_CommerceBackend.Entities;

namespace E_CommerceBackend.Repositories
{
    public interface IUserRepository : IGenericRepository<UserModel>
    {
        public UserModel? GetUserByUsername(string username);
    }
}
