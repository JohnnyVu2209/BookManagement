using BookManagement.Shared.Models.Dtos;
using BookManagement.UI.Blazor.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace BookManagement.UI.Blazor.Pages
{
    public class DetailEditBookBase: ComponentBase
    {
        
        [Inject]
        public IBookService BookService { get; set; }
        public BookDto BookDto { get; set; }
        public EditBookDto EditBookDto { get; set; }
        [Parameter]
        public int Id { get; set; }
        [Parameter]
        public bool IsVisible { get; set; }
        [Parameter]
        public EventCallback OnClose { get; set; }
        [Parameter]
        public EventCallback OnDetailEditBook { get; set; }
        protected override async Task OnInitializedAsync()
        {
            BookDto = await BookService.GetBook(Id);
            EditBookDto = new EditBookDto
            {
                Title = BookDto.Title,
                Description = BookDto.Description,
                PublishedDate = BookDto.PublishedDate,
                Author_FirstName = BookDto.Author.Split(' ')[0],
                Author_LastName = BookDto.Author.Split(' ')[1],
            };
        }
        protected async Task HandleValidSubmit()
        {

            var result = await BookService.UpdateBook(Id,EditBookDto);
            if (result != null)
            {
                await OnDetailEditBook.InvokeAsync();
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
