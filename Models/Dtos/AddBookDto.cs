namespace BookManagement.Shared.Models.Dtos
{
    public class AddBookDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}
