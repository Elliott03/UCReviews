import { IReview } from './Review';

export interface IParkingGarage {
  id: number;
  name: string;
  slug: string;
  latitude: number;
  longitude: number;
  campus: string;
  address: string;
  permitRequired: boolean;
  reviews: IReview[];
}

export interface IParkingGarageWithRating extends IParkingGarage {
  averageRating: number;
}

export type ParkingGarage = IParkingGarage;
