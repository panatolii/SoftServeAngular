import { EntityBase } from './entity-base';


export class Doctor extends EntityBase {
  FirstName: string;
  LastName: string;
  Age: number;
  Image: number;
  Description: string;



  get fullName(): string {
     return `${this.FirstName} ${this.LastName}`;

  }
}
