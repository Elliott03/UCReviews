import { IDiningHall, DiningHall } from './DiningHall';
import { Dorm, ILargeDorm } from './Dorm';
import { IParkingGarage, ParkingGarage } from './ParkingGarage';
import { ICourse, Course } from './Course';
import { ReviewSummary } from './ReviewSummary';
import { IUser } from './User';

export interface IReview {
  id: number;
  reviewText: string;
  starRating: number;
  timeCreated: Date;
  averageVote: number;
  userId: number;
  dormId: number;
  user: IUser;
  dorm?: ILargeDorm;
  parkingGarage?: IParkingGarage;
  userVoteType: UserVoteType;
  diningHall?: IDiningHall;
  course?: ICourse;
}
export enum UserVoteType {
  UserUpvoted,
  UserDownvoted,
  UserNeutral,
}
export type Review = IReview;

export type Reviewable = Dorm | ParkingGarage | DiningHall | Course;

export class SaveReview {
  constructor(props: {
    reviewText: string;
    rating: string;
    userId: number;
    parkingGarageId?: Number;
    dormId?: Number;
    diningHallId?: Number;
    courseId?: Number;
  }) {
    Object.assign(this, props);
  }
}

export type SaveReviewResponse = {
  review: Review;
  summary: ReviewSummary;
};
