namespace RecipeApp.API.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CookingTime { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}