namespace CouchChefDAL.Entities;

public class RecipeCategory : BaseEntity
{
    public int RecipeId { get; set; }
    public int CategoryId {  get; set; }
    public required virtual Category Category { get; set; }
}
