import { ApiProvider } from './ApiProvider';
import { HttpClient, HttpResponse, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Injectable } from '../../../node_modules/@angular/core';

@Injectable()
export class DbProvider<T> extends ApiProvider<T> {
  constructor(private http: HttpClient) {
    super();
  }

  public get(url: string): Observable<T> {
    url = this.GetFullUr(url);
    console.log('Test DbProvider');
    console.log('URL: ', url);
    console.log(this.http.get<T>(url));
    return this.http.get<T>(url);
  }

  private GetFullUr(url: string): string {
    return `${environment.apiUrl}/${url}`;
  }

}
