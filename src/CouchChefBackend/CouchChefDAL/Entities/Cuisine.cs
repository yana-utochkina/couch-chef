namespace CouchChefDAL.Entities
{
    public class Cuisine : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }

        public List<Recipe> Recipes { get; set; }
    }
}
