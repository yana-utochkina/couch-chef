namespace CouchChefBLL.DTOs.Post;

public class PostIngredientDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public PostImageDTO? PostImageDTO { get; set; } 
    public string? Description { get; set; }
    public float Protein { get; set; }
    public float Fat { get; set; }
    public float Carbs { get; set; }
    public bool IsValid()
    {
        return this.Carbs + this.Protein + this.Fat <= 100;
    }
    public bool IsImageNotNull()
    {
        return this.PostImageDTO is not null ? this.PostImageDTO.IsNotNull() : false;
    }
}
