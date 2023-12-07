using Blazored.LocalStorage;
using FantasyBookShop.Shared.Dtos;
using System.Net.Http.Json;

namespace FantasyBookShop.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;

        public CartService(ILocalStorageService localStorage, HttpClient http)
        {
            _localStorage = localStorage;
            _http = http;
        }

        public event Action OnChange;

        public async Task AddToCart(CartItem cartItem)
        {
            var cart = await GetCart();
            cart.Add(cartItem);

            await _localStorage.SetItemAsync("cart", cart);

            OnChange.Invoke();
        }

        public async Task<List<CartBookResponseDto>> GetCartBooks()
        {
            var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            var response = await _http.PostAsJsonAsync("api/cart/books", cartItems);
            var cartBooks = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartBookResponseDto>>>();
            return cartBooks.Data;
        }

        public async Task<List<CartItem>> GetCartItems()
        {
            var cart = await GetCart();

            return cart;
        }

        public async Task RemoveBookFromCart(int productId, int productTypeId)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if(cart == null)
            {
                return;
            }
            var cartItem = cart.Find(b=>b.BookId == productId && b.BookTypeId == productTypeId);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
                await _localStorage.SetItemAsync("cart", cart);
                OnChange.Invoke();
            }
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
