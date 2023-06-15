using BookManagement.Shared.Models.Dtos;
using BookManagement.UI.Blazor.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace BookManagement.UI.Blazor.Pages
{
    public class BooksBase: ComponentBase
    {
        [Inject]
        public IBookService BookService { get; set; }

        public IEnumerable<BookDto> Books { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }
        public async Task LoadData()
        {
            Books = await BookService.GetAllBooks();
        }

    }
}
