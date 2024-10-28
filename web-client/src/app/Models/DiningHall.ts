import { IReview } from './Review';

export interface IDiningHall {
  id: number;
  name: string;
  description: string;
  category: string;
  location: string;
  includedInMealPlan: string;
  nameQueryParameter: string;
  reviews: IReview[];
}

export interface IDiningHallWithRating extends IDiningHall {
  averageRating: number;
}

export type DiningHall = IDiningHall;
