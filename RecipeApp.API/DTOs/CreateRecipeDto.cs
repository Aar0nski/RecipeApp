namespace RecipeApp.API.DTOs;

public class CreateRecipeDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CookingTime { get; set; }
    public int CategoryId { get; set; }
}
