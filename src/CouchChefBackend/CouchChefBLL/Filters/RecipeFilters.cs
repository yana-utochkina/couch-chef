namespace CouchChefBLL.Filters;

public class RecipeFilters
{
    public int? CuisineId { get; set; }
    public List<int>? CategoryIds { get; set; }
    public List<int>? IngredientIds { get; set; }
    public int ProteinFrom { get; set; } = 0;
    public int ProteinTo { get; set; } = 100;
    public int FatFrom { get; set; } = 0;
    public int FatTo { get; set; } = 100;
    public int CarbsFrom { get; set; } = 0;
    public int CarbsTo { get; set; } = 100;
    public int CaloriesFrom { get; set; } = 0;
    public int CaloriesTo { get; set; } = 900;
}
