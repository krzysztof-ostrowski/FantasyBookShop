using FantasyBookShop.Shared.Dtos;

namespace FantasyBookShop.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(CartItem cartItem);
        Task<List<CartItem>> GetCartItems();
        Task<List<CartBookResponseDto>> GetCartBooks();
        Task RemoveBookFromCart(int productId, int productTypeId);
    }
}
