using FantasyBookShop.Server.Data;
using FantasyBookShop.Server.Services.BookService;
using FantasyBookShop.Shared;
using FantasyBookShop.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FantasyBookShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooks()
        {
            var result = await _bookService.GetBooksAsync();

            return Ok(result);
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<ServiceResponse<Book>>> GetBook(int bookId)
        {
            var result = await _bookService.GetBookAsync(bookId);
            return Ok(result);
        }
        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooksByCategory(string categoryUrl)
        {
            var result = await _bookService.GetBooksByCategory(categoryUrl);
            return Ok(result);
        }


        [HttpGet("search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<BookSearchResultDto>>> SearchBooks(string searchText, int page = 1)
        {
            var result = await _bookService.SearchBooks(searchText, page);
            return Ok(result);
        }

        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBookSearchSuggestions(string searchText)
        {
            var result = await _bookService.GetBooksSearchSuggestions(searchText);
            return Ok(result);
        }

        [HttpGet("featured")] public async Task<ActionResult<ServiceResponse<List<Book>>>> GetFeaturedBooks()
        {
            var result = await _bookService.GetFeaturedBooks();
            return Ok(result);
        }


    }
}

