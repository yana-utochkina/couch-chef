namespace CouchChefDAL.Entities
{
    public class Recipe : BaseEntity
    {
        public int CuisineId { get; set; }
        public required string Name { get; set; }
        public TimeOnly PrepareTime { get; set; }
        public TimeOnly TotalTime { get; set; }
        public int Servings { get; set; }
        public required string Directions { get; set; }
        public int ImageId {  get; set; }

        public Cuisine Cuisine { get; set; }
        public Image Image { get; set; }
        public List<RecipeCategory> RecipeCategories { get; set; }
        public List<RecipeIngredientDetail> RecipeIngredientDetails { get; set; }
    }
}
