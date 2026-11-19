namespace LittleCrumbs.Models;
public class ReviewItem
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public string Author { get; set; } = string.Empty;
    public double Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string TimeAgo { get; set; } = string.Empty;
}