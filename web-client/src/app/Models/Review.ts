import { ILargeDorm } from "./Dorm";
import { IParkingGarage } from "./ParkingGarage";
import { IUser } from "./User";

export interface IReview {
    id: number,
    reviewText: string,
    starRating: number,
    timeCreated: Date,
    userId: number,
    dormId: number,
    user: IUser,
    dorm?: ILargeDorm
    parkingGarage?: IParkingGarage
}

export class SaveReview {
    private reviewText: string;
    private rating: string;
    private userId: number;
    private dormId: number;
    constructor(reviewText: string, rating: string, userId: number, dormId: number) {
        this.reviewText = reviewText;
        this.rating = rating;
        this.userId = userId;
        this.dormId = dormId;
    }
}
