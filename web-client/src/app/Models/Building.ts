import { IReview } from "./Review"

export interface ILargeBuilding {
    id: number,
    name: string,
    style: string,
    cost: string,
    largeImage: string,
    averageRating: number,
    description: string,
    nameQueryParameter: string,
    reviews: IReview[]
}

export interface ISmallBuilding {
    id: number,
    name: string,
    style: string,
    cost: string,
    smallImage: string,
    nameQueryParameter: string,
    averageRating: number,
    image: string
}
