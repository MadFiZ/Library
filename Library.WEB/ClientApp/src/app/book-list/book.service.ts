import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import { Book } from './book';
import { SelectHouse } from './selecthouse'

@Injectable()
export class BookService {

  private url = "/api/books";
  private url1 = "/api/housevalues"

  constructor(private http: HttpClient) {
  }

  public books(): Observable<Book[]> {
    return this.http.get<Book[]>(this.url);
  }

  public houses(): Observable<SelectHouse[]> {
    return this.http.get<SelectHouse[]>(this.url1);
  }

  getSelectedHouses(id: number): Observable<SelectHouse[]> {
    return this.http.get<SelectHouse[]>(this.url1 + '/' + id);
  }

  createBook(book: Book) {
    return this.http.post(this.url, book);
  }
  updateBook(book: Book) {
    return this.http.put(this.url + '/' + book.id, book);
  }
  deleteBook(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
