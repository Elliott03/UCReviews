import { ILargeBuilding } from "./Building";
import { IUser } from "./User";

export interface IReview {
    id: number,
    reviewText: string,
    starRating: number,
    timeCreated: Date,
    userId: number,
    buildingId: number,
    user: IUser,
    building: ILargeBuilding
}

export class SaveReview {
    private reviewText: string;
    private rating: string;
    private userId: number;
    private buildingId: number;
    constructor(reviewText: string, rating: string, userId: number, buildingId: number) {
        this.reviewText = reviewText;
        this.rating = rating;
        this.userId = userId;
        this.buildingId = buildingId;
    }
}