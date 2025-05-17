namespace CouchChefBLL.DTOs.Get;

public class GetRecipeDTO
{
    public int Id { get; set; }
    public int CuisineId { get; set; }
    public required string Name { get; set; }
    public TimeOnly PrepareTime { get; set; }
    public TimeOnly TotalTime { get; set; }
    public int Servings { get; set; }
    public required string Directions { get; set; }
    public int ImageId { get; set; }

    public required ImageDTO Image { get; set; }
    public required CuisineDTO Cuisine { get; set; } 
    public required List<IngredientDTO> Ingredients { get; set; }
    public required List<CategoryDTO> Categories { get; set;  }
}
