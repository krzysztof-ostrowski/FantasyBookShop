namespace FantasyBookShop.Client.Services.BookService
{
    public interface IBookService
    {
        event Action BooksChanged;
        List<Book> Books { get; set; }
        string Message { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        string LastSearchText { get; set; }
        Task GetBooks(string? categoryUrl = null);
        Task<ServiceResponse<Book>> GetBook(int bookId);

        Task SearchBooks(string searchText, int page);
        Task<List<string>> GetBookSearchSuggestions(string searchText);


    }
}
