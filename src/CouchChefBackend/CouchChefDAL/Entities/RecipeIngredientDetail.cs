namespace CouchChefDAL.Entities;

public class RecipeIngredientDetail : BaseEntity
{
    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
    public bool IsTagged { get; set; }
    public int WeightInGrams { get; set; }

    public required virtual Recipe Recipe { get; set; }
    public required virtual Ingredient Ingredient { get; set; }
}
