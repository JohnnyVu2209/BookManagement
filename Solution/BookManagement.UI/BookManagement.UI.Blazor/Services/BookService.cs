using BookManagement.Shared.Models.Dtos;
using BookManagement.UI.Blazor.Services.Contracts;
using System.Net.Http.Json;

namespace BookManagement.UI.Blazor.Services
{
    public class BookService:IBookService
    {
        private readonly HttpClient _httpClient;
        private PaginationParameters paginationParameters = new PaginationParameters();
        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BookDto> AddBook(AddBookDto book)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<AddBookDto>("api/Book/AddBook", book);
                if(response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<BookDto>();
                } else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} - Message:{message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<BookDto>> GetAllBooks()
        {
            try
            {
                var books = await _httpClient.GetFromJsonAsync<IEnumerable<BookDto>>($"api/Book/Paging?page={paginationParameters.PageNumber}&pageSize={paginationParameters.PageSize}&sortBy={paginationParameters.SortBy}&SortAscending=false");
                return books;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
