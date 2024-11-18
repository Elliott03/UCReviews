import { DiningHall } from './DiningHall';
import { Dorm, ILargeDorm } from './Dorm';
import { IParkingGarage, ParkingGarage } from './ParkingGarage';
import { IUser } from './User';

export interface IReview {
  id: number;
  reviewText: string;
  starRating: number;
  timeCreated: Date;
  userId: number;
  dormId: number;
  user: IUser;
  dorm?: ILargeDorm;
  parkingGarage?: IParkingGarage;
}

export type Reviewable = Dorm | ParkingGarage | DiningHall;

export class SaveReview {
  constructor(props: {
    reviewText: string;
    rating: string;
    userId: number;
    parkingGarageId?: Number;
    dormId?: Number;
    diningHallId?: Number;
  }) {
    Object.assign(this, props);
  }
}

export type SaveReviewResponse = {
  review: IReview;
  reviewable?: Reviewable;
  averageRating?: number;
};
