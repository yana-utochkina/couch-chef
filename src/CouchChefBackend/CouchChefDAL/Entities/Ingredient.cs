namespace CouchChefDAL.Entities;

public class Ingredient : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int? ImageId { get; set; }
    public float Protein { get; set; }
    public float Fat { get; set; }
    public float Carbs { get; set; }

    public Image? Image { get; set; }
    public List<RecipeIngredientDetail>? RecipeIngredientDetails { get; set; }
}
