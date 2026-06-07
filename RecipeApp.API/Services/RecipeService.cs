using RecipeApp.API.DTOs;
using RecipeApp.API.Models;
using RecipeApp.API.Repositories;

namespace RecipeApp.API.Services;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;

    public RecipeService(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    public async Task<IEnumerable<RecipeDto>> GetAllRecipesAsync()
    {
        var recipes = await _recipeRepository.GetAllAsync();

        return recipes.Select(r => new RecipeDto
        {
            Id = r.Id,
            Name = r.Name,
            Description = r.Description,
            CookingTime = r.CookingTime,
            CategoryId = r.CategoryId
        });
    }

    public async Task<RecipeDto?> GetRecipeByIdAsync(int id)
    {
        var recipe = await _recipeRepository.GetByIdAsync(id);

        if (recipe == null)
            return null;

        return new RecipeDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            Description = recipe.Description,
            CookingTime = recipe.CookingTime,
            CategoryId = recipe.CategoryId
        };
    }

    public async Task<RecipeDto> CreateRecipeAsync(CreateRecipeDto createRecipeDto)
    {
        var recipe = new Recipe
        {
            Name = createRecipeDto.Name,
            Description = createRecipeDto.Description,
            CookingTime = createRecipeDto.CookingTime,
            CategoryId = createRecipeDto.CategoryId
        };

        await _recipeRepository.AddAsync(recipe);

        return new RecipeDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            Description = recipe.Description,
            CookingTime = recipe.CookingTime,
            CategoryId = recipe.CategoryId
        };
    }

    public async Task<bool> UpdateRecipeAsync(int id, CreateRecipeDto updateRecipeDto)
    {
        var recipe = await _recipeRepository.GetByIdAsync(id);

        if (recipe == null)
            return false;

        recipe.Name = updateRecipeDto.Name;
        recipe.Description = updateRecipeDto.Description;
        recipe.CookingTime = updateRecipeDto.CookingTime;
        recipe.CategoryId = updateRecipeDto.CategoryId;

        await _recipeRepository.UpdateAsync(recipe);

        return true;
    }

    public async Task<bool> DeleteRecipeAsync(int id)
    {
        var recipe = await _recipeRepository.GetByIdAsync(id);

        if (recipe == null)
            return false;

        await _recipeRepository.DeleteAsync(recipe);

        return true;
    }
}