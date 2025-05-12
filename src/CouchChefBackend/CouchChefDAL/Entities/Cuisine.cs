namespace CouchChefDAL.Entities;

public class Cuisine : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    public virtual List<Recipe>? Recipes { get; set; }
}
