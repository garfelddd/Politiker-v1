import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { BaseService } from './base.service';
import { Category } from '../models/category';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CategoryService extends BaseService {
  protected apiUrl = this.apiUrl + "category/";
  constructor(private http: HttpClient) {
      super();
  }

  getCategory(id: number): Observable<Category> {
    return this.http.get<Category>(this.apiUrl + "getbyid/" + id).pipe(
      catchError(this.handleError)
    );
  }

  addCategory(category: Category): Observable<any> {
    return this.http.post<Category>(this.apiUrl + 'add', category).pipe(
      catchError(this.handleError)
    );
  }

  listCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl + "list").pipe(
      catchError(this.handleError)
    );
  }

  removeCategory(id: number): Observable<any> {
    return this.http.delete<any>(this.apiUrl + "removebyid/" + id).pipe(
      catchError(this.handleError)
    );
  }

  updateCategory(category: Category) {
    return this.http.put<Category>(this.apiUrl + "update", category).pipe(
      catchError(this.handleError)
    );
  }

}
