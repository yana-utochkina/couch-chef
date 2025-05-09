namespace CouchChefDAL.Entities
{
    public class RecipeCategory : BaseEntity
    {
        public int RecipeId { get; set; }
        public int CategoryId {  get; set; }

        public Recipe Recipe { get; set; }
        public Category Category { get; set; }
    }
}
