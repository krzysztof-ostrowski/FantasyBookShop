using FantasyBookShop.Server.Services.CartService;
using FantasyBookShop.Shared;
using FantasyBookShop.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FantasyBookShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("books")]
        public async Task<ActionResult<ServiceResponse<List<CartBookResponseDto>>>> GetCartBooks(List<CartItem> cartBooks)
        {
            var result = await _cartService.GetCartBooks(cartBooks);
            return Ok(result);
        }

        
    }
}
