import { IReview } from './Review';

export interface ILargeDorm {
  id: number;
  name: string;
  style: string;
  cost: string;
  description: string;
  nameQueryParameter: string;
  reviews: IReview[];
}

export interface ISmallDorm {
  id: number;
  name: string;
  style: string;
  cost: string;
  nameQueryParameter: string;
  averageRating: number;
  image: string;
}

export interface ILargeDormWithRating extends ILargeDorm {
  averageRating: number;
}

export interface ISmallDormWithRating extends ISmallDorm {
  averageRating: number;
}
