namespace CouchChefBLL.DTOs.Get;

public class GetIngredientDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int? ImageId { get; set; }
    public GetImageDTO? GetImageDTO { get; set; }
    public string? Description { get; set; }
    public float Protein { get; set; }
    public float Fat { get; set; }
    public float Carbs { get; set; }
    public float Calories { get; set; }
}
