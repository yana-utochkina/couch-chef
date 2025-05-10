namespace CouchChefBLL.DTOs;

public class ImageDTO
{
    public int Id { get; set; }
    public required string Path { get; set; }
    public required string AlternativeText { get; set; }
}
