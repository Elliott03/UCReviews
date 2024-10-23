import { IReview } from "src/app/Models/Review";

export function getAvgRating(reviews: IReview[]): number {
  const sum = reviews.reduce((sum, review) => sum + review.starRating, 0);
  return sum / reviews.length;
}
