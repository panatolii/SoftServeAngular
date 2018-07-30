import { EntityBase } from './entity-base';


export class Doctor extends EntityBase {
  FistName: string;
  LastName: string;
  Age: number;
  Image: number;
  Description: string;

  get fullName(): string {
    return this.FistName + ' 1' + this.LastName;
  }
}
