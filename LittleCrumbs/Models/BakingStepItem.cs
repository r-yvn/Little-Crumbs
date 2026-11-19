namespace LittleCrumbs.Models;
public class BakingStepItem
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public int Number { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Instruction { get; set; } = string.Empty;
}
