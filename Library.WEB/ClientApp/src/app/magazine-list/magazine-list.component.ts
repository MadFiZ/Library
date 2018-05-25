import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Observable } from "rxjs/Observable";
import { MagazineService } from '../magazine-list/magazine.service';
import { Magazine } from "../magazine-list/magazine";
import { State, process } from '@progress/kendo-data-query';
import { windowProvider } from '../window';
import { forEach } from '@angular/router/src/utils/collection';

const createFormGroup = dataItem => new FormGroup({
  'id': new FormControl(dataItem.id),
  'name': new FormControl(dataItem.name),
  'number': new FormControl(dataItem.number),
  'yearOfPublishing': new FormControl(dataItem.yearOfPublishing),
});

@Component({
  selector: 'app-magazine-list',
  templateUrl: './magazine-list.component.html',
  styleUrls: ['./magazine-list.component.css']
})
export class MagazineListComponent implements OnInit {

  public magazine: Magazine = new Magazine();
  public magazines: Magazine[];
  public formGroup: FormGroup;
  private editedRowIndex: number;
  private counter: number;

  public gridState: State = {
    sort: [],
    skip: 0,
    take: 10
  };

  public onStateChange(state: State) {
    this.gridState = state;
    this.loadMagazines();
  }

  constructor(private magazineService: MagazineService,
    @Inject(windowProvider.provide) private window: Window) { }

  ngOnInit() {
    this.loadMagazines();
  }

  loadMagazines() {
    this.magazineService.getMagazines()
      .subscribe((data: Magazine[]) => this.magazines = data);
  }

  public saveHandler({ sender, rowIndex, formGroup, isNew }): void {

    this.magazine = formGroup.value;

    if (isNew) {
      this.magazineService.createMagazine(this.magazine)
        .subscribe((data: Magazine) => this.magazines.push(data));
    } else {
      this.magazineService.updateMagazine(this.magazine)
        .subscribe(data => this.loadMagazines());
    }

    sender.closeRow(rowIndex);
  }

  public editHandler({ sender, rowIndex, dataItem }) {
    this.closeEditor(sender);

    this.formGroup = createFormGroup(dataItem);
    this.magazine = this.formGroup.value;

    this.editedRowIndex = rowIndex;

    sender.editRow(rowIndex, this.formGroup);
  }

  public removeHandler({ dataItem }): void {
    this.counter--;
    this.magazineService.deleteMagazine(dataItem.id)
      .subscribe(data => this.loadMagazines());
  }
  public addHandler({ sender }) {
    this.closeEditor(sender);
    this.counter = this.magazines.length + 1;
    this.formGroup = createFormGroup({
      'id': this.counter++,
      'name': '',
      'number': 0,
      'yearOfPublishing': 0,
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
