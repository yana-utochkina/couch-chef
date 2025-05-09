namespace CouchChefDAL.Entities;

public class RecipeIngredientDetail : BaseEntity
{
    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
    public bool IsTagged { get; set; }
    public int WeightInGrams { get; set; }

    public required Recipe Recipe { get; set; }
    public required Ingredient Ingredient { get; set; }
}
