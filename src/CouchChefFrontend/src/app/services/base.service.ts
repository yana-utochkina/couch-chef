
export enum HTTP_METHODS {
  POST = "POST",
  PUT = "PUT",
  PATCH = "PATCH",
  GET = "GET",
  DELETE = "DELETE",
}

export abstract class BaseService {
  private readonly BASE_URL = "https://localhost:54277/api";

  protected buildUrl(endpoint?: string): string {
    return this.BASE_URL + this.baseEndpoint() + (endpoint || "");
  }

  protected buildQueryParams(queryParams: Record<string, any>): URLSearchParams {
    return new URLSearchParams(queryParams);
  }

  protected buildResponseError(response: Response) {
    return new Error(`Error while request: status ${response.status} | ${response.statusText}`);
  }

  protected buildRequestInit(
    method: HTTP_METHODS,
    otherParams?: Record<string, any>
  ): RequestInit {
    return {
      method: method,
      ...(otherParams || {}),
    };
  }

  protected abstract baseEndpoint(): string;
}
