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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> Get()
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

        
    }
}
