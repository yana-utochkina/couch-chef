namespace CouchChefBLL.DTOs.Get;

public class GetImageDTO
{
    public int Id { get; set; }
    public required string Path { get; set; }
    public required string AlternativeText { get; set; }
}
