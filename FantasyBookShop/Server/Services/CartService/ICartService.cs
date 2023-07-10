using FantasyBookShop.Shared;
using FantasyBookShop.Shared.Dtos;

namespace FantasyBookShop.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartBookResponseDto>>> GetCartBooks(List<CartItem> cartItems);
    }
}
