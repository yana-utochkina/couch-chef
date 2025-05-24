namespace CouchChefBLL.DTOs.Get;

public class GetRecipeDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public TimeOnly PrepareTime { get; set; }
    public TimeOnly TotalTime { get; set; }
    public int Servings { get; set; }
    public required string Directions { get; set; }
    public float Protein { get; set; }
    public float Fat { get; set; }
    public float Carbs { get; set; }
    public float Calories { get; set; }

    public required GetImageDTO GetImageDTO { get; set; }
    public required GetCuisineDTO GetCuisineDTO { get; set; }
    public required List<GetIngredientDTO> GetIngredientDTOs { get; set; }
    public required List<CategoryDTO> CategoryDTOs { get; set; }
}
