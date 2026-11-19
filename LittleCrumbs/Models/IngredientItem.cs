namespace LittleCrumbs.Models;
public class IngredientItem
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Amount { get; set; } = string.Empty;
    public bool IsChecked { get; set; }
}