import { IReview } from "./Review"

export interface ILargeDorm {
    id: number,
    name: string,
    style: string,
    cost: string,
    averageRating: number,
    description: string,
    nameQueryParameter: string,
    reviews: IReview[]
}

export interface ISmallDorm {
    id: number,
    name: string,
    style: string,
    cost: string,
    nameQueryParameter: string,
    averageRating: number,
    image: string
}
