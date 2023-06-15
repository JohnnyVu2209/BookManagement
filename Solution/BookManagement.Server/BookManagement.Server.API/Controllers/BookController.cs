using AutoMapper;
using BookManagement.Server.BL.Services.Interfaces;
using BookManagement.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookManagement.Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            _mapper = mapper;
        }
        [HttpGet("GetBooks")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {

            try
            {
                var books = await bookService.GetAllBooks();
                if(books == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<List<BookDto>>(books));
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
        [HttpGet("Paging")]
        public async Task<ActionResult<IEnumerable<BookDto>>> Paging([FromQuery] PaginationParameters paginationParameters)
        {

            try
            {
                var books = await bookService.GetBooks(paginationParameters);
                if (books == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<List<BookDto>>(books));
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpPost("AddBook")]
        public async Task<ActionResult<BookDto>> AddBook([FromBody]AddBookDto bookDto)
        {
            try
            {
                var book = await bookService.AddBook(bookDto);
                return Ok(_mapper.Map<BookDto>(book));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data to database");
            }
        } 


    }
}
