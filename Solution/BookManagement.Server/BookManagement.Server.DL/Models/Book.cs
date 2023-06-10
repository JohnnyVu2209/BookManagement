

using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement.Server.DL.Models
{
    public class Book: BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }

    }
}
