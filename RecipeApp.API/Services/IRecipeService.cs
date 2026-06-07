using RecipeApp.API.DTOs;

namespace RecipeApp.API.Services;

public interface IRecipeService
{
    Task<IEnumerable<RecipeDto>> GetAllRecipesAsync();
    Task<RecipeDto?> GetRecipeByIdAsync(int id);
    Task<RecipeDto> CreateRecipeAsync(CreateRecipeDto createRecipeDto);
    Task<bool> UpdateRecipeAsync(int id, CreateRecipeDto updateRecipeDto);
    Task<bool> DeleteRecipeAsync(int id);
}
