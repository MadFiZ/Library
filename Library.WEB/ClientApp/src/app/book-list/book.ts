export class Book {
  constructor(
    public id?: number,
    public name?: string,
    public author?: string,
    public yearOfPublishing?: number,
    public publicationHouseIds?: string,
    public publicationHouseNames?: string) { }
}
