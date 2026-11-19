using LittleCrumbs.Models;

namespace LittleCrumbs.Services;

public class RecipeService
{
    private readonly Supabase.Client _supabase;

    public RecipeService(Supabase.Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<RecipeModel>> GetAllRecipesAsync()
    {
        var recipeRes = await _supabase.From<RecipeModel>().Get();
        var ingredientRes = await _supabase.From<IngredientItem>().Get();
        var stepRes = await _supabase.From<BakingStepItem>().Get();
        var reviewRes = await _supabase.From<ReviewItem>().Get();

        var recipes = recipeRes.Models.OrderBy(r => r.Id).ToList();

        foreach (var recipe in recipes)
        {
            recipe.Ingredients = ingredientRes.Models.Where(i => i.RecipeId == recipe.Id).OrderBy(i => i.Id).ToList();
            recipe.Steps = stepRes.Models.Where(s => s.RecipeId == recipe.Id).OrderBy(s => s.Number).ToList();
            recipe.Reviews = reviewRes.Models.Where(rv => rv.RecipeId == recipe.Id).OrderByDescending(rv => rv.Id).ToList();
        }

        return recipes;
    }

    public async Task<RecipeModel?> GetRecipeByIdAsync(int id)
    {
        var recipeRes = await _supabase.From<RecipeModel>()
            .Where(r => r.Id == id)
            .Single();

        if (recipeRes == null) return null;

        var ingredients = await _supabase.From<IngredientItem>()
            .Where(i => i.RecipeId == id)
            .Get();
        var steps = await _supabase.From<BakingStepItem>()
            .Where(s => s.RecipeId == id)
            .Get();
        var reviews = await _supabase.From<ReviewItem>()
            .Where(rv => rv.RecipeId == id)
            .Get();

        recipeRes.Ingredients = ingredients.Models.OrderBy(i => i.Id).ToList();
        recipeRes.Steps = steps.Models.OrderBy(s => s.Number).ToList();
        recipeRes.Reviews = reviews.Models.OrderByDescending(rv => rv.Id).ToList();

        return recipeRes;
    }

    public async Task<RecipeModel> AddRecipeAsync(RecipeModel newRecipe)
    {
        // 1. Insert parent recipe and get generated Id back
        var inserted = await _supabase.From<RecipeModel>().Insert(newRecipe);
        var createdRecipe = inserted.Models.First();

        // 2. Insert child ingredients
        if (newRecipe.Ingredients.Any())
        {
            foreach (var item in newRecipe.Ingredients)
                item.RecipeId = createdRecipe.Id;

            var ingRes = await _supabase.From<IngredientItem>().Insert(newRecipe.Ingredients);
            createdRecipe.Ingredients = ingRes.Models;
        }

        // 3. Insert child baking steps
        if (newRecipe.Steps.Any())
        {
            for (int i = 0; i < newRecipe.Steps.Count; i++)
            {
                newRecipe.Steps[i].RecipeId = createdRecipe.Id;
                newRecipe.Steps[i].Number = i + 1;
            }

            var stepRes = await _supabase.From<BakingStepItem>().Insert(newRecipe.Steps);
            createdRecipe.Steps = stepRes.Models;
        }

        return createdRecipe;
    }

    public async Task UpdateRecipeAsync(RecipeModel recipe)
    {
        await _supabase.From<RecipeModel>()
            .Where(r => r.Id == recipe.Id)
            .Update(recipe);
    }

    public async Task DeleteRecipeAsync(int id)
    {
        // ON DELETE CASCADE automatically cleans up ingredients, steps, and reviews
        await _supabase.From<RecipeModel>()
            .Where(r => r.Id == id)
            .Delete();
    }

    public async Task ToggleIngredientAsync(IngredientItem ingredient)
    {
        await _supabase.From<IngredientItem>()
            .Where(i => i.Id == ingredient.Id)
            .Set(i => i.IsChecked, ingredient.IsChecked)
            .Update();
    }

    public async Task AddReviewAsync(ReviewItem review)
    {
        await _supabase.From<ReviewItem>().Insert(review);

        // Recalculate rating & review_count on parent recipe
        var allReviews = await _supabase.From<ReviewItem>()
            .Where(rv => rv.RecipeId == review.RecipeId)
            .Get();

        var count = allReviews.Models.Count;
        var avg = count > 0 ? Math.Round(allReviews.Models.Average(rv => rv.Rating), 1) : 0.0;

        await _supabase.From<RecipeModel>()
            .Where(r => r.Id == review.RecipeId)
            .Set(r => r.Rating, avg)
            .Set(r => r.ReviewCount, count)
            .Update();
    }
}