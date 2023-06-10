using BookManagement.Shared.Models.Dtos;
using BookManagement.UI.Blazor.Services.Contracts;
using System.Net.Http.Json;

namespace BookManagement.UI.Blazor.Services
{
    public class BookService:IBookService
    {
        private readonly HttpClient _httpClient;
        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooks()
        {
            try
            {
                var books = await _httpClient.GetFromJsonAsync<IEnumerable<BookDto>>("api/Book");
                return books;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
