namespace BlazorAppName.Models;

public class RecipeModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int PrepTimeMinutes { get; set; }
    public int BakeTimeMinutes { get; set; }
    public int Servings { get; set; }
    public double Rating { get; set; }
    public int ReviewCount { get; set; }
    public bool IsFeatured { get; set; }

    public List<IngredientItem> Ingredients { get; set; } = new();
    public List<BakingStepItem> Steps { get; set; } = new();
    public List<ReviewItem> Reviews { get; set; } = new();
}

public class IngredientItem
{
    public string Name { get; set; } = string.Empty;
    public string Amount { get; set; } = string.Empty;
    public bool IsChecked { get; set; }
}

public class BakingStepItem
{
    public int Number { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Instruction { get; set; } = string.Empty;
}

public class ReviewItem
{
    public string Author { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string TimeAgo { get; set; } = string.Empty;
}