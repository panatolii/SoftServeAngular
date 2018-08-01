export abstract class EntityBase {
  id: number;
  constructor(fields: any) {
    Object.assign(this, fields);

  }
}
