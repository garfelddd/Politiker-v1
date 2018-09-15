import { Observable } from 'rxjs';
import { throwError } from 'rxjs';
import { environment } from '../../environments/environment';
import { Response } from 'selenium-webdriver/http';
import { HttpErrorResponse } from '@angular/common/http';

export abstract class BaseService {
  protected readonly apiUrl = environment.apiUrl;
  constructor() { }

  protected handleError(error: HttpErrorResponse) {
    var modelStateErrors: any[] = [];
    var errors: any[] = error.error;
    if (!error.type) {
      for (var key of errors) {

        if (key)
          modelStateErrors.push(key);
      }
    }
    return throwError(modelStateErrors || 'Problem z serwerem');
  }
}
