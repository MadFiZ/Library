import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { BookService } from '../book-list/book.service';
import { Book } from "../book-list/book";
import { SelectHouse } from "../book-list/selecthouse";
import { State, process } from '@progress/kendo-data-query';
import { windowProvider } from '../window';

const createFormGroup = dataItem => new FormGroup({
  'id': new FormControl(dataItem.id),
  'name': new FormControl(dataItem.name),
  'author': new FormControl(dataItem.author),
  'yearOfPublishing': new FormControl(dataItem.yearOfPublishing),
  'publicationHouseNames': new FormControl(dataItem.publicationHouseNames)
});

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {

  public book: Book = new Book();
  public books: Book[];
  public formGroup: FormGroup;
  private editedRowIndex: number;
  public houses: SelectHouse[];

  public gridState: State = {
    sort: [],
    skip: 0,
    take: 10
  };

  public onStateChange(state: State) {
    this.gridState = state;
    this.loadBooks();
    this.loadHouses();
  }

  constructor(private bookService: BookService,
    @Inject(windowProvider.provide) private window: Window) { }

  ngOnInit() {
    this.loadBooks();
    this.loadHouses();
  }

  loadBooks() {
    this.bookService.getBooks()
      .subscribe((data: Book[]) => this.books = data);
  }

  loadHouses() {
    this.bookService.getHouses()
      .subscribe((data: any[]) => this.houses = data);
  }
  // сохранение данных
  public saveHandler({ sender, rowIndex, formGroup, isNew }): void {

    this.book = formGroup.value;

    if (isNew) {
      this.bookService.createBook(this.book)
        .subscribe((data: Book) => this.books.push(data));
    } else {
      this.bookService.updateBook(this.book)
        .subscribe(data => this.loadBooks());
    }

    sender.closeRow(rowIndex);
  }

  public editHandler({ sender, rowIndex, dataItem }) {
    this.closeEditor(sender);

    this.formGroup = createFormGroup(dataItem);

    this.editedRowIndex = rowIndex;

    sender.editRow(rowIndex, this.formGroup);
  }

  public removeHandler({ dataItem }): void {
    this.bookService.deleteBook(dataItem.id)
      .subscribe(data => this.loadBooks());
  }
  public addHandler({ sender }) {
    this.closeEditor(sender);

    this.formGroup = createFormGroup({
      'name': '',
      'author': '',
      'yearOfPublishing': 0,
      'publicationHouseNames': ''
    });

    sender.addRow(this.formGroup);
  }

  private closeEditor(grid, rowIndex = this.editedRowIndex) {
    grid.closeRow(rowIndex);
    this.editedRowIndex = undefined;
    this.formGroup = undefined;
  }

  public cancelHandler({ sender, rowIndex }) {
    this.closeEditor(sender, rowIndex);
  }

}
