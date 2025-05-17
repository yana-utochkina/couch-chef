namespace CouchChefBLL.DTOs.Post;

public class PostRecipeDTO
{
    public int Id { get; set; }
    public int CuisineId { get; set; }
    public required string Name { get; set; }
    public TimeOnly PrepareTime { get; set; }
    public TimeOnly TotalTime { get; set; }
    public int Servings { get; set; }
    public required string Directions { get; set; }
    public int ImageId { get; set; }
    public required List<int> IngredientIds { get; set; }
    public required List<int> CategoryIds { get; set; }

    public bool IsValid()
    {
        return CategoryIds.Count() > 0
            && IngredientIds.Count() > 0
            && Servings > 0 
            && PrepareTime.IsBetween(TimeOnly.MinValue, TotalTime);
    }
}
