
export enum HTTP_METHODS {
  POST = "POST",
  PUT = "PUT",
  PATCH = "PATCH",
  GET = "GET",
  DELETE = "DELETE",
}

export abstract class BaseService {
  private readonly BASE_URL = "https://localhost:58811/api";

  protected buildUrl(endpoint: string = ""): string {
    const normalizedEndpoint = endpoint.startsWith("/") ? endpoint : "/" + endpoint;
    return this.BASE_URL + this.baseEndpoint() + (normalizedEndpoint);
  }

  protected buildQueryParams(queryParams: Record<string, any>): URLSearchParams {
    return new URLSearchParams(queryParams);
  }

  protected buildResponseError(response: Response) {
    return new Error(`Error while request: status ${response.status} | ${response.statusText}`);
  }

  protected buildRequestInit(
    method: HTTP_METHODS,
    queryParams?: Record<string, any>
  ): RequestInit {
    return {
      method: method,
      ...(queryParams || {}),
    };
  }

  protected abstract baseEndpoint(): string;
}
