import { ApiProvider } from './ApiProvider';
import { HttpClient, HttpResponse, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Injectable } from '../../../node_modules/@angular/core';
import { EntityBase } from '../Models/entity-base';

@Injectable()
export class DbProvider<T extends EntityBase> extends ApiProvider<T> {

  constructor(private http: HttpClient) {
    super();
  }

  private GetFullUr(url: string): string {
    return `${environment.apiUrl}/${url}`;
  }

  getList(url: string): Promise<T[]> {
    url = this.GetFullUr(url);
    return this.http.get<T[]>(url).toPromise();
  }

}
