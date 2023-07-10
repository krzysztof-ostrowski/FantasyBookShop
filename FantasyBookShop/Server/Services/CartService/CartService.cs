using FantasyBookShop.Server.Data;
using FantasyBookShop.Shared;
using FantasyBookShop.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FantasyBookShop.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly FantasyBookShopContext _context;
        public CartService(FantasyBookShopContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<CartBookResponseDto>>> GetCartBooks(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartBookResponseDto>>
            {
                Data = new List<CartBookResponseDto>()
            };

            foreach (var cartItem in cartItems)
            {
                var book = await _context.Books.Where(b=>b.Id == cartItem.BookId)
                    .FirstOrDefaultAsync();

                if (book == null)
                {
                    continue;
                }

                var bookVariant = await _context.BookVariants
                    .Where(v => v.BookId == cartItem.BookId && v.BookTypeId == cartItem.BookTypeId)
                    .Include(v => v.BookType)
                    .FirstOrDefaultAsync();

                if (bookVariant == null)
                {
                    continue;
                }

                var cartBook = new CartBookResponseDto
                {
                    BookId = book.Id,
                    Title = book.Title,
                    ImageUrl = book.ImageUrl,
                    Price = bookVariant.Price,
                    BookType = bookVariant.BookType.Name,
                    BookTypeId = bookVariant.BookTypeId,
                };

                result.Data.Add(cartBook);
            }
            return result;
        }
    }
}
