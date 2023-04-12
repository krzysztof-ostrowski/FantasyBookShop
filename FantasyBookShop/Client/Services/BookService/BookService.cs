using FantasyBookShop.Shared.Dtos;
using System.Net.Http.Json;

namespace FantasyBookShop.Client.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly HttpClient _http;

        

        public BookService(HttpClient http)
        {
            _http = http;
        }
        public List<Book> Books { get; set; } = new List<Book>();
        public string Message { get; set; } = "Loading books. . .";

        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;

        public event Action BooksChanged;

        public async Task GetBooks(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Book>>>("api/Book/featured"):
                await _http.GetFromJsonAsync<ServiceResponse<List<Book>>>($"api/Book/category/{categoryUrl}");

            if (result != null && result.Data != null)
            {
                Books = result.Data;
            }

            CurrentPage = 1;
            PageCount= 0;
            if (Books.Count==0)
            {
                Message = "No books found.";
            }

            BooksChanged.Invoke();
        }
        public async Task <ServiceResponse<Book>> GetBook(int bookId)
        {
            var result =
                await _http.GetFromJsonAsync<ServiceResponse<Book>>($"api/Book/{bookId}");
            return result;
        }

        public async Task SearchBooks(string searchText, int page)
        {
            LastSearchText= searchText;
            var result = await _http.GetFromJsonAsync<ServiceResponse<BookSearchResultDto>>($"api/Book/search/{searchText}/{page}");
            if (result != null && result.Data != null)
            {
                Books = result.Data.Books;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }
            if (Books.Count == 0)
            {
                Message = "No books found";
            }
            BooksChanged?.Invoke();
        }

        public async Task<List<string>> GetBookSearchSuggestions(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/Book/searchsuggestions/{searchText}");

            return result.Data;
        }
    }
}
