using CouchChefBLL.Configurations;
using CouchChefBLL.Interfaces;
using CouchChefBLL.Services;
using CouchChefDAL.Data;
using CouchChefWebApiPL;
using CouchChefWebApiPL.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<CorsSettings>(builder.Configuration.GetSection(SettingStrings.Cors));

var corsSettings = builder.Configuration.GetSection(SettingStrings.Cors).Get<CorsSettings>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(SettingStrings.CorsPolicy, policyBuilder =>
    {
        if (corsSettings is not null)
            policyBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins(corsSettings.Origins);
    });

});

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

builder.Services.Configure<StaticFileSettings>(builder.Configuration.GetSection(SettingStrings.StaticFilesSection));

if (builder.Configuration[SettingStrings.ImagesSetting] == "local")
{
    builder.Services.AddTransient<IStaticFileService, StaticFileService>(
        serviceProvider => new StaticFileService(
            serviceProvider.GetRequiredService<IOptions<StaticFileSettings>>(),
            serviceProvider.GetService<IWebHostEnvironment>().WebRootPath
            )
        );
}
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

app.UseCors(SettingStrings.CorsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MigrateDatabase();

app.MapControllers();

app.Run();
