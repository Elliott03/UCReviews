export function buildQueryParams<T extends Record<string, any>>(
  queryParams: T
) {
  return Object.entries(queryParams)
    .map(([key, value]) => `${key}=${value}`)
    .join('&');
}
