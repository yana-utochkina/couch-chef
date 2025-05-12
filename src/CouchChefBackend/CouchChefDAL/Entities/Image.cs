namespace CouchChefDAL.Entities;

public class Image : BaseEntity
{
    public required string Path { get; set; }
    public required string AlternativeText { get; set; }

    public virtual Ingredient? Ingredient { get; set; }
    public virtual Recipe? Recipe { get; set; }
}
