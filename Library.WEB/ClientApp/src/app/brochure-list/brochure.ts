import { TypeOfCover } from '../enums/typeofcover';

export class Brochure {
  constructor(
    public id?: number,
    public name?: string,
    public typeOfCover?: TypeOfCover,
    public numberOfPages?: number) { }
}
