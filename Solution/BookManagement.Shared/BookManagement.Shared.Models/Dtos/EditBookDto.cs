
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Shared.Models.Dtos
{
    public class EditBookDto
    {
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters.")]
        [MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.Now;

        [MinLength(2, ErrorMessage = "Title must be at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
        public string Author_FirstName { get; set; }
        [MinLength(2, ErrorMessage = "Title must be at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
        public string Author_LastName { get; set; }
    }
}
