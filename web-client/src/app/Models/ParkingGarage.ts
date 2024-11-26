import { ReviewSummary } from './ReviewSummary';

export interface IParkingGarage {
  id: number;
  name: string;
  slug: string;
  latitude: number;
  longitude: number;
  campus: string;
  address: string;
  permitRequired: boolean;
  reviewSummary: ReviewSummary | null;
}

export type ParkingGarage = IParkingGarage;
