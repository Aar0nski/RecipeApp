using NSubstitute;
using RecipeApp.API.DTOs;
using RecipeApp.API.Models;
using RecipeApp.API.Repositories;
using RecipeApp.API.Services;

namespace RecipeApp.Tests;

public class RecipeServiceTests
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly RecipeService _recipeService;

    public RecipeServiceTests()
    {
        _recipeRepository = Substitute.For<IRecipeRepository>();
        _recipeService = new RecipeService(_recipeRepository);
    }

    [Fact]
    public async Task GetAllRecipesAsync_ShouldReturnAllRecipes()
    {
        // Arrange
        var recipes = new List<Recipe>
    {
        new Recipe
        {
            Id = 1,
            Name = "Lasagne",
            Description = "Italian",
            CookingTime = 45,
            CategoryId = 1
        }
    };

        _recipeRepository.GetAllAsync()
            .Returns(recipes);

        // Act
        var result = await _recipeService.GetAllRecipesAsync();

        // Assert
        Assert.Single(result);
    }
    [Fact]
    public async Task GetRecipeByIdAsync_WhenRecipeExists_ShouldReturnRecipe()
    {
        // Arrange
        var recipe = new Recipe
        {
            Id = 1,
            Name = "Lasagne",
            Description = "Italian",
            CookingTime = 45,
            CategoryId = 1
        };

        _recipeRepository.GetByIdAsync(1)
            .Returns(recipe);

        // Act
        var result = await _recipeService.GetRecipeByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Lasagne", result.Name);
        Assert.Equal(45, result.CookingTime);
    }
    [Fact]
    public async Task GetRecipeByIdAsync_WhenRecipeDoesNotExist_ShouldReturnNull()
    {
        // Arrange
        _recipeRepository.GetByIdAsync(999)
            .Returns((Recipe?)null);

        // Act
        var result = await _recipeService.GetRecipeByIdAsync(999);

        // Assert
        Assert.Null(result);
    }
    [Fact]
    public async Task CreateRecipeAsync_ShouldCreateAndReturnRecipe()
    {
        // Arrange
        var dto = new CreateRecipeDto
        {
            Name = "Pasta",
            Description = "Creamy pasta",
            CookingTime = 25,
            CategoryId = 1
        };

        _recipeRepository.AddAsync(Arg.Any<Recipe>())
            .Returns(callInfo =>
            {
                var recipe = callInfo.Arg<Recipe>();
                recipe.Id = 1;
                return recipe;
            });

        // Act
        var result = await _recipeService.CreateRecipeAsync(dto);

        // Assert
        Assert.Equal(1, result.Id);
        Assert.Equal("Pasta", result.Name);
        Assert.Equal(25, result.CookingTime);
    }
    [Fact]
    public async Task UpdateRecipeAsync_WhenRecipeExists_ShouldReturnTrue()
    {
        // Arrange
        var recipe = new Recipe
        {
            Id = 1,
            Name = "Old Recipe",
            Description = "Old",
            CookingTime = 10,
            CategoryId = 1
        };

        var updateDto = new CreateRecipeDto
        {
            Name = "New Recipe",
            Description = "Updated",
            CookingTime = 20,
            CategoryId = 1
        };

        _recipeRepository.GetByIdAsync(1)
            .Returns(recipe);

        // Act
        var result = await _recipeService.UpdateRecipeAsync(1, updateDto);

        // Assert
        Assert.True(result);
        await _recipeRepository.Received(1).UpdateAsync(Arg.Any<Recipe>());
    }
    [Fact]
    public async Task UpdateRecipeAsync_WhenRecipeDoesNotExist_ShouldReturnFalse()
    {
        // Arrange
        var updateDto = new CreateRecipeDto
        {
            Name = "New Recipe",
            Description = "Updated",
            CookingTime = 20,
            CategoryId = 1
        };

        _recipeRepository.GetByIdAsync(999)
            .Returns((Recipe?)null);

        // Act
        var result = await _recipeService.UpdateRecipeAsync(999, updateDto);

        // Assert
        Assert.False(result);
        await _recipeRepository.DidNotReceive().UpdateAsync(Arg.Any<Recipe>());
    }
    [Fact]
    public async Task DeleteRecipeAsync_WhenRecipeExists_ShouldReturnTrue()
    {
        // Arrange
        var recipe = new Recipe
        {
            Id = 1,
            Name = "Lasagne",
            Description = "Italian",
            CookingTime = 45,
            CategoryId = 1
        };

        _recipeRepository.GetByIdAsync(1)
            .Returns(recipe);

        // Act
        var result = await _recipeService.DeleteRecipeAsync(1);

        // Assert
        Assert.True(result);
        await _recipeRepository.Received(1).DeleteAsync(recipe);
    }
}

