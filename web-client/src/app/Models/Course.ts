import { ReviewSummary } from './ReviewSummary';

export interface ICourse {
  id: number;
  subject: string;
  number: string;
  name: string;
  nameQueryParameter: string;
  reviewSummary: ReviewSummary | null;
}

export type Course = ICourse;
