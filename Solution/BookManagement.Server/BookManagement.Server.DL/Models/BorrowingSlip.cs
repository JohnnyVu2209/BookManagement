
namespace BookManagement.Server.DL.Models
{
	public class BorrowingSlip:BaseEntity
	{
		public int BorrowerId { get; set; }
		public User Borrower { get; set; }
		public int BorrowedBookId { get; set; }
		public Book BorrowedBook { get; set; }
		public DateTime BorrowedDate { get; set; }
		public DateTime ReturnedDate { get; set; }
	}
}
