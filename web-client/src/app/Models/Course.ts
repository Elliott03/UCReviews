import { ReviewSummary } from './ReviewSummary';

export interface ICourse {
  id: number;
  subject: string;
  number: string;
  name: string;
  description: string;
  slug: string;
  reviewSummary: ReviewSummary | null;
}

export type Course = ICourse;
