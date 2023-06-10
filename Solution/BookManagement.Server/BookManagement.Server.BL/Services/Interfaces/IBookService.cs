
using BookManagement.Server.DL.Models;

namespace BookManagement.Server.BL.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
    }
}
