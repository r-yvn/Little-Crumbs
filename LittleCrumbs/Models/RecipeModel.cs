using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace LittleCrumbs.Models;

[Table("recipes")]
public class RecipeModel : BaseModel
{
    [PrimaryKey("id", false)]
    public int Id { get; set; }

    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [Column("category")]
    public string Category { get; set; } = "Cakes";

    [Column("image_url")]
    public string ImageUrl { get; set; } = string.Empty;

    [Column("prep_time_minutes")]
    public int PrepTimeMinutes { get; set; }

    [Column("bake_time_minutes")]
    public int BakeTimeMinutes { get; set; }

    [Column("servings")]
    public int Servings { get; set; } = 1;

    [Column("rating")]
    public double Rating { get; set; }

    [Column("review_count")]
    public int ReviewCount { get; set; }

    [Column("is_featured")]
    public bool IsFeatured { get; set; }

    // Navigation lists loaded from child tables (not columns on recipes)
    public List<IngredientItem> Ingredients { get; set; } = new();
    public List<BakingStepItem> Steps { get; set; } = new();
    public List<ReviewItem> Reviews { get; set; } = new();
}