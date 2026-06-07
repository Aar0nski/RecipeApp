using RecipeApp.API.Data;
using RecipeApp.API.Models;

namespace RecipeApp.API.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}