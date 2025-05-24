using CouchChefBLL.Filters;
using CouchChefDAL.Entities;

namespace CouchChefBLL.QueryBuilders;

public class RecipeQueryBuilder
{
    private IQueryable<Recipe> _query;
    public RecipeQueryBuilder(IQueryable<Recipe> query)
    {
        _query = query;
    }

    public RecipeQueryBuilder ApplyFilters(RecipeFilters filters)
    {
        if (filters.CuisineId.HasValue)
        {
            _query = _query.Where(r => r.CuisineId == filters.CuisineId.Value);
        }

        if (filters.CategoryIds?.Any() == true)
        {
            _query = _query.Where(r => r.RecipeCategories.Any(c => filters.CategoryIds.Contains(c.Id)));
        }

        if (filters.IngredientIds?.Any() == true)
        {
            _query = _query.Where(r => r.RecipeIngredientDetails.Any(i => filters.IngredientIds.Contains(i.Id)));
        }

        if (filters.ProteinFrom != 0)
        {
            _query = _query.Where(r =>
                r.RecipeIngredientDetails.Sum(i => i.Ingredient.Protein / 100) >= filters.ProteinFrom);
        }

        if (filters.ProteinTo != 100)
        {
            _query = _query.Where(r =>
                r.RecipeIngredientDetails.Sum(i => i.Ingredient.Protein / 100) <= filters.ProteinTo);
        }

        if (filters.FatFrom != 0)
        {
            _query = _query.Where(r =>
                r.RecipeIngredientDetails.Sum(i => i.Ingredient.Fat / 100) >= filters.FatFrom);
        }

        if (filters.FatTo != 180)
        {
            _query = _query.Where(r =>
                r.RecipeIngredientDetails.Sum(i => i.Ingredient.Fat / 100) <= filters.FatTo);
        }

        if (filters.CarbsFrom != 0)
        {
            _query = _query.Where(r =>
                r.RecipeIngredientDetails.Sum(i => i.Ingredient.Carbs / 100) >= filters.CarbsFrom);
        }

        if (filters.CarbsTo != 180)
        {
            _query = _query.Where(r =>
                r.RecipeIngredientDetails.Sum(i => i.Ingredient.Carbs / 100) <= filters.CarbsTo);
        }

        if (filters.CaloriesFrom != 0)
        {
            _query = _query.Where(r =>
                r.RecipeIngredientDetails.Sum(i => Recipe.CountCalories(i.Ingredient.Protein, i.Ingredient.Fat, i.Ingredient.Carbs)) >= filters.CaloriesFrom);
        }

        if (filters.CaloriesTo != 900)
        {
            _query = _query.Where(r =>
                r.RecipeIngredientDetails.Sum(i => Recipe.CountCalories(i.Ingredient.Protein, i.Ingredient.Fat, i.Ingredient.Carbs)) <= filters.CaloriesTo);
        }
        return this;
    }

    public IQueryable<Recipe> Build()
    {
        return _query;
    }
}
