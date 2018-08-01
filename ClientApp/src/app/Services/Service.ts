import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Doctor } from '../Models/doctor';
import { EntityBase } from './../Models/entity-base';

@Injectable()
export abstract class  Service<T extends EntityBase> {
   url: string;
   abstract getById(id: number): T;
   abstract list(): Promise<T[]> ;
}
