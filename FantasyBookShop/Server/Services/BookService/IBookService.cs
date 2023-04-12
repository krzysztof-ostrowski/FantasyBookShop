using FantasyBookShop.Shared;
using FantasyBookShop.Shared.Dtos;

namespace FantasyBookShop.Server.Services.BookService
{
    public interface IBookService
    {
        Task<ServiceResponse<List<Book>>> GetBooksAsync();
        Task<ServiceResponse<Book>> GetBookAsync(int bookId);
        Task<ServiceResponse<List<Book>>> GetBooksByCategory(string categoryUrl);
        Task<ServiceResponse<BookSearchResultDto>> SearchBooks(string searchText, int page);
        Task<ServiceResponse<List<string>>> GetBooksSearchSuggestions(string searchText);
        Task<ServiceResponse<List<Book>>> GetFeaturedBooks();
    }
}
