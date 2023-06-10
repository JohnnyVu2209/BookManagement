
using BookManagement.Server.DL.Models;

namespace BookManagement.Server.DL.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(BookShopDbContext context) : base(context)
        {
        }
    }
}
