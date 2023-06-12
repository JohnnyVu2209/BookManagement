using BookManagement.Server.DL.ValueObjects;

namespace BookManagement.Server.DL.Models
{
    public class Book: BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public Author Author { get; set; }
        public int Status { get; set; } 
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnedDate { get; set; }
        public List<BorrowingSlip> BorrowingSlips { get; set; }

    }
}
