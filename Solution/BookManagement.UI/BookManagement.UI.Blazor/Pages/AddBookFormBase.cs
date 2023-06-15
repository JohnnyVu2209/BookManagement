using BookManagement.Shared.Models.Dtos;
using BookManagement.UI.Blazor.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace BookManagement.UI.Blazor.Pages
{
    public class AddBookFormBase: ComponentBase
    {
        [Inject]
        public IBookService BookService { get; set; }
        [Parameter]
        public bool IsVisible { get; set; }
        [Parameter]
        public EventCallback OnClose { get; set; }
        [Parameter]
        public EventCallback OnBookAdded { get; set; }
        public AddBookDto BookDto { get; set; } = new AddBookDto();
        protected async Task HandleValidSubmit()
        {

            var result = await BookService.AddBook(BookDto);
            if (result != null)
            {
                await OnBookAdded.InvokeAsync();
                CloseModal();
            }
        }
        private void CloseModal()
        {
            IsVisible = false;
            OnClose.InvokeAsync();
        }
    }
}
