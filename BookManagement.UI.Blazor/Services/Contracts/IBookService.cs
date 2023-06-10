using BookManagement.Shared.Models.Dtos;

namespace BookManagement.UI.Blazor.Services.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooks();
    }
}
