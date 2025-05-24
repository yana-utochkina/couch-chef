export interface GetImageDTO {
    id: number,
    path: string,
    alternativeText: string
}

export interface PostImageDTO {
    id: number,
    alternativeText: string,
    image: string
}