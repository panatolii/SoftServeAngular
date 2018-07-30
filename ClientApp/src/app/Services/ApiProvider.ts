import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export abstract class ApiProvider<T> {
    abstract get(controller: string): Observable<T>;
}
