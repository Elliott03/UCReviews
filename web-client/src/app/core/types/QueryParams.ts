export type PageableQueryParam = {
  prev: number;
  perPage: number;
  searchTerm?: string;
};

export type QueryParams = PageableQueryParam;