import { IReview } from './Review';

interface IBaseDorm {
  id: number;
  name: string;
  style: string;
  cost: string;
  reviews: IReview[];
}

export interface ILargeDorm extends IBaseDorm {
  description: string;
  nameQueryParameter: string;
}

export interface ISmallDorm extends IBaseDorm {
  nameQueryParameter: string;
  image: string;
}

export interface ILargeDormWithRating extends ILargeDorm {
  averageRating: number;
}

export interface ISmallDormWithRating extends ISmallDorm {
  averageRating: number;
}

export type Dorm = IBaseDorm;
