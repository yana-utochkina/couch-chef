namespace CouchChefBLL.DTOs.Post;

public class PostRecipeDTO
{
    public int Id { get; set; }
    public int CuisineId { get; set; }
    public required string Name { get; set; }
    public TimeOnly PrepareTime { get; set; }
    public TimeOnly TotalTime { get; set; }
    public int Servings { get; set; }
    public required string Directions { get; set; }
    public int ImageId { get; set; }
    public required PostImageDTO PostImageDTO { get; set; }
    public required List<int> CategoryIds { get; set; }
    public required List<PostRecipeIngredientDetailDTO> RecipeIngredientDetailDTOs { get; set; }

    public bool IsValid()
    {
        return Servings > 0
            && PrepareTime.IsBetween(TimeOnly.MinValue, TotalTime);
    }

    public bool IsImageNotNull()
    {
        return this.PostImageDTO is not null ? this.PostImageDTO.IsNotNull() : false;
    }
}
