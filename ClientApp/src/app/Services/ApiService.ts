import { Injectable } from '@angular/core';
import {Service} from './Service';
import { ApiProvider } from './ApiProvider';
import { Observable } from 'rxjs';
import { Doctor } from '../Models/doctor';
import { EntityBase } from '../Models/entity-base';
import { Http, Response } from '@angular/http';

@Injectable()
 export class ApiService<T extends EntityBase> extends Service<T> {

   constructor(private provider: ApiProvider<T>) {
     super();
   }

   list(): Promise<T[]> {
    return this.provider.getList(this.url).then(response => {
      return response;
     }).catch();
  }

  getById(id: number): T {
    throw new Error('Method not implemented.');
  }
}


