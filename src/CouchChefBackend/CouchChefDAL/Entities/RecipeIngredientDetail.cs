namespace CouchChefDAL.Entities
{
    public class RecipeIngredientDetail : BaseEntity
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public bool IsTagged { get; set; }
        public int WeightInGrams { get; set; }

        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
