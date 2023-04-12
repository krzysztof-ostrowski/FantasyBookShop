using FantasyBookShop.Server.Data;
using FantasyBookShop.Shared;
using FantasyBookShop.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FantasyBookShop.Server.Services.BookService
{
    public class BookService :  IBookService
    {
        private readonly FantasyBookShopContext _context;
        public BookService(FantasyBookShopContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Book>> GetBookAsync(int bookId)
        {
            var response = new ServiceResponse<Book>();
            var book = await _context.Books.Include(b=>b.Variants)
                .ThenInclude(v=>v.BookType)
                .FirstAsync(b=>b.Id==bookId);
            if (book==null)
            {
                response.Success = false;
                response.Message = "Book does not exist";
            }
            else
            {
                response.Data = book;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Book>>> GetBooksAsync()
        {

            var response = new ServiceResponse<List<Book>>
            {
                Data = await _context.Books.Include(b=>b.Variants).ToListAsync(),
            };

            return response;
        }

        public async Task<ServiceResponse<List<Book>>> GetBooksByCategory(string categoryUrl)
        {
            
            var response = new ServiceResponse<List<Book>>
            {
                Data = await _context.Books.Where(b => b.BookCategories.Any(c=>c.Category.Url== categoryUrl)).ToListAsync(),

        };
            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetBooksSearchSuggestions(string searchText)
        {
            var books = await FindBookBySearchText(searchText);

            List<string> result = new List<string>();

            foreach (var book in books)
            {
                if (book.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(book.Title);
                }

                if (book.Description !=null)
                {
                    var punctuation = book.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = book.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText,StringComparison.OrdinalIgnoreCase)&& !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = result };
        }

        public async Task<ServiceResponse<List<Book>>> GetFeaturedBooks()
        {
            var response = new ServiceResponse<List<Book>>
            {
                Data = await _context.Books
                .Where(b => b.Featured)
                .Include(b => b.Variants)
                .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<BookSearchResultDto>> SearchBooks(string searchText, int page)
        {
            var pageResults = 2f;
            var pageCount = Math.Ceiling((await FindBookBySearchText(searchText)).Count / pageResults);
            var books =  await _context.Books.Where(b => b.Title.ToLower().Contains(searchText.ToLower()) ||
                            b.Description.ToLower().Contains(searchText.ToLower())).Include(b => b.Variants).Skip((page - 1) * (int)pageResults)
                            .Take((int)pageResults)
                            .ToListAsync();

            var response = new ServiceResponse<BookSearchResultDto>
            {
                Data = new BookSearchResultDto
                {
                    Books = books,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };

            return response;

        }

        private async Task<List<Book>> FindBookBySearchText(string searchText)
        {
            return await _context.Books.Where(b => b.Title.ToLower().Contains(searchText.ToLower()) ||
                            b.Description.ToLower().Contains(searchText.ToLower())).Include(b => b.Variants).ToListAsync();
        }
    }
}
