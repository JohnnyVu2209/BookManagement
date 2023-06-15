
using BookManagement.Server.DL.Models;
using BookManagement.Shared.Models.Dtos;

namespace BookManagement.Server.BL.Services.Interfaces
{
    public interface IBookService
    {
        Task<Book> AddBook(AddBookDto bookDto);
        Task<List<Book>> GetAllBooks();
        Task<List<Book>> GetBooks(PaginationParameters paginationParameters);
    }
}
