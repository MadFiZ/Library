import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Observable } from "rxjs/Observable";
import { BookService } from '../book-list/book.service';
import { Book } from "../book-list/book";
import { SelectHouse } from "../book-list/selecthouse";
import { State, process } from '@progress/kendo-data-query';
import { windowProvider } from '../window';
import { forEach } from '@angular/router/src/utils/collection';

const createFormGroup = dataItem => new FormGroup({
  'id': new FormControl(dataItem.id),
  'name': new FormControl(dataItem.name),
  'author': new FormControl(dataItem.author),
  'yearOfPublishing': new FormControl(dataItem.yearOfPublishing),
  'publicationHouseIds': new FormControl(dataItem.publicationHouseIds),
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
  public selectedItems: SelectHouse[];

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

  loadSelectedItems(id: number) {
    this.bookService.getSelectedHouses(id)
      .subscribe((data: SelectHouse[]) => this.selectedItems = data);
  }

  loadBooks() {
    this.bookService.books()
      .subscribe((data: Book[]) => this.books = data);
  }

  loadHouses() {
    this.bookService.houses()
      .subscribe((data: SelectHouse[]) => this.houses = data);
  }
  // сохранение данных
  public saveHandler({ sender, rowIndex, formGroup, isNew }): void {

    this.book = formGroup.value;
    var ids = "";
    var names = "";
    for (var _i = 0; _i < this.selectedItems.length; _i++) 
    {
      ids += this.selectedItems[_i].id.toString() + " ";
      names += this.selectedItems[_i].name + " ";
    }

    this.book.publicationHouseIds = ids;
    this.book.publicationHouseNames = names;
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
     this.book = this.formGroup.value;
    this.loadSelectedItems(this.book.id);

    this.editedRowIndex = rowIndex;

    sender.editRow(rowIndex, this.formGroup);
  }

  public removeHandler({ dataItem }): void {
    this.bookService.deleteBook(dataItem.id)
      .subscribe(data => this.loadBooks());
  }
  public addHandler({ sender }) {
    this.closeEditor(sender);
    this.selectedItems = null;
    this.formGroup = createFormGroup({
      'id': 0,
      'name': '',
      'author': '',
      'yearOfPublishing': 0,
      'publicationHouseIds': '',
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
