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

            var sameItem = cart.Find(x=>x.BookId == cartItem.BookId &&
            x.BookTypeId == cartItem.BookTypeId);

            if (sameItem == null) 
            {
                cart.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }

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

        public async Task UpdateQuantity(CartBookResponseDto book)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if(cart == null)
            {
                return;
            }
            var cartItem = cart.Find(x => x.BookId == book.BookId &&
            x.BookTypeId == book.BookTypeId);
            if (cartItem != null)
            {
                cartItem.Quantity = book.Quantity;
                await _localStorage.SetItemAsync("cart", cart);
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
