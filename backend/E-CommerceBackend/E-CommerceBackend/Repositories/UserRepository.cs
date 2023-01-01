using E_CommerceBackend.Entities;

namespace E_CommerceBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly LibraryContext _libraryContext;
        public UserRepository(LibraryContext context)
        {
            _libraryContext = context;
        }

        public void CreateUser(User user)
        {
            _libraryContext.Set<User>().Add(user);
            _libraryContext.SaveChanges();
        }

        public User? GetUserByUsername(string username)
        {
            return _libraryContext.Users.FirstOrDefault(user => user.Username == username);
        }
    }
}
