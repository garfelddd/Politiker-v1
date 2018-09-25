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
  apiUrl = this.apiUrl + "category";
  constructor(private http: HttpClient) {
      super();
  }

  addCategory(category: Category): Observable<any> {
    return this.http.post<Category>(this.apiUrl + 'add', category).pipe(
      catchError(this.handleError)
    );
  }

}
