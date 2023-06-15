using BookManagement.Shared.Models.Dtos;

namespace BookManagement.UI.Blazor.Services.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooks();
        Task<BookDto> AddBook(AddBookDto book);
        Task<BookDto> UpdateBook(int id,EditBookDto editBook);
        Task<BookDto> GetBook(int id);
    }
}
