import { IReview } from './Review';

export interface IParkingGarage {
  id: number;
  name: string;
  slug: string;
  nameQueryParameter: string;
  latitude: number;
  longitude: number;
  campus: string;
  address: string;
  permitRequired: boolean;
  reviews: IReview[];
}

export type ParkingGarage = IParkingGarage;
