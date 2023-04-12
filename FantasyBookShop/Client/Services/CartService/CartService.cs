using Blazored.LocalStorage;

namespace FantasyBookShop.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        public CartService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public event Action OnChange;

        public async Task AddToCart(CartItem cartItem)
        {
            var cart = await GetCart();
            cart.Add(cartItem);

            await _localStorage.SetItemAsync("cart", cart);

            OnChange.Invoke();
        }

        public async Task<List<CartItem>> GetCartItems()
        {
            var cart = await GetCart();

            return cart;
        }

        private async Task<List<CartItem>> GetCart()
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }
            return cart;
        }
    }
}
