export type QueryParams = ReviewableQueryParam & PageableQueryParam;

export type ReviewableQueryParam = {
  includeReviews: boolean;
};

export type PageableQueryParam = {
  prev: Number;
  perPage: Number;
};
