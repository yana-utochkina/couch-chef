import { GetImageDTO, PostImageDTO } from '@entities/image.dto';

export interface GetIngredientDTO {
    id: number,
    name: string,
    imageId: number,
    getImageDTO: GetImageDTO,
    description: string,
    protein: number,
    fat: number,
    carbs: number,
    calories: number
}

export interface PostIngredientDTO {
    id: number,
    name: string,
    postImageDTO: PostImageDTO,
    description: string,
    protein: number,
    fat: number,
    carbs: number
}