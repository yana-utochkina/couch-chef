namespace CouchChefDAL.Entities;

public class Category : BaseEntity
{
    public required string Name { get; set; }

    public virtual List<RecipeCategory>? RecipeCategories { get; set; }
}
