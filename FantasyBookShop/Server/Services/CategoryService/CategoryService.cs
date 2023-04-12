using FantasyBookShop.Server.Data;
using FantasyBookShop.Shared;
using Microsoft.EntityFrameworkCore;

namespace FantasyBookShop.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly FantasyBookShopContext _context;
        public CategoryService(FantasyBookShopContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                Data = categories
            };
        }

        public Task<ServiceResponse<Category>> GetCategory()
        {
            throw new NotImplementedException();
        }
    }
}
