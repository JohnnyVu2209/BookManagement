
using AutoMapper;
using BookManagement.Server.BL.Services.Interfaces;
using BookManagement.Server.DL.Models;
using BookManagement.Server.DL.Repositories;
using BookManagement.Shared.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Server.BL.Services
{
    public class BookService : IBookService
    {
        protected IRepository<Book> repository;
        private readonly IMapper mapper;
        public BookService(IRepository<Book> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task<Book> AddBook(AddBookDto bookDto)
        {
            var book = repository.Add(mapper.Map<Book>(bookDto));
            repository.SaveChanges();
            return Task.FromResult(book);

        }

        Task<List<Book>> IBookService.GetAllBooks()
        {
            return repository.Include(x => x.Author).ToListAsync();
        }

        public async Task<List<Book>> GetBooks(PaginationParameters paginationParameters)
        {
            return (List<Book>)await repository.GetItems(paginationParameters);
        }

        public Task<Book> GetBook(int id)
        {
            return Task.FromResult(repository.Get(id));
        }

        public Task<Book> EditBook(int id, EditBookDto bookDto)
        {
            var currentBook = repository.Get(id);
            var edBook = mapper.Map<Book>(bookDto);
            mapper.Map(edBook, currentBook);
            repository.Update(currentBook);
            repository.SaveChanges();
            return Task.FromResult(currentBook);
        }
    }
}
