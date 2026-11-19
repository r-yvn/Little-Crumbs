using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace LittleCrumbs.Models;

[Table("ingredients")]
public class IngredientItem : BaseModel
{
    [PrimaryKey("id", false)]
    public int Id { get; set; }

    [Column("recipe_id")]
    public int RecipeId { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("amount")]
    public string Amount { get; set; } = string.Empty;

    [Column("is_checked")]
    public bool IsChecked { get; set; }
}