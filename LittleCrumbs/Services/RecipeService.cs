using BlazorAppName.Models;

namespace BlazorAppName.Services;

public class RecipeService
{
    private readonly List<RecipeModel> _recipes = new()
    {
        new RecipeModel
        {
            Id = 1,
            Title = "Strawberry Matcha Layer Cake",
            Description = "A delightful fusion of earthy Japanese matcha sponge and sweet fresh strawberry cream filling.",
            Category = "Cakes",
            ImageUrl = "images/Strawberry Matcha Layer Cake.jpg",
            PrepTimeMinutes = 45,
            BakeTimeMinutes = 35,
            Servings = 8,
            Rating = 4.9,
            ReviewCount = 38,
            IsFeatured = true,
            Ingredients = new()
            {
                new IngredientItem { Name = "Matcha Powder (Ceremonial Grade)", Amount = "2 tbsp" },
                new IngredientItem { Name = "Cake Flour", Amount = "200g" },
                new IngredientItem { Name = "Granulated Sugar", Amount = "150g" },
                new IngredientItem { Name = "Fresh Strawberries (Sliced)", Amount = "250g" },
                new IngredientItem { Name = "Heavy Whipping Cream", Amount = "400ml" }
            },
            Steps = new()
            {
                new BakingStepItem { Number = 1, Title = "Prep & Sift", Instruction = "Preheat oven to 175°C (350°F). Line two 8-inch round cake pans with parchment paper. Sift cake flour and matcha powder together." },
                new BakingStepItem { Number = 2, Title = "Batter Creation", Instruction = "Whip eggs and sugar until pale and fluffy. Fold in sifted flour mixture gently to retain aeration." },
                new BakingStepItem { Number = 3, Title = "Bake & Cool", Instruction = "Divide batter between pans and bake for 25-30 minutes. Cool completely before frosting." }
            }
        },
        new RecipeModel
        {
            Id = 2,
            Title = "Flaky Butter Croissants",
            Description = "Master the art of lamination with golden, crispy layers of buttery pastry perfection.",
            Category = "Pastries",
            ImageUrl = "images/Flaky Butter Croissants.jpg",
            PrepTimeMinutes = 180,
            BakeTimeMinutes = 20,
            Servings = 6,
            Rating = 4.8,
            ReviewCount = 24,
            IsFeatured = true,
            Ingredients = new()
            {
                new IngredientItem { Name = "Unsalted European Butter", Amount = "250g" },
                new IngredientItem { Name = "Bread Flour", Amount = "500g" },
                new IngredientItem { Name = "Active Dry Yeast", Amount = "10g" },
                new IngredientItem { Name = "Warm Water", Amount = "140ml" }
            },
            Steps = new()
            {
                new BakingStepItem { Number = 1, Title = "Dough Preparation", Instruction = "Combine flour, yeast, sugar, salt, and water. Knead into a smooth dough and chill for 1 hour." },
                new BakingStepItem { Number = 2, Title = "Butter Lamination", Instruction = "Encase butter block in dough and perform 3 envelope folds with resting periods between folds." }
            }
        },
        new RecipeModel
        {
            Id = 3,
            Title = "Chunky Chocolate Chip Cookies",
            Description = "Crispy on the outside, gooey on the inside with pools of dark chocolate chunks.",
            Category = "Cookies",
            ImageUrl = "images/Chunky Chocolate Chip Cookies.jpg",
            PrepTimeMinutes = 25,
            BakeTimeMinutes = 12,
            Servings = 12,
            Rating = 5.0,
            ReviewCount = 56,
            IsFeatured = true,
            Ingredients = new()
            {
                new IngredientItem { Name = "70% Dark Chocolate Chunks", Amount = "200g" },
                new IngredientItem { Name = "All-Purpose Flour", Amount = "280g" },
                new IngredientItem { Name = "Brown Sugar", Amount = "150g" },
                new IngredientItem { Name = "Unsalted Butter (Melted)", Amount = "115g" }
            },
            Steps = new()
            {
                new BakingStepItem { Number = 1, Title = "Cream & Mix", Instruction = "Whisk melted butter with brown and white sugar. Fold in flour and dark chocolate chunks." },
                new BakingStepItem { Number = 2, Title = "Bake", Instruction = "Scoop onto lined baking sheets and bake at 190°C (375°F) for 10-12 minutes until edges are golden." }
            }
        }
    };

    public IEnumerable<RecipeModel> GetAllRecipes() => _recipes;

    public IEnumerable<RecipeModel> GetFeaturedRecipes() => _recipes.Where(r => r.IsFeatured);

    public RecipeModel? GetRecipeById(int id) => _recipes.FirstOrDefault(r => r.Id == id);

    public IEnumerable<RecipeModel> SearchAndFilter(string query, string category)
    {
        return _recipes.Where(r =>
            (string.Equals(category, "All", StringComparison.OrdinalIgnoreCase) || string.Equals(r.Category, category, StringComparison.OrdinalIgnoreCase)) &&
            (string.IsNullOrWhiteSpace(query) || r.Title.Contains(query, StringComparison.OrdinalIgnoreCase))
        );
    }
}