import { IReview } from './Review';
import { ReviewSummary } from './ReviewSummary';

export interface IDiningHall {
  id: number;
  name: string;
  description: string;
  category: string;
  location: string;
  includedInMealPlan: string;
  nameQueryParameter: string;
  reviewSummary: ReviewSummary | null;
}

export type DiningHall = IDiningHall;
