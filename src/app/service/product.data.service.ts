import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
//Grab everything with import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { ConfigService } from '../utils/config.service';
import { IProduct } from '../shared/interfaces';

@Injectable()
export class ProductDataService {
  _baseUrl: string = '';
  constructor(private http: Http,
    private configService: ConfigService) {
    this._baseUrl = configService.getApiURI();
  }
  
  getUsers(): Observable<IProduct[]> {
    return this.http.get(this._baseUrl + 'product')
      .map((res: Response) => {
        return res.json();
      })
      .catch(this.handleError);
  }

  private handleError(error: any) {
    var applicationError = error.headers.get('Application-Error');
    var serverError = error.json();
    var modelStateErrors: string = '';

    if (!serverError.type) {
      console.log(serverError);
      for (var key in serverError) {
        if (serverError[key])
          modelStateErrors += serverError[key] + '\n';
      }
    }

    modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;

    return Observable.throw(applicationError || modelStateErrors || 'Server error');
  }
}
