using RecipeApp.API.Data;
using RecipeApp.API.Models;

namespace RecipeApp.API.Repositories;

public class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
{
    public RecipeRepository(AppDbContext context) : base(context)
    {
    }
}