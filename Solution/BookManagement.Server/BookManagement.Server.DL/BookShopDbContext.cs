
using BookManagement.Server.DL.Models;
using BookManagement.Server.DL.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BookManagement.Server.DL
{
	public class BookShopDbContext : DbContext
	{
		public BookShopDbContext(DbContextOptions<BookShopDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>()
			.OwnsOne(b => b.Author);

			modelBuilder.Entity<User>()
				.HasOne(u => u.Role)
				.WithMany(r => r.Users)
				.HasForeignKey(u => u.RoleId);

			modelBuilder.Entity<BorrowingSlip>()
				.HasOne(bs => bs.Borrower)
				.WithMany(u => u.BorrowingSlips)
				.HasForeignKey(bs => bs.BorrowerId);

			modelBuilder.Entity<BorrowingSlip>()
				.HasOne(bs => bs.BorrowedBook)
				.WithMany(b => b.BorrowingSlips)
				.HasForeignKey(bs => bs.BorrowedBookId);
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<BorrowingSlip> BorrowingSlips { get; set; }
		public DbSet<Role> Roles { get; set; }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entities = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entities)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;
					entry.Entity.UpdatedAt = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.Now;
                }
            }
        }

    }
}
