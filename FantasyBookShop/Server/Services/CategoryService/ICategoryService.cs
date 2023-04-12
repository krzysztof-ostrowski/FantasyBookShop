using FantasyBookShop.Shared;

namespace FantasyBookShop.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<Category>>> GetCategories();
        Task<ServiceResponse<Category>> GetCategory();
    }
}
