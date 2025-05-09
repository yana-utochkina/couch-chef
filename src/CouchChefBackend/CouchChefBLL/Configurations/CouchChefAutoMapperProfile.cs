using AutoMapper;
using CouchChefBLL.Models;
using CouchChefDAL.Entities;

namespace CouchChefBLL.Configurations
{
    public class CouchChefAutoMapperProfile : Profile
    {
        public CouchChefAutoMapperProfile()
        {
            CreateMap<Cuisine, CuisineModel>()
                .ReverseMap();

            CreateMap<Category, CategoryModel>()
                .ReverseMap();

            CreateMap<Ingredient, IngredientModel>()
                .ReverseMap();

            CreateMap<Recipe, RecipeModel>()
                .ReverseMap();

            CreateMap<RecipeCategory, RecipeCategoryModel>()
                .ReverseMap();

            CreateMap<RecipeIngredientDetail, RecipeIngredientDetailModel>()
                .ReverseMap();

            CreateMap<Image, ImageModel>()
                .ReverseMap();

            CreateMap<Advise, AdviseModel>()
                .ReverseMap();
        }
    }
}
