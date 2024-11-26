import { IReview } from './Review';
import { ReviewSummary } from './ReviewSummary';

interface IBaseDorm {
  id: number;
  name: string;
  style: string;
  cost: string;
  reviews: IReview[];
  reviewSummary: ReviewSummary | null;
}

export interface ILargeDorm extends IBaseDorm {
  description: string;
  nameQueryParameter: string;
}

export interface ISmallDorm extends IBaseDorm {
  nameQueryParameter: string;
  image: string;
}

export type Dorm = IBaseDorm;
