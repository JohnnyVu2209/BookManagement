
using BookManagement.Server.BL.Services.Interfaces;
using BookManagement.Server.DL.Models;
using BookManagement.Server.DL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Server.BL.Services
{
    public class BookService : IBookService
    {
        protected IRepository<Book> repository;

        public BookService(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        Task<List<Book>> IBookService.GetAllBooks()
        {
            return repository.Include(x => x.Author).ToListAsync();
        }
    }
}
