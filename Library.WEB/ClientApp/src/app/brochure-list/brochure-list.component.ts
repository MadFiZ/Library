import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Observable } from "rxjs/Observable";
import { BrochureService } from '../brochure-list/brochure.service';
import { Brochure } from "../brochure-list/brochure";
import { State, process } from '@progress/kendo-data-query';
import { windowProvider } from '../window';
import { forEach } from '@angular/router/src/utils/collection';
import { TypeOfCover } from '../enums/typeofcover';

const createFormGroup = dataItem => new FormGroup({
  'id': new FormControl(dataItem.id),
  'name': new FormControl(dataItem.name),
  'typeOfCover': new FormControl(dataItem.typeOfCover),
  'numberOfPages': new FormControl(dataItem.numberOfPages),
});

@Component({
  selector: 'app-brochure-list',
  templateUrl: './brochure-list.component.html',
  styleUrls: ['./brochure-list.component.css']
})
export class BrochureListComponent implements OnInit {

  public brochure: Brochure = new Brochure();
  public brochures: Brochure[];
  public formGroup: FormGroup;
  private editedRowIndex: number;
  private counter: number;
  CoverTypes: typeof TypeOfCover = TypeOfCover;
  public typesOfCover: string[]
  public selectedValue: number;

  public gridState: State = {
    sort: [],
    skip: 0,
    take: 10
  };

  public onStateChange(state: State) {
    this.gridState = state;
    this.loadBrochures();
  }

  constructor(private brochureService: BrochureService,
    @Inject(windowProvider.provide) private window: Window) { }

  ngOnInit() {
    this.loadBrochures();
    this.loadTypes();
  }

  loadBrochures() {
    this.brochureService.getBrochures()
      .subscribe((data: Brochure[]) => this.brochures = data);
  }

  loadTypes() {
    var typeOfCover = Object.keys(this.CoverTypes);
    this.typesOfCover = typeOfCover.slice(typeOfCover.length / 2);
  }

  // сохранение данных
  public saveHandler({ sender, rowIndex, formGroup, isNew }): void {

    this.brochure = formGroup.value;

    if (isNew) {
      this.brochureService.createBrochure(this.brochure)
        .subscribe((data: Brochure) => this.brochures.push(data));
    } else {
      this.brochureService.updateBrochure(this.brochure)
        .subscribe(data => this.loadBrochures());
    }

    sender.closeRow(rowIndex);
  }

  public editHandler({ sender, rowIndex, dataItem }) {
    this.closeEditor(sender);

    this.formGroup = createFormGroup(dataItem);
    this.brochure = this.formGroup.value;

    this.selectedValue = this.brochure.typeOfCover;

    this.editedRowIndex = rowIndex;

    sender.editRow(rowIndex, this.formGroup);
  }

  public removeHandler({ dataItem }): void {
    this.brochureService.deleteBrochure(dataItem.id)
      .subscribe(data => this.loadBrochures());
  }
  public addHandler({ sender }) {
    this.closeEditor(sender);
    this.counter = this.brochures.length + 1;
    this.formGroup = createFormGroup({
      'id': this.counter++,
      'name': '',
      'typeOfCover': this.selectedValue,
      'numberOfPages': 0,
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
