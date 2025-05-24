import { Injectable } from '@angular/core';
import { BaseService, HTTP_METHODS } from '@services/base.service';
import { CategoryDTO } from '@entities/category.dto';
import { catchError, EMPTY, from, Observable, of, switchMap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService extends BaseService {

  public getCategoriesList(): Observable<CategoryDTO[]> {
    let response: Observable<Response>;

    try {
      response = from(fetch(this.buildUrl(), this.buildRequestInit(HTTP_METHODS.GET)));
    } catch (err) {
      console.error(err);
      return of([]);
    }

    const data = response.pipe(
      switchMap(
        (response) => {
          if (!response.ok)
            throw this.buildResponseError(response);
          return response.json() as Promise<CategoryDTO[]>;
        }
      ),
      catchError(
        (err) => {
          console.error(err);
          return [];
        }
      )
    )

    return data;
  }

  public getCategory(id: number): Observable<CategoryDTO> {
    let response: Observable<Response>;

    try {
      response = from(fetch(this.buildUrl(id.toString()), this.buildRequestInit(HTTP_METHODS.GET)));
    } catch (err) {
      console.error(err);
      return EMPTY;
    }

    const data = response.pipe(
      switchMap(
        (response) => {
          if (!response.ok)
            throw this.buildResponseError(response);
          return response.json() as Promise<CategoryDTO>;
        }
      )
    )

    return data;
  }

  protected baseEndpoint(): string {
    return "/categories";
  }
}
