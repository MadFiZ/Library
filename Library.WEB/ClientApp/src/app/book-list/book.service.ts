import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import { Book } from './book';
import { SelectHouse } from './selecthouse'

@Injectable()
export class BookService {

  private url = "/api/books";
  private url1 = "/api/housevalues"
  private counter: number = this.books.length;

  constructor(private http: HttpClient) {
  }

  public books(): Observable<Book[]> {
    return this.getBooks();
  }

  public houses(): Observable<object> {
    return this.getHouses();
  }

  getHouses(): Observable<SelectHouse> {  
    return this.http.get<SelectHouse[]>(this.url1);
  }
  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.url);
  }

  createBook(book: Book) {
    book.id = this.counter++;
    return this.http.post(this.url, book);
  }
  updateBook(book: Book) {
    return this.http.put(this.url + '/' + book.id, book);
  }
  deleteBook(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
