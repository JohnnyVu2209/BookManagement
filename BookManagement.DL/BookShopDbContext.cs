
using BookManagement.Server.DL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Server.DL
{
    public class BookShopDbContext:DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options):base(options) {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(u => u.Books)
                .HasForeignKey(b => b.AuthorId);

            base.OnModelCreating(modelBuilder);

            var author = new User { Id = 1, FirstName = "John", LastName = "Doe" };

            for (int i = 1; i <= 10; i++)
            {
                var book = new Book
                {
                    Id = i,
                    Name = $"Book {i}",
                    Description = $"Description {i}",
                    Title = $"Title {i}",
                    PublishedDate = DateTime.Now,
                    AuthorId = author.Id  // Gán giá trị cho khóa ngoại AuthorId
                };

                modelBuilder.Entity<Book>().HasData(book);
            }

            modelBuilder.Entity<User>().HasData(author);  // Thêm seed data cho User
        }

        public DbSet<Book> Books { get; set;}
        public DbSet<User> Users { get;set;}
    }
}
