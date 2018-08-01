import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EntityBase } from '../Models/entity-base';

@Injectable()
export abstract class ApiProvider<T> {
    abstract getList(controller: string): Promise<T[]>;
}
