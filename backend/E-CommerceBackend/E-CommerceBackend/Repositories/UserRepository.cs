using E_CommerceBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceBackend.Repositories
{
    public class UserRepository : GenericRepository<UserModel>, IUserRepository
    {
        public UserRepository(MyDbContext context)
            : base(context)
        {

        }

        /// <summary>
        /// Get a user with a specific username
        /// </summary>
        /// <param name="username">Username of the user</param>
        public UserModel? GetUserByUsername(string username)
        {
            return context.Set<UserModel>().AsNoTracking().FirstOrDefault(user => user.Username == username);
        }
    }
}
