using CouchChefDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CouchChefDAL.Data;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cuisine>(CuisineConfigure);
        modelBuilder.Entity<Category>(CategoryConfigure);
        modelBuilder.Entity<Image>(ImageConfigure);
        modelBuilder.Entity<Ingredient>(IngredientConfigure);
        modelBuilder.Entity<Recipe>(RecipeConfigure);
        modelBuilder.Entity<RecipeCategory>(RecipeCategoryConfigure);
        modelBuilder.Entity<RecipeIngredientDetail>(RecipeIngredientDetailConfigure);
        modelBuilder.Entity<Advise>(AdviseConfigure);
    }

    private void CuisineConfigure(EntityTypeBuilder<Cuisine> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(255);
        builder.Property(x => x.Description)
            .HasColumnType("text");
    }

    private void CategoryConfigure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(255);
    }

    private void ImageConfigure(EntityTypeBuilder<Image> builder)
    {
    }

    private void IngredientConfigure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(255);
        builder.Property(x => x.Description)
            .HasColumnType("text");
        builder.HasOne(ingredient => ingredient.Image)
            .WithOne(image => image.Ingredient)
            .HasForeignKey<Ingredient>(ingredient => ingredient.ImageId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void RecipeConfigure(EntityTypeBuilder<Recipe> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(255);
        builder.Property(x => x.Directions)
            .HasColumnType("text");
        builder.HasOne(recipe => recipe.Image)
            .WithOne(image => image.Recipe)
            .HasForeignKey<Recipe>(recipe => recipe.ImageId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(recipe => recipe.Cuisine)
            .WithMany(cuisine => cuisine.Recipes)
            .HasForeignKey(recipe => recipe.CuisineId);
    }

    private void RecipeCategoryConfigure(EntityTypeBuilder<RecipeCategory> builder)
    {
        builder.HasOne(rc => rc.Category)
            .WithMany(category => category.RecipeCategories)
            .HasForeignKey(rc => rc.CategoryId);
        builder.HasOne(rc => rc.Recipe)
            .WithMany(recipe => recipe.RecipeCategories)
            .HasForeignKey(rc => rc.RecipeId);
    }

    private void RecipeIngredientDetailConfigure(EntityTypeBuilder<RecipeIngredientDetail> builder)
    {
        builder.HasOne(rid => rid.Recipe)
            .WithMany(recipe => recipe.RecipeIngredientDetails)
            .HasForeignKey(rid => rid.RecipeId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(rid => rid.Ingredient)
            .WithMany(ingredient => ingredient.RecipeIngredientDetails)
            .HasForeignKey(rid => rid.IngredientId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    private void AdviseConfigure(EntityTypeBuilder<Advise> builder)
    {
        builder.Property(x => x.PublicationDate)
            .HasDefaultValueSql("CAST(GETDATE() AS date)");
        builder.Property(x => x.ShortText)
            .HasMaxLength(255);
        builder.Property(x => x.FullText)
            .HasColumnType("text");
    }
}
