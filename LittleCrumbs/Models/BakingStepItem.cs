using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace LittleCrumbs.Models;

[Table("baking_steps")]
public class BakingStepItem : BaseModel
{
    [PrimaryKey("id", false)]
    public int Id { get; set; }

    [Column("recipe_id")]
    public int RecipeId { get; set; }

    [Column("step_number")]
    public int Number { get; set; }

    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [Column("instruction")]
    public string Instruction { get; set; } = string.Empty;
}