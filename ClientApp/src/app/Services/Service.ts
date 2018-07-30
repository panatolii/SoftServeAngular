import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Doctor } from '../Models/doctor';

@Injectable()
export abstract class  Service<T> {
   url: string;
   abstract getById(id: number): T;
   abstract list(): Observable<T> ;
}
