using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace LittleCrumbs.Models;

[Table("reviews")]
public class ReviewItem : BaseModel
{
    [PrimaryKey("id", false)]
    public int Id { get; set; }

    [Column("recipe_id")]
    public int RecipeId { get; set; }

    [Column("author")]
    public string Author { get; set; } = string.Empty;

    [Column("rating")]
    public double Rating { get; set; }

    [Column("comment")]
    public string Comment { get; set; } = string.Empty;

    [Column("time_ago")]
    public string TimeAgo { get; set; } = "just now";
}