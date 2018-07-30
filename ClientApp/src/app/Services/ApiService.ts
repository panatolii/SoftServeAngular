import { Injectable } from '@angular/core';
import {Service} from './Service';
import { ApiProvider } from './ApiProvider';
import { Observable } from 'rxjs';
import { Doctor } from '../Models/doctor';

@Injectable()
 export class ApiService<T> extends Service<T> {

   constructor(private provider: ApiProvider<T>) {
     super();
   }

  getById(id: number): T {
    throw new Error('Method not implemented.');
  }

  list(): Observable<T> {
    return this.provider.get(this.url);
  }
}


