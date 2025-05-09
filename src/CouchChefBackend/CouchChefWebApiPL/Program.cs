using CouchChefBLL.Interfaces;
using CouchChefBLL.Services;
using CouchChefDAL.Data;
using CouchChefWebApiPL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<CouchChefDbContext>(option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString(SettingStrings.CouchChefDbConnection));
        option.EnableSensitiveDataLogging();
    }
);

builder.Services.AddTransient<IAdviseService, AdviseService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICuisineService, CuisineService>();
builder.Services.AddTransient<IImageService, ImageService>();
builder.Services.AddTransient<IIngredientService, IngredientService>();
builder.Services.AddTransient<IRecipeService, RecipeService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
