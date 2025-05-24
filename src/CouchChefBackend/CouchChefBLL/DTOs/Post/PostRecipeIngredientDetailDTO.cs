using CouchChefDAL.Entities;

namespace CouchChefBLL.DTOs.Post;

public class PostRecipeIngredientDetailDTO
{
    public int IngredientId { get; set; }
    public bool IsTagged { get; set; }
    public int WeightInGrams { get; set; }
}
