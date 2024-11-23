export interface IReviewSummary {
  id: number;
  averageRating: number;
  totalReviews: number;
  summaryText: string;
}

export type ReviewSummary = IReviewSummary;
