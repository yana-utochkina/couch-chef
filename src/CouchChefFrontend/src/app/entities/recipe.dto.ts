import { GetImageDTO, PostImageDTO } from "./image.dto";

export interface PostRecipeDTO {
    id: number,
    cuisineId: number,
    name: string,
    prepareTime: Date,
    totalTime: Date,
    servings: number,
    directions: string,
    imageId: number,
    postImageDTO: PostImageDTO,
    categoryIds: number[],
    postRecipeIngredientDetailDTOs: PostRecipeIngredientDetailDTO[]
}

export interface PostRecipeIngredientDetailDTO {
    ingredientId: number,
    isTagged: boolean,
    weightInGrams: number
}

export interface RecipeDTO {
    id: number,
    name: string,
    prepareTime: Date,
    totalTime: Date,
    servings: number,
    directions: string,
    protein: number,
    fat: number,
    carbs: number,
    calories: number,
    getImageDTO: GetImageDTO,
    cuisine: string,
    ingredients: string[],
    categories: string[]
}