namespace CouchChefDAL.Entities;

public class Image : BaseEntity
{
    public required string Path { get; set; }
    public required string AlternativeText { get; set; }

    public Ingredient? Ingredient { get; set; }
    public Recipe? Recipe { get; set; }
}
