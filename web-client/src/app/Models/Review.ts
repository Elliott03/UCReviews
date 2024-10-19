import { Dorm, ILargeDorm, ISmallDorm } from './Dorm';
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

export type Reviewable = Dorm | ParkingGarage;

export class SaveReview {
  constructor(
    private reviewText: string,
    private rating: string,
    private userId: number
  ) {}
}

export class SaveDormReview extends SaveReview {
  private dormId: Number;

  constructor(
    reviewText: string,
    rating: string,
    userId: number,
    dormId: Number
  ) {
    super(reviewText, rating, userId);
    this.dormId = dormId;
  }
}

export class SaveParkingGarageReview extends SaveReview {
  private parkingGarageId: Number;
  constructor(
    reviewText: string,
    rating: string,
    userId: number,
    parkingGarageId: Number
  ) {
    super(reviewText, rating, userId);
    this.parkingGarageId = parkingGarageId;
  }
}
