import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import { Book } from './book';

@Injectable()
export class BookService {

  private url = "/api/books";
  private counter: number = this.books.length;

  constructor(private http: HttpClient) {
  }

  public books(): Observable<Book[]> {
    return this.getBooks();
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
