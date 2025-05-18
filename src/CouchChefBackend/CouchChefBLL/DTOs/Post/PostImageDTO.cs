using Microsoft.AspNetCore.Http;

namespace CouchChefBLL.DTOs.Post;

public class PostImageDTO
{
    public int? Id {  get; set; }
    public string? AlternativeText { get; set; } 
    public IFormFile? Image { get; set; }
    public bool IsNotNull()
    {
        return this.AlternativeText != null && this.Image != null;
    }
}
