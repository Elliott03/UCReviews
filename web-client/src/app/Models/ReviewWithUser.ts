import { IReview } from './Review';
import { IReviewUser } from './User';

export interface IReviewWithUser {
  review: IReview;
  user: IReviewUser;
}

export type ReviewSummary = IReviewWithUser;
