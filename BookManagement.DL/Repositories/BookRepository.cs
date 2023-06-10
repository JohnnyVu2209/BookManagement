

using BookManagement.Server.DL.Models;
using BookManagement.Server.DL.Repositories;

namespace BookManagement.Server.DL.Repository
{
    public class BookRepository : GenericRepository<Book>
    {
        public BookRepository(BookShopDbContext context) : base(context)
        {
        }
    }
}
