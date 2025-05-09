using CouchChefDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CouchChefDAL.Data
{
    public class CouchChefDbContext : DbContext
    {
        public CouchChefDbContext(DbContextOptions<CouchChefDbContext> options)
            : base(options)
        {

        }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<RecipeIngredientDetail> RecipeIngredientDetails { get; set; }
        public DbSet<Advise> Advises { get; set; }
    }
}
