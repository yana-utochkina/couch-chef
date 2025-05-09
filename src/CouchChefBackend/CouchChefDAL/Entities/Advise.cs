namespace CouchChefDAL.Entities;

public class Advise : BaseEntity
{
    public DateOnly PublicationDate { get; set; }
    public required string ShortText { get; set; }
    public required string FullText { get; set; }
}
