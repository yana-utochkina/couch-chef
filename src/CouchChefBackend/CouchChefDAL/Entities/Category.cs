namespace CouchChefDAL.Entities;

public class Category : BaseEntity
{
    public required string Name { get; set; }

    public List<RecipeCategory>? RecipeCategories { get; set; }
}
