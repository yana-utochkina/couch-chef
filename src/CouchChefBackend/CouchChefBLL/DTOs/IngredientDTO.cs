namespace CouchChefBLL.DTOs;

public class IngredientDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int? ImageId { get; set; }
    public ImageDTO? ImageDTO { get; set; }
    public string? Description { get; set; }
    public float Protein { get; set; }
    public float Fat { get; set; }
    public float Carbs { get; set; }
    public float? Calories { get; set; }

    public bool IsValid()
    {
        return this.Carbs + this.Protein + this.Fat <= 100;
    }
}
