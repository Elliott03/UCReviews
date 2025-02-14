// /src/app/types/query-params.ts

// Define PageableQueryParam with searchTerm as an optional field
export type PageableQueryParam = {
  prev: number;
  perPage: number;
  searchTerm?: string; // Add searchTerm as an optional field
};

// QueryParams now references the updated PageableQueryParam
export type QueryParams = PageableQueryParam;